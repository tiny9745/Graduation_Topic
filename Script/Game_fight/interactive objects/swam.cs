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
            static_parameters.MC_Wspeed = static_parameters.MC_Wspeed * 0.7f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (Upgrade.Speed_LV)
            {
                case 1:
                    static_parameters.MC_Wspeed = 15f;
                    break;
                case 2:
                    static_parameters.MC_Wspeed = 18f;
                    break;
                case 3:
                    static_parameters.MC_Wspeed = 22f;
                    break;
                case 4:
                    static_parameters.MC_Wspeed = 27f;
                    break;
                case 5:
                    static_parameters.MC_Wspeed = 32f;
                    break;
                case 6:
                    static_parameters.MC_Wspeed = 38f;
                    break;
            }
        }
    }
}
