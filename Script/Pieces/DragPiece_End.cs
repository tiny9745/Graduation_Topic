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
        Debug.Log("OnDrop");
    }
}
