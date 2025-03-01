using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class C2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image cancel_img;
    public Sprite cancel_on, cancel_off;
    public void OnPointerDown(PointerEventData eventData)
    {
        cancel_img.sprite = cancel_on; // Change the button image to image2 when button is pressed
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        cancel_img.sprite = cancel_off; // Change the button image back to image1 when button is released
    }
}
