using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ani_MC : MonoBehaviour
{
    //stand 0 walk 1 melee attack 2~4
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
        switch (static_parameters.face)
        {
            case 0:
                break;
            case 1:
                Angle_sum = 0;
                break;
            case 2:
                Angle_sum = 45;
                break;
            case 3:
                Angle_sum = 90;
                break;
            case 4:
                Angle_sum = 135;
                break;
            case 5:
                Angle_sum = 180;
                break;
            case 6:
                Angle_sum = 225;
                break;
            case 7:
                Angle_sum = 270;
                break;
            case 8:
                Angle_sum = 315;
                break;
        }

        if (Input.GetKey(KeyCode.J))
        {
            if (startTime <= 0)
            {
                startTime = Time.time;
                static_parameters.Ani_state = 0;
            }
            elapsedTime = Time.time - startTime;
            if (elapsedTime <= 1f / static_parameters.MC_ATK_Speed)
            {
                static_parameters.Ani_state = 2;
            }
            else if (elapsedTime > 1f / static_parameters.MC_ATK_Speed && elapsedTime <= 2f / static_parameters.MC_ATK_Speed)
            {
                static_parameters.Ani_state = 3;
            }
            if (elapsedTime > 2f / static_parameters.MC_ATK_Speed && elapsedTime <= 3f / static_parameters.MC_ATK_Speed)
            {
                static_parameters.Ani_state = 4;
            }
            else if (elapsedTime > 2.25f / static_parameters.MC_ATK_Speed)
            {
                startTime = 0;
                static_parameters.Ani_state = 0;
            }
        }
        else
        {
            if (static_parameters.face == 0){
                static_parameters.Ani_state = 0;
            }else{
                static_parameters.Ani_state = 1;
            }
        }
        MC_ani_state();
    }
    void MC_ani_state()
    {
        switch (static_parameters.Ani_state)
        {
            case 0://stand
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_Stand_Right");
                        break;
                    case 45:
                        animator.Play("MC_Stand_Back");
                        break;
                    case 90:
                        animator.Play("MC_Stand_Back");
                        break;
                    case 135:
                        animator.Play("MC_Stand_Left");
                        break;
                    case 180:
                        animator.Play("MC_Stand_Left");
                        break;
                    case 225:
                        animator.Play("MC_Stand_Front");
                        break;
                    case 270:
                        animator.Play("MC_Stand_Front");
                        break;
                    case 315:
                        animator.Play("MC_Stand_Right");
                        break;
                }
                break;
            case 1://walk
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_Walk_Right");
                        break;
                    case 45:
                        animator.Play("MC_Walk_Back");
                        break;
                    case 90:
                        animator.Play("MC_Walk_Back");
                        break;
                    case 135:
                        animator.Play("MC_Walk_Left");
                        break;
                    case 180:
                        animator.Play("MC_Walk_Left");
                        break;
                    case 225:
                        animator.Play("MC_Walk_Front");
                        break;
                    case 270:
                        animator.Play("MC_Walk_Front");
                        break;
                    case 315:
                        animator.Play("MC_Walk_Right");
                        break;
                }
                break;
            case 2:
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_Att_FR01");
                        break;
                    case 45:
                        animator.Play("MC_Att_BR01");
                        break;
                    case 90:
                        animator.Play("MC_Att_BR01");
                        break;
                    case 135:
                        animator.Play("MC_Att_BL01");
                        break;
                    case 180:
                        animator.Play("MC_Att_FL01");
                        break;
                    case 225:
                        animator.Play("MC_Att_FL01");
                        break;
                    case 270:
                        animator.Play("MC_Att_FR01");
                        break;
                    case 315:
                        animator.Play("MC_Att_FR01");
                        break;
                }
                break;
            case 3:
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_Att_FR02");
                        break;
                    case 45:
                        animator.Play("MC_Att_BR02");
                        break;
                    case 90:
                        animator.Play("MC_Att_BR02");
                        break;
                    case 135:
                        animator.Play("MC_Att_BL02");
                        break;
                    case 180:
                        animator.Play("MC_Att_FL02");
                        break;
                    case 225:
                        animator.Play("MC_Att_FL02");
                        break;
                    case 270:
                        animator.Play("MC_Att_FR02");
                        break;
                    case 315:
                        animator.Play("MC_Att_FR02");
                        break;
                }
                break;
            case 4:
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_Att_FR03");
                        break;
                    case 45:
                        animator.Play("MC_Att_BR03");
                        break;
                    case 90:
                        animator.Play("MC_Att_BR03");
                        break;
                    case 135:
                        animator.Play("MC_Att_BL03");
                        break;
                    case 180:
                        animator.Play("MC_Att_FL03");
                        break;
                    case 225:
                        animator.Play("MC_Att_FL03");
                        break;
                    case 270:
                        animator.Play("MC_Att_FR03");
                        break;
                    case 315:
                        animator.Play("MC_Att_FR03");
                        break;
                }
                break;
            case 5:

                break;
        }
    }
}
