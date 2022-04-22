using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyController
{
    public float MoveSpeed;
    private Vector2 velocity;
    private Vector3 scale;
    private bool isAttacking;

    private void Start()
    {
        scale = transform.localScale;
    }

    private void Update()
    {
        MoveToTarget();
        Flip();
        ChangeAnimation();
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = velocity;
        transform.localScale = scale;
    }

    private void MoveToTarget()
    {
        if (ScopeAttack() || isAttacking) { velocity.x = 0; return; }
        velocity.x = scale.x * MoveSpeed;
    }

    private bool ScopeAttack()
    {
        return EnemyAttack.CheckScopeAttack();
    }

    public void CheckAttacking(bool statusAttack)
    {
        isAttacking = statusAttack;
    }

    private void Flip()
    {
        if (isAttacking) return;
        if (Target.position.x < transform.position.x) scale.x = -1;
        if (Target.position.x > transform.position.x) scale.x = 1;
    }

    private void ChangeAnimation()
    {
        if (isAttacking) return;
        if (velocity.x != 0) Animator.Play("Idle");
        else Animator.Play("Run");
    }
}
