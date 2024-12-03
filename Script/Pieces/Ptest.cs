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
            addp();
        }
    }
    void addp(){
        thisItem = GetRandomPiece();
        Debug.Log(thisItem);
        PieceManager.Instance.Add(thisItem);
    }
    Diary_piece GetRandomPiece()
{
    // Assume you have a list of pre-created Diary_piece instances
    var allPieces = Resources.LoadAll<Diary_piece>("Piece");
    return allPieces[Random.Range(0, allPieces.Length)];
}
}