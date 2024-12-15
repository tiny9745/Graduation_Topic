using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PieceManager Instance;
    public Piece_UI Piece_UI;
    public List<Diary_piece> PieceList;
    public delegate void PieceInventoryChange();
    public PieceInventoryChange PieceInventoryCallBack;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        PieceInventoryCallBack?.Invoke();
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
     public void Add(Diary_piece newPiece)
    { 
        PieceList.Add(newPiece);
        PieceInventoryCallBack?.Invoke();
    }

    public void Remove(Diary_piece oldPiece)
    {
        PieceList.Remove(oldPiece);
        PieceInventoryCallBack?.Invoke();
    }
    public void Clear()
    {
        PieceList.Clear();
        PieceInventoryCallBack?.Invoke();
    }
    public void Refresh()
    {
        PieceInventoryCallBack?.Invoke();
    }
}
