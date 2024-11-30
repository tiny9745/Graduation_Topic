using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Berry : MonoBehaviour
{
    // Start is called before the first frame update
    int berry = 3;
    bool isExplode = false;
    float explode_time_max = 2,timmer = 0;
    Color Berry_color;
    private Material objectMaterial;     // 物件的材質
    private Color originalColor;         // 原本的顏色
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isExplode)
        {
            timmer += Time.deltaTime;
            if (berry == 0 && timmer < explode_time_max)
            {
                objectMaterial.color = originalColor;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(berry != 0) 
        {
            isExplode = true;
            if (timmer > explode_time_max) Bomb_Berry_Explode(other); 
        }
    }

    private void Bomb_Berry_Explode(Collider other)
    {
        if (other.tag == "Player")
        {
            static_parameters.MC_HP -= 10 * berry;
        }
        if (other.name == "請改成在NPC方面程式碼_Bomb_Berry")
        {
            
        }
        Destroy(gameObject, 0.1f);
    }

    IEnumerator FlashRedIncreasingSpeed()
    {
        float elapsedTime = 0f;          // 已經過的時間
        float flashInterval = 0.5f;      // 初始閃爍間隔

        while (elapsedTime < explode_time_max)
        {
            elapsedTime += flashInterval;

            // 切換顏色：紅色與原色
            if (objectMaterial.color == originalColor)
                objectMaterial.color = Berry_color;
            else
                objectMaterial.color = originalColor;

            yield return new WaitForSeconds(flashInterval);

            // 減少閃爍間隔（加快速度），最低間隔為 0.05 秒
            flashInterval = Mathf.Max(0.05f, flashInterval * 0.9f);
        }
    }
}
