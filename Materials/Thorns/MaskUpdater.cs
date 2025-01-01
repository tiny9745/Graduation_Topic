using UnityEngine;

public class MaskUpdater : MonoBehaviour
{
    public GameObject cubeMask; // Cube 遮罩物件
    public Material maskedMaterial; // MaskedObject 的材質

    void Update()
    {
        if (cubeMask != null && maskedMaterial != null)
        {
            // 傳遞 Cube 中心與大小
            Vector3 cubeCenter = cubeMask.transform.position;
            Vector3 cubeSize = cubeMask.transform.localScale;

            maskedMaterial.SetVector("_CubeCenter", new Vector4(cubeCenter.x, cubeCenter.y, cubeCenter.z, 0));
            maskedMaterial.SetVector("_CubeSize", new Vector4(cubeSize.x, cubeSize.y, cubeSize.z, 0));
        }
    }
}