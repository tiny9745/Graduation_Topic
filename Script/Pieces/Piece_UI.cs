using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public Pieceslot[] Pieceslot1, Pieceslot2, Pieceslot3, Pieceslot4;
    public Transform Pieceslot1Point, Pieceslot2Point, Pieceslot3Point, Pieceslot4Point;
    public UI UI;
    void Start()
    {
        PieceManager.Instance.PieceInventoryCallBack += UpdatePiece;
        Pieceslot1 = Pieceslot1Point.GetComponentsInChildren<Pieceslot>();
        Pieceslot2 = Pieceslot2Point.GetComponentsInChildren<Pieceslot>();
        Pieceslot3 = Pieceslot3Point.GetComponentsInChildren<Pieceslot>();
        Pieceslot4 = Pieceslot4Point.GetComponentsInChildren<Pieceslot>();
    }

    // Update is called once per frame
    public void UpdatePiece()
    {
        switch (UI.Diarystatus)
        {
            case 1://chapter1
                for (int i = 0; i < Pieceslot1.Length; i++)//first page
                {
                    if (i < PieceManager.Instance.PieceList.Count)
                    {
                        Pieceslot1[i].AddPiece(PieceManager.Instance.PieceList[i]);
                    }
                    else
                    {
                        Pieceslot1[i].Clean();
                    }
                }
                for (int i = 0; i < Pieceslot3.Length; i++)//second page
                {
                    if (i < PieceManager.Instance.PieceList.Count)
                    {
                        Pieceslot3[i].AddPiece(PieceManager.Instance.PieceList[i]);
                    }
                    else
                    {
                        Pieceslot3[i].Clean();
                    }
                }
                if (PieceManager.Instance.PieceList.Count > 44)
                {
                    for (int i = 44; i < Pieceslot4.Length; i++)
                    {
                        if (i < PieceManager.Instance.PieceList.Count)
                        {
                            Pieceslot4[i].AddPiece(PieceManager.Instance.PieceList[i]);
                        }
                        else
                        {
                            Pieceslot4[i].Clean();
                        }
                    }
                }
                break;
            case 2://chapter2
                for (int i = 0; i < Pieceslot2.Length; i++)
                {
                    if (i < PieceManager.Instance.PieceList.Count)
                    {
                        Pieceslot2[i].AddPiece(PieceManager.Instance.PieceList[i]);
                    }
                    else
                    {
                        Pieceslot2[i].Clean();
                    }
                }
                break;
        }
    }
}

