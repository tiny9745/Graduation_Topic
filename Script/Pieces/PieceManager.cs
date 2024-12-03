using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PieceManager Instance;
    public Pieceslot Slot;
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
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
     public void Add(Diary_piece newPiece)
    { 
        Debug.Log(newPiece);
        PieceList.Add(newPiece);

        PieceInventoryCallBack?.Invoke();
    }

    public void Remove(Diary_piece oldPiece)
    {
        PieceList.Remove(oldPiece);
        PieceInventoryCallBack?.Invoke();
    }
}
