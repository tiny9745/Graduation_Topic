using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class C1 :  MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image comfirm_img;
    public Sprite comfirm_on, comfirm_off;
    public void OnPointerDown(PointerEventData eventData)
    {
        comfirm_img.sprite = comfirm_on; // Change the button image to image2 when button is pressed
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        comfirm_img.sprite = comfirm_off; // Change the button image back to image1 when button is released
    }
}
