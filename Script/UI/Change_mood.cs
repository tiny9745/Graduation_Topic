using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public void Change(string mood){

        //MoodChange(WOW, SAD, HAPPY, ANGRY, NORMAL);
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
