using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class EnableReadWrite : MonoBehaviour
{
    void Awake()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material.mainTexture.filterMode = FilterMode.Point; // Set texture filter mode
        renderer.material.mainTexture.wrapMode = TextureWrapMode.Clamp; // Set texture wrap mode
        renderer.material.EnableKeyword("_ALPHATEST_ON");
        renderer.material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        renderer.material.EnableKeyword("_EMISSION");
        renderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        renderer.material.mainTexture.filterMode = FilterMode.Trilinear;

        // Enable Read/Write
        renderer.material.mainTexture = Instantiate(renderer.material.mainTexture);
    }
}
