using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ani_MC : MonoBehaviour
{
    public Animator animator;
    public GameObject playerPrefab;
    private Play_move MC_move;
    int Angle_sum = 270;
    private float startTime; private float elapsedTime;
    public GameObject Play_s;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        MC_move = playerPrefab.GetComponent<Play_move>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Play_s.transform.position.x, transform.position.y, Play_s.transform.position.z);
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.J))
        {
            startTime = 0;
        }
        if (Input.GetKey(KeyCode.J))
        {
            if (startTime <= 0)
            {
                startTime = Time.time;
                static_parameters.Attactstate = 0;
            }

            elapsedTime = Time.time - startTime;
            if (elapsedTime <= 1f / static_parameters.MC_ATK_Speed)
            {
                static_parameters.Attactstate=1;
                if (Angle_sum == 45)
                {
                    animator.Play("MC_Att_BR01");
                }
                else if (Angle_sum == 315)
                {
                    animator.Play("MC_Att_FR01");
                }
                else if (Angle_sum == 225)
                {
                    animator.Play("MC_Att_FL01");
                }
                else if (Angle_sum == 135)
                {
                    animator.Play("MC_Att_BL01");
                }
                else if (Angle_sum == 270)
                {
                    animator.Play("MC_Att_FR01");
                }
                else if (Angle_sum == 90)
                {
                    animator.Play("MC_Att_BR01");
                }
                else if (Angle_sum == 180)
                {
                    animator.Play("MC_Att_FL01");
                }
                else if (Angle_sum == 0)
                {
                    animator.Play("MC_Att_FR01");
                }
            }
            if (elapsedTime > 1f / static_parameters.MC_ATK_Speed && elapsedTime <= 2f / static_parameters.MC_ATK_Speed)
            {
                static_parameters.Attactstate=2;
                if (Angle_sum == 45)
                {
                    animator.Play("MC_Att_BR02");
                }
                else if (Angle_sum == 315)
                {
                    animator.Play("MC_Att_FR02");
                }
                else if (Angle_sum == 225)
                {
                    animator.Play("MC_Att_FR02");
                }
                else if (Angle_sum == 135)
                {
                    animator.Play("MC_Att_BL02");
                }
                else if (Angle_sum == 270)
                {
                    animator.Play("MC_Att_FR02");
                }
                else if (Angle_sum == 90)
                {
                    animator.Play("MC_Att_BR02");
                }
                else if (Angle_sum == 180)
                {
                    animator.Play("MC_Att_FL02");
                }
                else if (Angle_sum == 0)
                {
                    animator.Play("MC_Att_FR02");
                }
            }
            if (elapsedTime > 2f / static_parameters.MC_ATK_Speed && elapsedTime <= 3f / static_parameters.MC_ATK_Speed)
            {
                static_parameters.Attactstate=3;
                if (Angle_sum == 45)
                {
                    animator.Play("MC_Att_BR03");
                }
                else if (Angle_sum == 315)
                {
                    animator.Play("MC_Att_FR03");
                }
                else if (Angle_sum == 225)
                {
                    animator.Play("MC_Att_FR03");
                }
                else if (Angle_sum == 135)
                {
                    animator.Play("MC_Att_BL03");
                }
                else if (Angle_sum == 270)
                {
                    animator.Play("MC_Att_FR03");
                }
                else if (Angle_sum == 90)
                {
                    animator.Play("MC_Att_BR03");
                }
                else if (Angle_sum == 180)
                {
                    animator.Play("MC_Att_FL03");
                }
                else if (Angle_sum == 0)
                {
                    animator.Play("MC_Att_FR03");
                }
            }
            else if (elapsedTime > 2.25f / static_parameters.MC_ATK_Speed)
            {
                startTime = 0;
                static_parameters.Attactstate=0;
            }
        }
        else//verticalInput=垂直，horizontalInput=水平
        {
            if (MC_move.verticalInput > 0 && MC_move.horizontalInput > 0)
            {
                animator.Play("MC_Walk_Back");
                Angle_sum = 45;
            }
            else if (MC_move.verticalInput > 0 && MC_move.horizontalInput < 0)
            {
                animator.Play("MC_Walk_Left");
                Angle_sum = 135;
            }
            else if (MC_move.verticalInput < 0 && MC_move.horizontalInput < 0)
            {
                animator.Play("MC_Walk_Front");
                Angle_sum = 225;
            }
            else if (MC_move.verticalInput < 0 && MC_move.horizontalInput > 0)
            {
                animator.Play("MC_Walk_Right");
                Angle_sum = 315;
            }
            else if (MC_move.verticalInput < 0)
            {
                animator.Play("MC_Walk_Front");
                Angle_sum = 270;
            }
            else if (MC_move.verticalInput > 0)
            {
                animator.Play("MC_Walk_Back");
                Angle_sum = 90;
            }
            else if (MC_move.horizontalInput > 0)
            {
                animator.Play("MC_Walk_Right");
                Angle_sum = 0;
            }
            else if (MC_move.horizontalInput < 0)
            {
                animator.Play("MC_Walk_Left");
                Angle_sum = 180;
            }
            else if (MC_move.horizontalInput == 0 && MC_move.horizontalInput == 0)
            {
                if (Angle_sum == 45)
                {
                    animator.Play("MC_Stand_Front");
                }
                else if (Angle_sum == 315)
                {
                    animator.Play("MC_Stand_Right");
                }
                else if (Angle_sum == 225)
                {
                    animator.Play("MC_Stand_Front");
                }
                else if (Angle_sum == 135)
                {
                    animator.Play("MC_Stand_Left");
                }
                else if (Angle_sum == 270)
                {
                    animator.Play("MC_Stand_Front");
                }
                else if (Angle_sum == 90)
                {
                    animator.Play("MC_Stand_Back");
                }
                else if (Angle_sum == 180)
                {
                    animator.Play("MC_Stand_Left");
                }
                else if (Angle_sum == 0)
                {
                    animator.Play("MC_Stand_Right");
                }
            }
        }  
    }
    void MC_ani_state(){
        switch(static_parameters.Attactstate){
            case 0:
                animator.Play("MC_Stand_Front");
                break;
            case 1:
                animator.Play("MC_Att_FR01");
                break;
            case 2:
                animator.Play("MC_Att_FR02");
                break;
            case 3:
                animator.Play("MC_Att_FR03");
                break;
        }
    }
}
