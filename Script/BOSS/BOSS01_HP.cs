using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS01_HP : MonoBehaviour
{
    // public SpriteRenderer healthBarFill;
    float MaxHealth, minus;
    private Vector3 initialScale;
    public Boss_col control;
    public AudioSource hit_NPC;
    void Start()
    {
        MaxHealth = control.BOSS_HP_Max;
        // initialScale = healthBarFill.transform.localScale;
        // SetPivotToLeft(healthBarFill);
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float fillAmount = control.BOSS_HP_Max / MaxHealth;
        Vector3 newScale = initialScale;
        newScale.x = initialScale.x * fillAmount;
        // healthBarFill.transform.localScale = newScale;
    }

    public void TakeDamage(float damage, float NPC_DEF)
    {
        control.change_color_red();
        hit_NPC.Play();
        minus = (float)(damage * damage / (damage + NPC_DEF));
        if (minus < 5) minus = 5;
        control.BOSS_HP -= minus;
        control.BOSS_HP = Mathf.Clamp(control.BOSS_HP, 0, MaxHealth);
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        control.BOSS_HP += amount;
        control.BOSS_HP = Mathf.Clamp(control.BOSS_HP, 0, MaxHealth);
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
