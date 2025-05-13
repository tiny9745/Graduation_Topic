using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_ground : MonoBehaviour
{
    // Start is called before the first frame update
    public Boss_col boss_col;
    private Animator animator;
    private Collider this_collider;
    bool isGrounded = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        this_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            isGrounded = false;
            Debug.Log("BOSS_in_open_time:" + boss_col.BOSS_in_open_time);
            animator.SetTrigger("open_ground");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        boss_col.BOSS_live = true;
        boss_col.BOSS_in_open_time = true;
        isGrounded = true;
        this_collider.enabled = false;
    }
}
