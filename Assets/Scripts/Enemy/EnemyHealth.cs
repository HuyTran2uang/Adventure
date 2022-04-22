using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    public void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0) { CurrentHealth = 0; return; }
        CurrentHealth -= damage;
    }

    private void Die()
    {
        if (CurrentHealth > 0) return;
        Debug.Log(gameObject.name + "Die");
    }
}
