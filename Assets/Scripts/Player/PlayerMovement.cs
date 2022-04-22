using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isMoving;

    private float inputX;

    private Vector2 velocity;

    private bool isGrounded;

    private bool isActing;

    private void Update()
    {
        isGrounded = GroundSensor.IsGrounded;

        ChangeAnimation();
        Move();
    }

    private void FixedUpdate()
    {
        PlayerController.Instance.Rigidbody2D.velocity = velocity;
    }

    private void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal");
    }

    private void ChangeAnimation()
    {
        if (isActing) return;
        if (isGrounded)
        {
            if (inputX != 0) AnimationWalk();
            else AnimationIdle();
        }
        else AnimationJump();
    }

    private void AnimationIdle()
    {
        PlayerController.Instance.Animator.Play("Idle");
    }

    private void AnimationWalk()
    {
        PlayerController.Instance.Animator.Play("Walk");
    }

    private void AnimationJump()
    {
        PlayerController.Instance.Animator.Play("Jump");
    }
}
