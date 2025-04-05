using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    private UI _UI;
    private Ptest ptest;
    GameObject targetObject;
    Animator Chest_Animator;
    int randomIndex;
    bool isAni = false;
    void Start()
    {
        randomIndex = Random.Range(5, 9);
        targetObject = GameObject.Find("UI");

        if (targetObject != null)
        {
            ptest = targetObject.GetComponent<Ptest>();
            if (ptest == null)
            {
                Debug.LogWarning("Ptest component not found on UI!");
            }
        }
        else
        {
            Debug.LogWarning("UI not found in the scene!");
        }
        _UI = targetObject.GetComponent<UI>();
        Chest_Animator = GetComponent<Animator>();
        Chest_Animator.SetTrigger($"chest{randomIndex}");
    }

    private void Update()
    {
        StartCoroutine(Aniwait());
    }

    private IEnumerator Aniwait()
    {
        yield return new WaitUntil(() =>
        {
            AnimatorStateInfo stateInfo = Chest_Animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.IsName($"chest{randomIndex}") && stateInfo.normalizedTime >= 0.75f;
        });
        if (targetObject != null && isAni == false)
        {
            isAni = true;
            if (static_parameters.teaching_stop <= 6) static_parameters.teaching_stop = 7;
            ptest._to_Drop(randomIndex);
            static_parameters.money += Random.Range(25, 41);
            _UI.Loadmoney();
            Debug.Log("randomIndex: " + randomIndex + " money: " + static_parameters.money);
        }
        yield return new WaitForSeconds(0.65f);
        Destroy(gameObject);
    }
}
