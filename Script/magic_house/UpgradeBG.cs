using UnityEngine;
using UnityEngine.UI;

public class UpgradeBG : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {
        canvas.sortingOrder = -1000;
    }
}
