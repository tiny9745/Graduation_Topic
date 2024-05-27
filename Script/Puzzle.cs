using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Book; public GameObject Extra1;
    bool OC = false; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // MoveDiary();
    }
    public void Open()
    {
        OC = true;
    }
    public void Close()
    {
        OC = false;
    }
    public void MoveDiary(){
        if (OC)
        {
            Book.transform.position +=Vector3.MoveTowards(Book.transform.localPosition,new Vector3(-300,0,0),0.1f);
            Extra1.transform.position +=Vector3.MoveTowards(Extra1.transform.localPosition,new Vector3(-250,0,0),0.1f);
        }
        else
        {
            Book.transform.position = Vector3.MoveTowards(Book.transform.localPosition,new Vector3(0,0,0),0.1f);
            Extra1.transform.position = Vector3.MoveTowards(Extra1.transform.localPosition,new Vector3(0,0,0),0.1f);
        }
    }
}
