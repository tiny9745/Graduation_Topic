using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Change_mood : MonoBehaviour
{
    public Image Mood;
    public Sprite wow, sad, happy, angry, normal;
    public int mood=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Change(){
        MoodChange(Skill_public_funtion.WOW,Skill_public_funtion.SAD,Skill_public_funtion.HAPPY,Skill_public_funtion.ANGRY);
        switch (mood)
        {
            case 0:
                Mood.sprite = normal;
                break;
            case 1:
                Mood.sprite = wow;
                break;
            case 2:
                Mood.sprite = sad;
                break;
            case 3:
                Mood.sprite = happy;
                break;
            case 4:
                Mood.sprite = angry;
                break;
            default:
                Mood.sprite = normal;
                break;
        }
    }

    void MoodChange(int WOW, int SAD, int HAPPY, int ANGRY){
        if(WOW > SAD && WOW > HAPPY && WOW > ANGRY){
            mood=1;
        }else if(SAD > WOW && SAD > HAPPY && SAD > ANGRY){
            mood=2;
        }else if(HAPPY > WOW && HAPPY > SAD && HAPPY > ANGRY){
            mood=3;
        }else if(ANGRY > WOW && ANGRY > SAD && ANGRY > HAPPY){
            mood=4;
        }else{
            mood=0;
        }
    }
}
