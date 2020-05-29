using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : CharacterStats
{
    public Image healthbar;
    public GameObject healthbarFrame;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        healthbar.fillAmount = currentHealth / maxHealth;
    }

    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }


}
