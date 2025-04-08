using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_HP_04 : MonoBehaviour
{
    public SpriteRenderer healthBarFill;
    public float MaxHealth, minus;
    private Vector3 initialScale;
    public NPC04_control control;
    public AudioSource hit_NPC;
    void Start()
    {
        MaxHealth = control.NPC_HP_Max;
        initialScale = healthBarFill.transform.localScale;
        SetPivotToLeft(healthBarFill);
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float fillAmount = control.NPC_HP / MaxHealth;
        Vector3 newScale = initialScale;
        newScale.x = initialScale.x * fillAmount;
        healthBarFill.transform.localScale = newScale;
    }

    public void TakeDamage(float damage, float NPC_DEF)
    {
        hit_NPC.Play();
        control.change_color_red();
        minus = (float)(damage * damage / (damage + NPC_DEF));
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
