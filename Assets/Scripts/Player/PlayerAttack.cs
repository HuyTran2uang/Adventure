using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int Damage;
    public float Cooldown;
    public float SpeedAttack;//time complete attack
    //check
    private bool isAttackPressed;
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
        Damage = 2;
        Cooldown = 2;
        SpeedAttack = 0.9f;
        //
        pointAttack = transform.Find("PointAttack");
        enemyLayer = LayerMask.GetMask("Enemy");
        areaDamage = 0.63f;
    }

    private void Update()
    {
        InputManager();
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

    private void InputManager()
    {
        isAttackPressed = Input.GetKey("j");
    }

    private void Attack()
    {
        if (!isAttackPressed) return;
        isAttackPressed = false;
        if (isAttacking) return;
        if (time > 0) return;
        isAttacking = true;
        time = Cooldown;
        PlayerController.Instance.PlayerMovement.CheckActing(isAttacking);
        SendDamage(Damage);
        StartCoroutine(CompleteAttack(SpeedAttack));
    }

    private void SendDamage(int damage)
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(pointAttack.position, areaDamage, enemyLayer);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.gameObject.layer == 9)
                enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointAttack.position, areaDamage);
    }

    private IEnumerator CompleteAttack(float time)
    {
        yield return new WaitForSeconds(time);
        isAttacking = false;
        PlayerController.Instance.PlayerMovement.CheckActing(isAttacking);
    }

    private void ChangeAnimation()
    {
        if (!isAttacking) return;
        AnimationAttack();
    }

    private void AnimationAttack()
    {
        PlayerController.Instance.Animator.Play("Attack");
    }
}
