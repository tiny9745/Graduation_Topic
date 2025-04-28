using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_dairy : MonoBehaviour
{
    private bool P1 = false;
    public GameObject BOSS_paper_button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && P1 && !Setting_keybroad.ESC_col)
        {
            Debug.Log("FFFFF");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            P1 = true;
            BOSS_paper_button.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            P1 = false;
            BOSS_paper_button.SetActive(false);
        }
    }
}
