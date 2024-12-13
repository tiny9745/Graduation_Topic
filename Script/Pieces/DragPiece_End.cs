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
                Ptest.pickedPieces[itemNumber - 1].survival_state = "Drag";

                Ptest.pickedPieces.RemoveAt(itemNumber - 1);
                for (int i = 0; i < Ptest.pickedPieces.Count; i++)
                {
                    if (key_color != Ptest.pickedPieces[i].PieceName.Substring(0, 3))
                    {
                        Ptest.pickedPieces[i].survival_state = "Remove";
                        PieceManager.Instance.Remove(Ptest.pickedPieces[i]);
                        Debug.Log("PieceName:" + Ptest.pickedPieces[i].PieceName + ",Survival_State:" + Ptest.pickedPieces[i].survival_state);
                    }
                }
            }
        }
    }
}
