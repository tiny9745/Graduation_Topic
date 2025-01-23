using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Dash_Magnification : MonoBehaviour
{
    float lifetime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime < 5f)
        {
            lifetime += Time.deltaTime;
        }
        else
        {
            lifetime = 0;
            Destroy(this);
        }
    }
}
