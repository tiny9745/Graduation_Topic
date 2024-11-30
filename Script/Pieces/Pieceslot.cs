using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pieceslot : MonoBehaviour
{
    Diary_piece piece;
    public Image PieceImage;
    
    public void AddPiece(Diary_piece thisItem)
    {
        piece = thisItem;
        PieceImage.sprite = piece.PieceImage;
    }
    public void Clean()
    {
        piece = null;
        PieceImage.sprite = null;
    }
    
}