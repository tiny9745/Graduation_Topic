using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_HP : MonoBehaviour
{
    public SpriteRenderer healthBarFill;
    public float MaxHealth, minus;
    private Vector3 initialScale;
    public Dummy_ctrl control;

    void Start()
    {
        MaxHealth = control.NPC_HP_Max;
        initialScale = healthBarFill.transform.localScale;
        SetPivotToLeft(healthBarFill);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float fillAmount = control.NPC_HP / MaxHealth;
        Vector3 newScale = initialScale;
        newScale.x = initialScale.x * fillAmount;
        healthBarFill.transform.localScale = newScale;
    }

    public void TakeDamage(float damage, float NPC_DEF)
    {
        minus = (float)(damage * damage / (damage + NPC_DEF));
        if (minus < 5) minus = 5;
        control.NPC_HP -= minus;
        control.NPC_HP = Mathf.Clamp(control.NPC_HP, 0, MaxHealth);
        Skill_public_funtion.blood_deduction_NPC_count += minus;//skill_add
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
