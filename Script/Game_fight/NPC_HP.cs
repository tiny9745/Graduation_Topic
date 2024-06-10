using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_HP : MonoBehaviour
{
    public SpriteRenderer healthBarFill;
    public float maxHealth;
    private Vector3 initialScale;
    public NPC01_control control;

    void Start()
    {
        maxHealth = control.NPC_HP_Max;
        initialScale = healthBarFill.transform.localScale; // Store initial zoom
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float fillAmount = control.NPC_HP / maxHealth;
        Vector3 newScale = initialScale;
        newScale.x = initialScale.x * fillAmount;
        healthBarFill.transform.localScale = newScale;
    }

    // Make sure the health volume is between 0 and maximum health volume
    public void TakeDamage(float damage)
    {
        control.NPC_HP -= damage;
        control.NPC_HP = Mathf.Clamp(control.NPC_HP, 0, maxHealth); 
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        control.NPC_HP += amount;
        control.NPC_HP = Mathf.Clamp(control.NPC_HP, 0, maxHealth); 
        UpdateHealthBar();
    }
}
