using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swam : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites; // 可選圖片的陣列
    public SpriteRenderer spriteRenderer; // SpriteRenderer 組件
    void Start()
    {
        if (sprites.Length > 0)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[randomIndex];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            static_parameters.MC_Wspeed /= 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            static_parameters.MC_Wspeed *= 2;
        }
    }
}
