using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keep : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    void Start()
    {
        Player  = GameObject.Find("Player");
        DontDestroyOnLoad(Player);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetPosition;
    }

    // 取消訂閱場景加載完成的事件
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetPosition;
    }

    // 在場景加載完成後重設物件位置到原點
    private void ResetPosition(Scene scene, LoadSceneMode mode)
    {
        // 將物件位置設置為原點
        transform.position = Vector3.zero;
    }
}
