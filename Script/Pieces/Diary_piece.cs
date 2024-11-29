using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ItemSystem/Item")]
public class Diary_piece : MonoBehaviour
{
    public int PieceID;
    public string PieceName;
    public Sprite PieceImage;
    public virtual void UseItem()
    {
        static_parameters.Piece_ID = PieceID;
        Debug.Log("item.ItemID:" + PieceID);
    }
}
