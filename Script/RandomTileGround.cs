using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomTileGround : MonoBehaviour
{
    public Sprite[] sprites; // Custom number of sprite images
    public int tilesX = 10; // Number of tiles on the X-axis
    public int tilesZ = 10; // Number of tiles on the Z-axis
    public float tileSize = 1.0f; // size of each tile
    public GameObject Player;
    public GameObject Player_S;
    Vector3 minBoundary; // Define the minimum boundary
    Vector3 maxBoundary; // Define the maximum boundary

    void Start()
    {
        Player = GameObject.Find("Player");
        Player_S = GameObject.Find("Player_S");
        minBoundary = new Vector3(-tilesX * tileSize / 2, 3f, -tilesZ * tileSize / 2);
        maxBoundary = new Vector3(tilesX * tileSize / 2, 3f, tilesZ * tileSize / 2);

        // Make sure textures are readable
        MakeTexturesReadable();
        // Create a new GameObject to use as the ground
        GameObject ground = new GameObject("Ground");
        MeshRenderer meshRenderer = ground.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = ground.AddComponent<MeshFilter>();
        Mesh mesh = new();

        // Calculate vertices, UVs and triangles
        int tileCount = tilesX * tilesZ;
        Vector3[] vertices = new Vector3[tileCount * 4];
        Vector2[] uvs = new Vector2[tileCount * 4];
        int[] triangles = new int[tileCount * 6];

        int vertIndex = 0;
        int triIndex = 0;

        // Create a texture that combines all sprite textures
        Texture2D combinedTexture = new Texture2D(1, 1);
        Texture2D[] textures = new Texture2D[sprites.Length];
        for (int i = 0; i < sprites.Length; i++)
        {
            textures[i] = sprites[i].texture;
        }
        Rect[] rects = combinedTexture.PackTextures(textures, 0, 4096); // Adjust the maximum size

        // Calculate center point position
        float halfSizeX = (tilesX * tileSize) / 2.0f;
        float halfSizeZ = (tilesZ * tileSize) / 2.0f;

        for (int x = 0; x < tilesX; x++)
        {
            for (int z = 0; z < tilesZ; z++)
            {
                // Calculate the tile position, taking the center point as the origin
                float xPos = x * tileSize - halfSizeX;
                float zPos = z * tileSize - halfSizeZ;

                // Allocate vertices to each tile
                vertices[vertIndex + 0] = new Vector3(xPos, 0, zPos);
                vertices[vertIndex + 1] = new Vector3(xPos + tileSize, 0, zPos);
                vertices[vertIndex + 2] = new Vector3(xPos, 0, zPos + tileSize);
                vertices[vertIndex + 3] = new Vector3(xPos + tileSize, 0, zPos + tileSize);

                // Determine the sprite index based on the tile's position
                int spriteIndex = (z * tilesX + x) % sprites.Length;
                Rect rect = rects[spriteIndex];

                // Assign UVs to each tile
                uvs[vertIndex + 0] = new Vector2(rect.xMin, rect.yMin);
                uvs[vertIndex + 1] = new Vector2(rect.xMax, rect.yMin);
                uvs[vertIndex + 2] = new Vector2(rect.xMin, rect.yMax);
                uvs[vertIndex + 3] = new Vector2(rect.xMax, rect.yMax);

                // Allocate triangles to each tile
                triangles[triIndex + 0] = vertIndex + 0;
                triangles[triIndex + 1] = vertIndex + 2;
                triangles[triIndex + 2] = vertIndex + 1;
                triangles[triIndex + 3] = vertIndex + 1;
                triangles[triIndex + 4] = vertIndex + 2;
                triangles[triIndex + 5] = vertIndex + 3;

                vertIndex += 4;
                triIndex += 6;
            }
        }

        // Apply vertices, UVs, and triangles to the mesh
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        // Assign mesh to MeshFilter and MeshRenderer
        meshFilter.mesh = mesh;

        // Create and assign a material
        Material material = new Material(Shader.Find("Standard")); // Use a shader that supports depth writing
        material.mainTexture = combinedTexture; // Use merged textures
        meshRenderer.material = material;
        meshRenderer.sortingOrder = 0; // Set sort order

        ResetPosition();
    }

    void Update()
    {
        Player.transform.position = new Vector3(
            Mathf.Clamp(Player.transform.position.x, minBoundary.x+20, maxBoundary.x-20),
            Mathf.Clamp(Player.transform.position.y, minBoundary.y, maxBoundary.y),
            Mathf.Clamp(Player.transform.position.z, minBoundary.z+10, maxBoundary.z-30)
        );
    }

    // 在場景加載完成後重設物件位置到原點
    void ResetPosition()
    {
        // 將物件位置設置為原點
        Player_S.transform.position = new Vector3(0, 0, -tilesZ * tileSize / 2);
        Player.transform.position = Player_S.transform.position;
    }

    void MakeTexturesReadable()
    {
#if UNITY_EDITOR
        foreach (Sprite sprite in sprites)
        {
            Texture2D texture = sprite.texture;
            string assetPath = AssetDatabase.GetAssetPath(texture);
            TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;

            if (importer != null)
            {
                importer.isReadable = true;
                AssetDatabase.ImportAsset(assetPath);
            }
        }
        AssetDatabase.Refresh();
#endif
    }
}

public class MakeTexturesReadable : MonoBehaviour
{
    public Texture2D[] textures; //  Assign sprite texture

    void Start()
    {
        MakeTexturesReadableMethod();
    }

    void MakeTexturesReadableMethod()
    {
#if UNITY_EDITOR
        foreach (Texture2D texture in textures)
        {
            string assetPath = AssetDatabase.GetAssetPath(texture);
            TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;

            if (importer != null)
            {
                importer.isReadable = true;
                AssetDatabase.ImportAsset(assetPath);
            }
        }
        AssetDatabase.Refresh();
#endif
    }
}
