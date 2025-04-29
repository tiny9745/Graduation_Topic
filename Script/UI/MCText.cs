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
        textComponent.text = "生命值：" + "攻擊力：+" + "擁有的碎片：" + "擁有的日記：" + "擁有的彈珠：";
    }
}
