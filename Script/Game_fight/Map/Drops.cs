using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public Text_Array text_array;

    void Start()
    {
        text_array = FindObjectOfType<Text_Array>();
        print("drop_exist:"+transform.position);
    }

    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            if (text_array != null)
            {
                print("drop_eat");
                //text_array.SetRandomTextExistToTrue();
            }
            Destroy(gameObject);
        }
    }
}
