using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCText : MonoBehaviour
{
    // Start is called before the first frame update
    private Text textComponent;
    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (static_parameters.Bookstate == false) return;
        if (static_parameters.fragmentsnumber_hold >= 36) static_parameters.fragmentsnumber_hold = 36;
        if (static_parameters.diary_number >= 25) static_parameters.diary_number = 25;
        textComponent.text =
        "生命值：" + static_parameters.MC_HP_Max.ToString() +
        "\r\n攻擊力：" + static_parameters.MC_ATK.ToString() +
        "\r\n擁有的碎片：" + static_parameters.fragmentsnumber_hold.ToString() +
        "/36\r\n擁有的日記：" + static_parameters.diary_number.ToString() +
        "/25\r\n擁有的彈珠：" + static_parameters.money.ToString();
    }
}
