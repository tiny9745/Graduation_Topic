using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Book; public GameObject Extra1;
    bool OC = true; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // MoveDiary();

    }
    public void MoveDiary(){
        if (OC)
        {
            print(OC);
            Vector3 targetPosition1 = new Vector3(-300, Book.transform.localPosition.y, Book.transform.localPosition.z);
            Book.transform.localPosition = targetPosition1;

            Vector3 targetPosition2 = new Vector3(-250, Extra1.transform.localPosition.y, Extra1.transform.localPosition.z);
            Extra1.transform.localPosition = targetPosition2;
            OC = false;
        }
        else
        {
            print(OC);
            Vector3 targetPosition1 = new Vector3(0, Book.transform.localPosition.y, Book.transform.localPosition.z);
            Book.transform.localPosition = targetPosition1;

            Vector3 targetPosition2 = new Vector3(0, Extra1.transform.localPosition.y, Extra1.transform.localPosition.z);
            Extra1.transform.localPosition = targetPosition2;
            OC = true;
        }
    }
}
