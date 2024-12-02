using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Pieceslot[] Pieceslot;
    public Transform PieceslotPoint;
    void Start()
    {
        PieceManager.Instance.PieceInventoryCallBack += UpdatePiece;
        Pieceslot = PieceslotPoint.GetComponentsInChildren<Pieceslot>();
    }

    // Update is called once per frame
    public void UpdatePiece()
    {
        Debug.Log("UpdatePiece");
        for (int i = 0; i < Pieceslot.Length; i++)
        {
            if (i < PieceManager.Instance.PieceList.Count)
            {
                Pieceslot[i].AddPiece(PieceManager.Instance.PieceList[i]);
            }
            else
            {
                Pieceslot[i].Clean();
            }
        }
    }
}

