using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    // Update is called once per frame
    private void OnCollisionEnter(Collision Hit)
    {
        //下一關條件(測試)
        if (Hit.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("A2");
        }
    }
}
