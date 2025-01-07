using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public Text_Array text_array;
    public Ptest ptest;
    GameObject targetObject;
    void Start()
    {
        // text_array = FindObjectOfType<Text_Array>();
        targetObject = GameObject.Find("UI");

        if (targetObject != null)
        {
            ptest = targetObject.GetComponent<Ptest>();
            if (ptest == null)
            {
                Debug.LogWarning("Ptest component not found on UI!");
            }
        }
        else
        {
            Debug.LogWarning("UI not found in the scene!");
        }
        print("drop_exist:" + transform.position);
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            if (targetObject != null)
            {
                ptest._to_Drop();
                //text_array.SetRandomTextExistToTrue();
            }
            Destroy(gameObject);
        }
    }
}
