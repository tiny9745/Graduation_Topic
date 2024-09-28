using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_mood : MonoBehaviour
{
    public Image Mood;
    public Sprite wow, sad, happy, angry, normal;
    int WOW, SAD, HAPPY, ANGRY, NORMAL = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Change(string mood){
        WOW = mood.Split('W').Length - 1;
        SAD = mood.Split('S').Length - 1;
        HAPPY = mood.Split('H').Length - 1;
        ANGRY = mood.Split('A').Length - 1;
        NORMAL = mood.Split('N').Length - 1;
        if(mood=="wow") Mood.sprite = wow;
        if(mood=="sad") Mood.sprite = sad;
        if(mood=="happy") Mood.sprite = happy;
        if(mood=="angry") Mood.sprite = angry;
        if(mood=="normal") Mood.sprite = normal;
    }

    public void Change(int mood){
        if(mood==0) Mood.sprite = happy;
        if(mood==1) Mood.sprite = angry;
        if(mood==2) Mood.sprite = sad;
        if(mood==3) Mood.sprite = wow;
    }
}
