using UnityEngine;
using UnityEngine.EventSystems;
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
                Debug.Log("Dropped object is: " + itemNumber);
                print(Ptest.pickedPieces[itemNumber - 1].PieceName);
                PieceManager.Instance.Remove(Ptest.pickedPieces[itemNumber - 1]);
                string key_color = Ptest.pickedPieces[itemNumber - 1].PieceName.Substring(0, 3);
                if (key_color == "Red")
                {
                    Debug.Log("Red");
                }
                else if (key_color == "Blu")
                {
                    Debug.Log("Blue");
                }
                else if (key_color == "Pur")
                {
                    Debug.Log("Purple");
                }
                else if (key_color == "Yel")
                {
                    Debug.Log("Yellow");
                }
                else if (key_color == "Gre")
                {
                    Debug.Log("Green");
                }
            }
        }
    }
}
