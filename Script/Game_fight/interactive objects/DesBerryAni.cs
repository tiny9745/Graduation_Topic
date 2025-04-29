using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesBerryAni : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Invoke("des", 1f);
    }

    void des(){
        Destroy(gameObject);
    }
}
