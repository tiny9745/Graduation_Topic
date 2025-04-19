using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiangMi : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator JM_animator;
    void Start()
    {
        Invoke("JM_atk", 2.5f);
    }

    private void JM_atk()
    {
        JM_animator.SetInteger("JM", 1);
        Invoke("wait", 1.5f);
    }

    private void wait()
    {
        static_parameters.teaching_stop = 3;
    }

    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("MC_Att"))
        {
            JM_animator.SetInteger("JM", 2);
            Invoke("Dead_wait", 4f);
        }
    }
    private void Dead_wait()
    {
        static_parameters.teaching_stop = 4;
        Destroy(gameObject);
    }
}
