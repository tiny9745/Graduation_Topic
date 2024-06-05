using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani_MC : MonoBehaviour
{
    public Animator animator;
    public GameObject playerPrefab;
    private MC_col MC_Ctrl;
    int Angle_sum = 270;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        MC_Ctrl = playerPrefab.GetComponent<MC_col>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {

        }
        else
        {
            if (MC_Ctrl.verticalInput > 0 && MC_Ctrl.horizontalInput > 0)
            {
                Angle_sum = 45;
            }
            else if (MC_Ctrl.verticalInput > 0 && MC_Ctrl.horizontalInput < 0)
            {
                Angle_sum = 315;
            }
            else if (MC_Ctrl.verticalInput < 0 && MC_Ctrl.horizontalInput < 0)
            {
                Angle_sum = 225;
            }
            else if (MC_Ctrl.verticalInput < 0 && MC_Ctrl.horizontalInput > 0)
            {
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

                }
                else if (Angle_sum == 315)
                {

                }
                else if (Angle_sum == 225)
                {

                }
                else if (Angle_sum == 135)
                {

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
