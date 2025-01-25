using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class skill_41_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "NPC")
        {
           Invoke("Destroy", 0.1f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
