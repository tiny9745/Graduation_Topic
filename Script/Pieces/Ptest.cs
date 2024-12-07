using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptest : MonoBehaviour
{
    // Start is called before the first frame update
    public Diary_piece thisItem;
    private List<Diary_piece> availablePieces = new List<Diary_piece>();
    private Dictionary<string, List<Diary_piece>> sortedPieces = new Dictionary<string, List<Diary_piece>>();

    private List<Diary_piece> Red, Blu, Prp, Grn, Yel = new List<Diary_piece>();
    static public List<Diary_piece> pickedPieces = new List<Diary_piece>();
    void Start()
    {
        Diary_piece[] allPieces = Resources.LoadAll<Diary_piece>("Piece");
        availablePieces.AddRange(allPieces); InitializePieceSorting();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            addp();
        }
    }
    void addp()
    {
        thisItem = GetRandomPiece();
        if (thisItem != null)
        {
            SortPiece(thisItem);
            PieceManager.Instance.Add(thisItem);           
        }else{
            return;
        }
        
    }
    Diary_piece GetRandomPiece()
    {
        if (availablePieces.Count == 0)
        {
            return null; // Handle the empty case appropriately
        }
        int randomIndex = Random.Range(0, availablePieces.Count);
        Diary_piece selectedPiece = availablePieces[randomIndex];
        pickedPieces.Add(selectedPiece);
        availablePieces.RemoveAt(randomIndex);

        return selectedPiece;
    }
    void SortPiece(Diary_piece piece)
    {
        string key = piece.PieceName.Substring(0, 3);

        if (sortedPieces.ContainsKey(key))
        {
            sortedPieces[key].Add(piece);
            print(sortedPieces[key].Count);
        }
        else
        {
            Debug.LogWarning($"Piece '{piece.PieceName}' does not match any category!");
        }
    }
    void InitializePieceSorting()
    {
        sortedPieces["Red"] = new List<Diary_piece>();
        sortedPieces["Blu"] = new List<Diary_piece>();
        sortedPieces["Prp"] = new List<Diary_piece>();
        sortedPieces["Yel"] = new List<Diary_piece>();
        sortedPieces["Grn"] = new List<Diary_piece>();
    }
}