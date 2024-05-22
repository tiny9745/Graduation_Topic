using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani_MC : MonoBehaviour
{
    public Animator animator;
    public GameObject playerPrefab;
    private MC_col MC_Ctrl;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        MC_Ctrl = playerPrefab.GetComponent<MC_col>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MC_Ctrl.horizontalInput != 0 || MC_Ctrl.verticalInput != 0)
        {
            animator.SetBool("Walking", true);

            if (MC_Ctrl.horizontalInput > 0)
            {
                animator.SetBool("Right", true);
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Left", false);
            }
            else if (MC_Ctrl.horizontalInput < 0)
            {
                animator.SetBool("Left", true);
                animator.SetBool("Front", false);
                animator.SetBool("Right", false);
                animator.SetBool("Back", false);
            }
            if (MC_Ctrl.verticalInput < 0)
            {
                animator.SetBool("Front", true);
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
                animator.SetBool("Back", false);
            }
            else if (MC_Ctrl.verticalInput > 0)
            {
                animator.SetBool("Back", true);
                animator.SetBool("Front", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }

    }
}
