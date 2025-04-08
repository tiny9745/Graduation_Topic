using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Change_mood : MonoBehaviour
{
    public Image Mood, Health, B1, B2, B3, B4;
    public Sprite wow, sad, happy, angry, normal,pain, bwow, bsad, bhappy, bangry, bnormal, bpain;
    static public int mood = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Change()
    {
        MoodChange(Skill_public_funtion.WOW, Skill_public_funtion.SAD, Skill_public_funtion.HAPPY, Skill_public_funtion.ANGRY, Skill_public_funtion.PAIN);
        switch (mood)
        {
            case 0:
                Mood.sprite = wow; Health.color = new Color(0.63f, 0.98f, 0.86f, 1);
                B1.sprite = bwow; B2.sprite = bwow; B3.sprite = bwow; B4.sprite = bwow;
                break;
            case 1:
                Mood.sprite = angry; Health.color = new Color(0.98f, 0.62f, 0.63f, 1);
                B1.sprite = bangry; B2.sprite = bangry; B3.sprite = bangry; B4.sprite = bangry;
                break;
            case 2:
                Mood.sprite = sad; Health.color = new Color(0.61f, 0.8f, 1, 1);
                B1.sprite = bsad; B2.sprite = bsad; B3.sprite = bsad; B4.sprite = bsad;
                break;
            case 3:
                Mood.sprite = pain; Health.color = new Color(0.84f, 0.62f, 0.88f, 1);
                B1.sprite = bpain; B2.sprite = bpain; B3.sprite = bpain; B4.sprite = bpain;
                break;
            case 4:
                Mood.sprite = happy; Health.color = new Color(1, 0.93f, 0.59f, 1);
                B1.sprite = bhappy; B2.sprite = bhappy; B3.sprite = bhappy; B4.sprite = bhappy;
                break;
            default:
                Mood.sprite = normal; Health.color = new Color(0.95f, 0.88f, 0.89f, 1);
                B1.sprite = bnormal; B2.sprite = bnormal; B3.sprite = bnormal; B4.sprite = bnormal;
                break;
        }
    }

    void MoodChange(int WOW, int SAD, int HAPPY, int ANGRY, int PAIN)
    {
        if (WOW > SAD && WOW > HAPPY && WOW > ANGRY && WOW > PAIN)
        {
            mood = 0;
        }
        else if (SAD > WOW && SAD > HAPPY && SAD > ANGRY && SAD > PAIN)
        {
            mood = 2;
        }
        else if (HAPPY > WOW && HAPPY > SAD && HAPPY > ANGRY && HAPPY > PAIN)
        {
            mood = 4;
        }
        else if (ANGRY > WOW && ANGRY > SAD && ANGRY > HAPPY && ANGRY > PAIN)
        {
            mood = 1;
        }
        else if (PAIN > WOW && PAIN > SAD && PAIN > HAPPY && PAIN > ANGRY)
        {
            mood = 3;
        }
        else
        {
            if (WOW > 0)
            {
                mood = 0; return;
            }
            else if (SAD > 0)
            {
                mood = 2; return;
            }
            else if (HAPPY > 0)
            {
                mood = 4; return;
            }
            else if (ANGRY > 0)
            {
                mood = 1; return;
            }
            else if (PAIN > 0)
            {
                mood = 3; return;
            }
            else mood = 5;
        }
    }
}
