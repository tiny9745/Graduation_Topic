using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_effect_03 : MonoBehaviour
{
    public NPC03_control control;
    public GameObject bomb_piano, bomb_point;
    int play_piano_atk = 0; float NPC_back = 10;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
    public void Skill()//skill_add
    {
        if (Skill_public_funtion.play_piano)
        {
            if (play_piano_atk <= Skill_public_funtion.P_time)
            {
                play_piano_atk++;
            }
            else
            {
                Instantiate(bomb_piano, bomb_point.transform.position, Quaternion.identity);
                play_piano_atk = 0;
            }
        }
    }
    public void play_piano_effect()
    {
        for (int i = 0; i < IconManager.Instance.IconList.Count; i++)
        {
            if (IconManager.Instance.IconList[i].iconID == 22)
            {
                play_piano_atk++;
                break;
            }
            else if (IconManager.Instance.IconList[i].iconID == 12)
            {
                control.change_color_red();
                control.NPC_HP -= 225;
                break;
            }
            else if (IconManager.Instance.IconList[i].iconID == 32)
            {
                if (control.NPC_HP < NPC_back) control.NPC_HP = 0;
                else{
                    Vector3 currentPosition = transform.position;
                    transform.position = currentPosition - NPC_back * Vector3.back;
                }
                play_piano_atk = 0;
                break;
            }
            else if (IconManager.Instance.IconList[i].iconID == 2)
            {
                control.stun = true;
                Invoke("Stun_end", 3);
                break;
            }
        }
        control.change_color_red();
    }
    void Stun_end()
    {
        control.stun = false;
    }
}
