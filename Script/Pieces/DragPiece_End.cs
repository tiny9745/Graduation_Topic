using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;


public class DragPiece_End : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private List<Diary_piece> fragments_tmp = new List<Diary_piece>();

    // Update is called once per frame
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {
            if (int.TryParse(droppedObject.name, out int itemNumber))
            {
                PieceManager.Instance.Remove(Ptest.pickedPieces[itemNumber - 1]);
                string key_color = Ptest.pickedPieces[itemNumber - 1].PieceName.Substring(0, 3);
                Ptest.pickedPieces[itemNumber - 1].survival_state = "dead";
                Debug.Log("survival_state:" + key_color + " is " + Ptest.pickedPieces[itemNumber - 1].survival_state);
                if (key_color == "Red")
                {
                    Debug.Log("Red");
                }
                else if (key_color == "Blu")
                {
                    Debug.Log("Blue");
                }
                else if (key_color == "Prp")
                {
                    Debug.Log("Purple");
                }
                else if (key_color == "Yel")
                {
                    Debug.Log("Yellow");
                }
                else if (key_color == "Grn")
                {
                    Debug.Log("Green");
                }
                Ptest.pickedPieces.RemoveAt(itemNumber - 1);
            }
        }
    }
}
