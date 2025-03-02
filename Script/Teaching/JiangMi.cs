using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiangMi : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator JM_animator;
    void Start()
    {
        Invoke("JM_atk", .5f);
    }

    // Update is called once per frame
    void Update()
    {

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
            Destroy(gameObject, 3f);
        }
    }
}
