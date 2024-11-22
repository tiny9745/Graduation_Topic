using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item_open_click : MonoBehaviour
{
    public GameObject Item_canvas;
    public GameObject back_button;
    bool turn001 = false;

    private void Start()
    {
        Vector3 targetPosition1 = new Vector3(-3000, Item_canvas.transform.localPosition.y, Item_canvas.transform.localPosition.z);
        Item_canvas.transform.localPosition = targetPosition1;
    }
    public void OPenItem()
    {
        if (turn001)
        {
            turn001 = false;
            back_button.SetActive(false);
            Vector3 targetPosition1 = new Vector3(-3000, Item_canvas.transform.localPosition.y, Item_canvas.transform.localPosition.z);
            Item_canvas.transform.localPosition = targetPosition1;
        }
        else
        {
            turn001 = true;
            back_button.SetActive(true);
            Vector3 targetPosition1 = new Vector3(0, Item_canvas.transform.localPosition.y, Item_canvas.transform.localPosition.z);
            Item_canvas.transform.localPosition = targetPosition1;
        }
    }
    public void Back_click()
    {
        SceneManager.LoadScene("Main");
    }
}
