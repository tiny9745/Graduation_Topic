using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptest : MonoBehaviour
{
    // Start is called before the first frame update
    Diary_piece thisItem;
    private List<Diary_piece> availablePieces = new List<Diary_piece>();
    private Dictionary<string, List<Diary_piece>> sortedPieces = new Dictionary<string, List<Diary_piece>>();
    private int itemsPerPage = 16;
    private List<Diary_piece> Red, Blu, Prp, Grn, Yel = new List<Diary_piece>();
    static public List<Diary_piece> pickedPieces = new List<Diary_piece>();
    static public List<Diary_piece> show = new List<Diary_piece>();

    int page, way = 0;
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
    void UpdateInventoryUI()
    {
        Debug.Log("Displaying page " + (page + 1) + " with " + show.Count + " items.");
    }
    public void NextPage()
    {
        // Check if the next page exists
        if ((page + 1) * itemsPerPage < pickedPieces.Count)
        {
            page++;
            ShowPieces();
        }
    }
    public void PreviousPage()
    {
        if (page > 0)
        {
            page--;
            ShowPieces();
        }
    }
    void addp()
    {
        thisItem = GetRandomPiece();
        if (thisItem != null)
        {
            SortPiece(thisItem);
            PieceManager.Instance.Add(thisItem);
        }
        else return;       
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
        if (sortedPieces.ContainsKey(key))sortedPieces[key].Add(piece);
        else Debug.LogWarning($"Piece '{piece.PieceName}' does not match any category!");
        piece.survival_state = "Alive";
    }
    void InitializePieceSorting()
    {
        sortedPieces["Red"] = new List<Diary_piece>();
        sortedPieces["Blu"] = new List<Diary_piece>();
        sortedPieces["Prp"] = new List<Diary_piece>();
        sortedPieces["Yel"] = new List<Diary_piece>();
        sortedPieces["Grn"] = new List<Diary_piece>();
    }
    void ShowPieces()
    {
        int startIndex = page * itemsPerPage;
        int endIndex = Mathf.Min(startIndex + itemsPerPage, pickedPieces.Count);
        switch (way)
        {
            case 0:
                show.Clear();
                PieceManager.Instance.PieceList.Clear();
                for (int i = startIndex; i < endIndex; i++)
                {
                    show.Add(pickedPieces[i]);
                    PieceManager.Instance.Add(pickedPieces[i]);
                }
                break;
            case 1:
                show = Red;
                break;
            case 2:
                show = Blu;
                break;
            case 3:
                show = Prp;
                break;
            case 4:
                show = Yel;
                break;
            case 5:
                show = Grn;
                break;
        }
        UpdateInventoryUI();
    }
}