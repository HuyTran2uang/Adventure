using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyController
{
    public int Damage;
    public float Cooldown;
    public float SpeedAttack;
    public float ScopeAttack;
    //
    private bool isAttacking;
    //init point attack
    [SerializeField] private Transform pointAttack;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float areaDamage;
    //
    private float time;

    private void Start()
    {
        LoadInformation();
    }

    private void Reset()
    {
        LoadInformation();
    }

    private void LoadInformation()
    {
        pointAttack = transform.Find("PointAttack");
        enemyLayer = LayerMask.GetMask("Player");
        areaDamage = 0.57f;
    }

    private void Update()
    {
        Attack();
        ChangeAnimation();
    }

    private void FixedUpdate()
    {
        Timer();
    }

    private void Timer()
    {
        if (time <= 0) { time = 0; return; }
        time -= Time.deltaTime;
    }

    private void Attack()
    {
        if (!CheckScopeAttack()) return;
        if (isAttacking) return;
        if (time > 0) return;
        isAttacking = true;
        time = Cooldown;
        EnemyMovement.CheckAttacking(isAttacking);
        SendDamage(Damage);
        StartCoroutine(CompleteAttack(SpeedAttack));
    }

    private void SendDamage(int damage)
    {
        Collider2D[] players = Physics2D.OverlapCircleAll(pointAttack.position, areaDamage, enemyLayer);
        foreach (Collider2D player in players)
        {
            if (player.gameObject.layer == 7)
                PlayerController.Instance.PlayerHealth.TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointAttack.position, areaDamage);
    }

    public bool CheckScopeAttack()
    {
        if (Mathf.Abs(Target.position.x - transform.position.x) < ScopeAttack) return true;
        return false;
    }

    private IEnumerator CompleteAttack(float time)
    {
        yield return new WaitForSeconds(time);
        isAttacking = false;
        EnemyMovement.CheckAttacking(isAttacking);
    }

    private void ChangeAnimation()
    {
        if (!isAttacking) return;
        Animator.Play("Attack");
    }
}
