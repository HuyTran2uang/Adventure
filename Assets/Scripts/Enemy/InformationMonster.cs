using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationMonster : EnemyController
{
    [SerializeField] private Base _base;
    [SerializeField] private int _level;
    public Enemy Enemy { get; private set; }

    private void Start()
    {
        SetupEnemy();
        SetupInformation();
    }

    private void SetupEnemy()
    {
        Enemy = new Enemy(_base, _level);
    }

    private void SetupInformation()
    {
        EnemyHealth.MaxHealth = Enemy.Health;
        EnemyHealth.CurrentHealth = EnemyHealth.MaxHealth;
        EnemyMovement.MoveSpeed = Enemy.MoveSpeed + Random.Range(-0.1f, 0.1f);
        EnemyAttack.Damage = Enemy.Attack;
        EnemyAttack.Cooldown = Enemy.Cooldown;
        EnemyAttack.SpeedAttack = Enemy.SpeedAttack + Random.Range(-0.1f, 0.1f);
        EnemyAttack.ScopeAttack = Enemy.ScopeAttack;
    }
}
