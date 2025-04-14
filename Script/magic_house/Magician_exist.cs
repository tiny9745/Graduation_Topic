using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician_exist : MonoBehaviour
{
    public GameObject magician;
    // Start is called before the first frame update
    void Start()
    {
        magician.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (static_parameters.isTeaching == false && static_parameters.teaching_stop >= 100)
        {
            if (magician != null)
            {
                magician.SetActive(true);
                this.enabled = false;
            }
        }
    }
}
