using UnityEngine;

public class Ground_under : MonoBehaviour
{
    public GameObject targetObject; // 指定的目標物件（含子物件）
    public Texture2D combinedTexture; // 指定的 2D 貼圖（若未指定則從現有材質抓取）

    void Start()
    {
        if (targetObject != null)
        {
            ApplyMaterialToChildren(targetObject);
        }
        else
        {
            Debug.LogWarning("未指定目標物件！");
        }
    }

    void ApplyMaterialToChildren(GameObject obj)
    {
        foreach (MeshRenderer renderer in obj.GetComponentsInChildren<MeshRenderer>())
        {
            // 創建並設置材質
            Material material = new Material(Shader.Find("Standard"));
            
            // 設定材質為透明模式，並強制渲染於所有物件後
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0); // 禁用深度寫入
            material.renderQueue = 1000; // 設置為透明渲染隊列

            // 禁用深度測試，確保地面物件不會遮蔽其他物件
            material.SetOverrideTag("RenderType", "Transparent");
            material.EnableKeyword("_ALPHABLEND_ON");

            // 如果有指定貼圖，使用指定貼圖；否則嘗試從原材質抓取
            if (combinedTexture != null)
            {
                material.mainTexture = combinedTexture;
            }
            else if (renderer.material != null && renderer.material.mainTexture != null)
            {
                material.mainTexture = renderer.material.mainTexture;
                Debug.Log($"從 {renderer.gameObject.name} 抓取貼圖：{material.mainTexture.name}");
            }
            else
            {
                Debug.LogWarning($"{renderer.gameObject.name} 沒有貼圖可抓取！");
            }

            // 設定材質給渲染器
            renderer.material = material;

            // 啟用陰影投射和接收（如果需要，否則可刪除）
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            renderer.receiveShadows = true;
        }

        Debug.Log($"已完成對 {obj.name} 及其子物件的材質設置");
    }
}
