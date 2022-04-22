using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected Transform TransformModel;
    protected Animator Animator;
    protected Rigidbody2D Rigidbody2D;
    protected Transform Target;

    protected EnemyMovement EnemyMovement;
    protected EnemyHealth EnemyHealth;
    protected EnemyAttack EnemyAttack;

    private void Awake()
    {
        LoadComponent();
    }

    private void Reset()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        LoadEnemy();
        LoadScript();
    }

    private void LoadEnemy()
    {
        TransformModel = transform.Find("Model");
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = TransformModel.GetComponentInChildren<Animator>();
        Target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void LoadScript()
    {
        EnemyMovement = GetComponent<EnemyMovement>();
        EnemyHealth = GetComponent<EnemyHealth>();
        EnemyAttack = GetComponent<EnemyAttack>();
    }
}
