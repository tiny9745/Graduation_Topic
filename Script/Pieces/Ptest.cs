using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptest : MonoBehaviour
{
    // Start is called before the first frame update
    public Diary_piece thisItem;
    private List<Diary_piece> availablePieces = new List<Diary_piece>();

    void Start()
    {
        Diary_piece[] allPieces = Resources.LoadAll<Diary_piece>("Piece");
        availablePieces.AddRange(allPieces);
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
        PieceManager.Instance.Add(thisItem);
    }
    Diary_piece GetRandomPiece()
    {
    // Check if there are any pieces left to pick
         if (availablePieces.Count == 0)
        {
            Debug.LogWarning("No pieces left to pick!");
            return null; // Handle the empty case appropriately
        }

        // Pick a random index from the list
        int randomIndex = Random.Range(0, availablePieces.Count);

        // Get the piece at the random index
        Diary_piece selectedPiece = availablePieces[randomIndex];

        // Remove the selected piece from the list
        availablePieces.RemoveAt(randomIndex);

        return selectedPiece;
    }
}