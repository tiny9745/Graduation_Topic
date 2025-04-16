using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_door : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject back_door;
    void Start()
    {
        if (static_parameters.teaching_stop < 100 || static_parameters.isTeaching == true)
        {
           back_door.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (static_parameters.teaching_stop >= 100)
        {
            back_door.SetActive(true);
        }
    }
}
