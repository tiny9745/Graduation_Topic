using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pieceslot : MonoBehaviour
{
    Diary_piece piece;
    public Image PieceImage;
    public Sprite emptySprite;
    
    public void AddPiece(Diary_piece thisItem)
    {
        piece = thisItem;
        PieceImage.sprite = piece.PieceImage;
        Color color = PieceImage.color;
        color.a = 1f;
        PieceImage.color = color;
    }
    public void RemoveItem()
    {
        Color color = PieceImage.color;
        color.a = 0f;
        PieceManager.Instance.Remove(piece);
        PieceManager.Instance.PieceInventoryCallBack();
    }
    public void Clean()
    {
        piece = null;
        PieceImage.sprite = emptySprite;
    }
    
}