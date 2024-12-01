using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptest : MonoBehaviour
{
    // Start is called before the first frame update
    public Diary_piece thisItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P key was pressed.");
            addp();
        }
    }
    void addp(){
        Debug.Log("addp function was called.");
        PieceManager.Instance.Add(thisItem);
    }
}
