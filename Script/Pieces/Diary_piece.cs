using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PieceSystem/Piece")]
public class Diary_piece : ScriptableObject
{
    public int PieceID;
    public string PieceName;
    public Sprite PieceImage;
    public string survival_state = "Dead";
}
