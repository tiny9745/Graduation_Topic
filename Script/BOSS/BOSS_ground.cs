using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_ground : MonoBehaviour
{
    // Start is called before the first frame update
    public Boss_col boss_col;
    private Animator animator;
    bool isGrounded = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == false)
        {
            if (boss_col.BOSS_in_open_time < 6)
            {
                boss_col.BOSS_in_open_time += Time.deltaTime;
            }
            else
            {
                isGrounded = true;
                animator.SetTrigger("open_ground");
            }
        }
    }
}
