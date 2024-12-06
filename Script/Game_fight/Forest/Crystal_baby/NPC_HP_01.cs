using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_HP_01 : MonoBehaviour
{
    public SpriteRenderer healthBarFill;
    public float MaxHealth;float minus;
    private Vector3 initialScale;
    public NPC01_control control;

    void Start()
    {
        MaxHealth = control.NPC_HP_Max;
        initialScale = healthBarFill.transform.localScale; // Store initial scale
        SetPivotToLeft(healthBarFill); // Set the pivot to the left
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float fillAmount = control.NPC_HP / MaxHealth;
        Vector3 newScale = initialScale;
        newScale.x = initialScale.x * fillAmount;
        healthBarFill.transform.localScale = newScale;
    }
    // Ensure health is between 0 and maximum health
    public void TakeDamage(float damage,float NPC_DEF)
    {
        minus = (float)(damage*damage/(damage+NPC_DEF));
        if (minus < 5) minus = 5;
        control.NPC_HP -= minus;
        control.NPC_HP = Mathf.Clamp(control.NPC_HP, 0, MaxHealth);
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        control.NPC_HP += amount;
        control.NPC_HP = Mathf.Clamp(control.NPC_HP, 0, MaxHealth);
        UpdateHealthBar();
    }

    void SetPivotToLeft(SpriteRenderer spriteRenderer)
    {
        Sprite sprite = spriteRenderer.sprite;
        Rect rect = sprite.rect;
        Vector2 pivot = new Vector2(0, sprite.pivot.y / rect.height);
        Sprite newSprite = Sprite.Create(sprite.texture, rect, pivot, sprite.pixelsPerUnit);
        spriteRenderer.sprite = newSprite;      
    }
}
