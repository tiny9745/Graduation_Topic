using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outside_back : MonoBehaviour
{
    private GameObject player_S;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        player_S = GameObject.Find("Player_S");
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // player_S.transform.localPosition = new Vector3(0, 0, 40);
        SceneManager.LoadScene("magic_house");
    }
}
