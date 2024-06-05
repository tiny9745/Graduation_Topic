using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ani_MC : MonoBehaviour
{
    public Animator animator;
    public GameObject playerPrefab;
    private MC_col MC_Ctrl;
    int Angle_sum = 270;
    private float startTime;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        MC_Ctrl = playerPrefab.GetComponent<MC_col>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(Input.GetKeyDown(KeyCode.J))
        {
            startTime = 0;
        }
        if (Input.GetKey(KeyCode.J)) 
        {
            if (startTime <= 0)
            {
                startTime = Time.time;
            }
            // 計算已過時間
            elapsedTime = Time.time - startTime;
            if (elapsedTime <= .75f)
            {
                if (Angle_sum == 45)
                {
                    animator.Play("MC_Att_BR01");
                    //animator.Play("MC_Att_BR02");
                }
                else if (Angle_sum == 315)
                {
                    animator.Play("MC_Att_FR01");
                    //animator.Play("MC_Att_FR02");
                }
                else if (Angle_sum == 225)
                {
                    animator.Play("MC_Att_FL01");
                    //animator.Play("MC_Att_FR02");
                }
                else if (Angle_sum == 135)
                {
                    animator.Play("MC_Att_BL01");
                    //animator.Play("MC_Att_BL02");
                }
                else if (Angle_sum == 270)
                {
                    animator.Play("MC_Att_FR01");
                }
                else if (Angle_sum == 90)
                {
                    animator.Play("MC_Att_BR01");
                    //animator.Play("MC_Att_BR02");
                }
                else if (Angle_sum == 180)
                {
                    animator.Play("MC_Att_FL01");
                    //animator.Play("MC_Att_FL02");
                }
                else if (Angle_sum == 0)
                {
                    animator.Play("MC_Att_FR01");
                    //animator.Play("MC_Att_FR02");
                }
            }
            if (elapsedTime > .75f && elapsedTime <= 1.5f)
            {
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
            if (elapsedTime > 1.5f && elapsedTime <= 2.25f)
            {
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
            else if ( elapsedTime > 2.25f)
            {
                startTime = 0;
            }
        }
        else
        {
            if (MC_Ctrl.verticalInput > 0 && MC_Ctrl.horizontalInput > 0)
            {
                animator.Play("MC_Walk_Back");
                Angle_sum = 45;
            }
            else if (MC_Ctrl.verticalInput > 0 && MC_Ctrl.horizontalInput < 0)
            {
                animator.Play("MC_Walk_Right");
                Angle_sum = 315;
            }
            else if (MC_Ctrl.verticalInput < 0 && MC_Ctrl.horizontalInput < 0)
            {
                animator.Play("MC_Walk_Front");
                Angle_sum = 225;
            }
            else if (MC_Ctrl.verticalInput < 0 && MC_Ctrl.horizontalInput > 0)
            {
                animator.Play("MC_Walk_Left");
                Angle_sum = 135;
            }
            else if (MC_Ctrl.verticalInput < 0)
            {
                animator.Play("MC_Walk_Front");
                Angle_sum = 270;
            }
            else if (MC_Ctrl.verticalInput > 0)
            {
                animator.Play("MC_Walk_Back");
                Angle_sum = 90;
            }
            else if (MC_Ctrl.horizontalInput > 0)
            {
                animator.Play("MC_Walk_Right");
                Angle_sum = 0;
            }
            else if (MC_Ctrl.horizontalInput < 0)
            {
                animator.Play("MC_Walk_Left");
                Angle_sum = 180;
            }
            else if(MC_Ctrl.horizontalInput == 0 && MC_Ctrl.horizontalInput == 0)
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
}
