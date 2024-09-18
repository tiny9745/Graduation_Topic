using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_HP : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth, minus;
    public Dummy_ctrl control;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage, float NPC_DEF)
    {
        minus = (float)(damage * damage / (damage + NPC_DEF));
        if (minus < 5) minus = 5;
        control.NPC_HP -= minus;
        control.NPC_HP = Mathf.Clamp(control.NPC_HP, 0, MaxHealth);
        //UpdateHealthBar();
    }
}
