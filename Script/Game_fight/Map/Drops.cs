using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public Ptest ptest;
    GameObject targetObject;
    Animator Chest_Animator;
    void Start()
    {
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
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            if (targetObject != null)
            {
                if (static_parameters.teaching_stop <= 6) static_parameters.teaching_stop = 7;
                Debug.Log("static_parameters.teaching_stop: " + static_parameters.teaching_stop);
                int randomIndex = Random.Range(5, 8);
                ptest._to_Drop(randomIndex);
            }
            Destroy(gameObject);
        }
    }
}
