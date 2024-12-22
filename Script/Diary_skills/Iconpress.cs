using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iconpress : MonoBehaviour
{
    public GameObject number;
    public static int itemNumber;
    public void Press()
    {
        int.TryParse(number.name, out itemNumber);
    }
}
