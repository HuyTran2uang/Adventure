using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private void Start()
    {
        LoadInforation();
    }

    private void Reset()
    {
        LoadInforation();
    }

    private void LoadInforation()
    {
        MaxHealth = 1000;
        CurrentHealth = MaxHealth;
    }

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
