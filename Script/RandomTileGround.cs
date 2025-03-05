using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomTileGround : MonoBehaviour
{
    public Sprite[] sprites; // Custom number of sprite images
    public int tilesX = 10; // Number of tiles on the X-axis
    public int tilesZ = 10; // Number of tiles on the Z-axis
    public float tileSize = 1.0f; // Size of each tile
    // public GameObject player;
    public GameObject player_S;

    public Vector3 minBoundary; // Define the minimum boundary
    public Vector3 maxBoundary; // Define the maximum boundary
    public int padding_X_min = 10, padding_X_max = 10;
    public int padding_Z_min = 10, padding_Z_max = 10;

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Texture2D combinedTexture;
    private Material material;

    void Start()
    {
        InitializeBoundaries();
        MakeTexturesReadable();
        CreateGroundMesh();
        CreateAndAssignMaterial();
        ResetPlayerPosition();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetPlayerPosition();
    }

    void InitializeBoundaries()
    {
        // player = GameObject.Find("Player");
        player_S = GameObject.Find("Player_S");

        float halfX = tilesX * tileSize / 2;
        float halfZ = tilesZ * tileSize / 2;

        minBoundary = new Vector3(-halfX, 3f, -halfZ);
        maxBoundary = new Vector3(halfX, 3f, halfZ);
    }

    void CreateGroundMesh()
    {
        GameObject ground = new GameObject("Ground");
        meshRenderer = ground.AddComponent<MeshRenderer>();
        meshFilter = ground.AddComponent<MeshFilter>();
        mesh = new Mesh();

        GenerateMeshData();
        ApplyMeshData();
    }

    void GenerateMeshData()
    {
        int quadCount = (tilesX / 2) * (tilesZ / 2) * 4;
        Vector3[] vertices = new Vector3[quadCount * 4];
        Vector2[] uvs = new Vector2[quadCount * 4];
        int[] triangles = new int[quadCount * 6];

        combinedTexture = CombineTextures(sprites, out Rect[] rects);

        int vertIndex = 0;
        int triIndex = 0;

        float halfSizeX = (tilesX * tileSize) / 2.0f;
        float halfSizeZ = (tilesZ * tileSize) / 2.0f;

        for (int x = 0; x < tilesX; x += 2)
        {
            for (int z = 0; z < tilesZ; z += 2)
            {
                float xPos = x * tileSize - halfSizeX;
                float zPos = z * tileSize - halfSizeZ;

                AssignQuad(vertices, uvs, triangles, ref vertIndex, ref triIndex, xPos, zPos, rects[0]); // Bottom-left
                AssignQuad(vertices, uvs, triangles, ref vertIndex, ref triIndex, xPos + tileSize, zPos, rects[1]); // Bottom-right
                AssignQuad(vertices, uvs, triangles, ref vertIndex, ref triIndex, xPos, zPos + tileSize, rects[2]); // Top-left
                AssignQuad(vertices, uvs, triangles, ref vertIndex, ref triIndex, xPos + tileSize, zPos + tileSize, rects[3]); // Top-right
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void ApplyMeshData()
    {
        meshFilter.mesh = mesh;
    }

    Texture2D CombineTextures(Sprite[] sprites, out Rect[] rects)
    {
        Texture2D combined = new Texture2D(1, 1);
        Texture2D[] textures = new Texture2D[sprites.Length];

        for (int i = 0; i < sprites.Length; i++)
        {
            textures[i] = sprites[i].texture;
        }

        rects = combined.PackTextures(textures, 0, 4096);
        return combined;
    }

    void AssignQuad(Vector3[] vertices, Vector2[] uvs, int[] triangles, ref int vertIndex, ref int triIndex, float xPos, float zPos, Rect rect)
    {
        // Allocate vertices for a quad
        vertices[vertIndex + 0] = new Vector3(xPos, 0, zPos);
        vertices[vertIndex + 1] = new Vector3(xPos + tileSize, 0, zPos);
        vertices[vertIndex + 2] = new Vector3(xPos, 0, zPos + tileSize);
        vertices[vertIndex + 3] = new Vector3(xPos + tileSize, 0, zPos + tileSize);

        // Assign UVs
        uvs[vertIndex + 0] = new Vector2(rect.xMin, rect.yMin);
        uvs[vertIndex + 1] = new Vector2(rect.xMax, rect.yMin);
        uvs[vertIndex + 2] = new Vector2(rect.xMin, rect.yMax);
        uvs[vertIndex + 3] = new Vector2(rect.xMax, rect.yMax);

        // Assign triangles
        triangles[triIndex + 0] = vertIndex + 0;
        triangles[triIndex + 1] = vertIndex + 2;
        triangles[triIndex + 2] = vertIndex + 1;
        triangles[triIndex + 3] = vertIndex + 1;
        triangles[triIndex + 4] = vertIndex + 2;
        triangles[triIndex + 5] = vertIndex + 3;

        vertIndex += 4;
        triIndex += 6;
    }

    void CreateAndAssignMaterial()
    {
        material = new Material(Shader.Find("Standard"));
        material.mainTexture = combinedTexture;

        // 確保材質的 `RenderQueue` 設置正確，並且材質支援透明度
        material.SetFloat("_Glossiness", 0.0f);  // 你可以調整這個值來控制表面的光滑度
        material.SetFloat("_Metallic", 0.0f);  // 調整這個值來控制材質的金屬度
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 1);  // ZWrite 可以確保正確的深度渲染
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = 2000;  // 設定為不透明物體的渲染順序

        meshRenderer.material = material;

        // 啟用陰影投射和接收
        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        meshRenderer.receiveShadows = true;
    }

    void Update()
    {
        ClampPlayerPosition();
    }

    void ClampPlayerPosition()
    {
        player_S.transform.position = new Vector3(
            Mathf.Clamp(player_S.transform.position.x, minBoundary.x + padding_X_min, maxBoundary.x - padding_X_max),
            Mathf.Clamp(player_S.transform.position.y, minBoundary.y, maxBoundary.y),
            Mathf.Clamp(player_S.transform.position.z, minBoundary.z + padding_Z_min, maxBoundary.z - padding_Z_max)
        );
    }

    void ResetPlayerPosition()
    {
        Vector3 startPos = new Vector3(0, -1, -tilesZ * tileSize / 2);
        player_S.transform.position = startPos;
    }

    void MakeTexturesReadable()
    {
#if UNITY_EDITOR
        foreach (Sprite sprite in sprites)
        {
            TextureImporter importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(sprite.texture)) as TextureImporter;
            if (importer != null && !importer.isReadable)
            {
                importer.isReadable = true;
                AssetDatabase.ImportAsset(importer.assetPath);
            }
        }
        AssetDatabase.Refresh();
#endif
    }
}
