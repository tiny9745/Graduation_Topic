using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_mood : MonoBehaviour
{
    public Image Mood;
    public Sprite wow, sad, happy, angry, normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Change("sad");
    }
    public void Change(string mood){
        if(mood=="wow") Mood.sprite = wow;
        if(mood=="sad") Mood.sprite = sad;
        if(mood=="happy") Mood.sprite = happy;
        if(mood=="angry") Mood.sprite = angry;
        if(mood=="normal") Mood.sprite = normal;
    }
}
