using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Dairy; public GameObject Extra1;
    bool OC = false; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        OC = true;
    }
    public void Close()
    {
        OC = false;
    }
    void MoveDiary(){
        if (OC)
        {
            Dairy.transform.position +=Vector3.MoveTowards(Dairy.transform.localPosition,new Vector3(-155,0,0),0.1f);
            Extra1.transform.position +=Vector3.MoveTowards(Extra1.transform.localPosition,new Vector3(-150,0,0),0.1f);
        }
        else
        {
            Dairy.transform.position = Vector3.MoveTowards(Dairy.transform.position, Extra1.transform.position, 0.1f);
        }
    }
}
