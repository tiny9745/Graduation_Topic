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
        initialScale = healthBarFill.transform.localScale; // 存储初始缩放
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float fillAmount = control.NPC_HP / maxHealth; // 计算填充比例
        Vector3 newScale = initialScale;
        newScale.x = initialScale.x * fillAmount; // 调整x轴的缩放
        healthBarFill.transform.localScale = newScale; // 更新填充图像的缩放
    }

    public void TakeDamage(float damage)
    {
        control.NPC_HP -= damage;
        control.NPC_HP = Mathf.Clamp(control.NPC_HP, 0, maxHealth); // 确保血量在0到最大血量之间
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        control.NPC_HP += amount;
        control.NPC_HP = Mathf.Clamp(control.NPC_HP, 0, maxHealth); // 确保血量在0到最大血量之间
        UpdateHealthBar();
    }
}
