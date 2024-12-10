using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragPiece_End : MonoBehaviour,IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void OnDrop (PointerEventData eventData){
        GameObject droppedObject = eventData.pointerDrag;
        Debug.Log(droppedObject);
        if (droppedObject != null)
        {
           if (int.TryParse(droppedObject.name, out int itemNumber))
            {
                Debug.Log(itemNumber);
                Debug.Log(Ptest.pickedPieces[itemNumber-1]);
            }
        }
    }
}
