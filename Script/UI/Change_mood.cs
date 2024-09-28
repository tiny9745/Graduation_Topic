using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        MoodChange(WOW, SAD, HAPPY, ANGRY, NORMAL);
    }

    void MoodChange(int WOW, int SAD, int HAPPY, int ANGRY, int NORMAL){
        if(WOW > SAD && WOW > HAPPY && WOW > ANGRY){
            Mood.sprite = wow;
        }else if(SAD > WOW && SAD > HAPPY && SAD > ANGRY){
            Mood.sprite = sad;
        }else if(HAPPY > WOW && HAPPY > SAD && HAPPY > ANGRY){
            Mood.sprite = happy;
        }else if(ANGRY > WOW && ANGRY > SAD && ANGRY > HAPPY){
            Mood.sprite = angry;
        }else{
            Mood.sprite = normal;
        }
    }
}
