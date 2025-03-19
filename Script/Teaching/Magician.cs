using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (static_parameters.teaching_stop >= 100 && static_parameters.isTeaching == false)
        {
            Destroy(gameObject);
        }
    }
}
