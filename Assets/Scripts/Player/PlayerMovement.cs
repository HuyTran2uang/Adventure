using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;

    private float inputX;
    private Vector2 velocity;
    private Vector3 scale;
    //check
    private bool isGrounded;
    private bool isActing;
    public bool isJumpPressed;

    private void Start()
    {
        LoadInformation();
        scale = PlayerController.Instance.transform.localScale;
    }

    private void Reset()
    {
        LoadInformation();
    }

    private void LoadInformation()
    {
        MoveSpeed = 5;
        JumpForce = 5;
    }

    private void Update()
    {
        isGrounded = GroundSensor.IsGrounded;
        velocity = PlayerController.Instance.Rigidbody2D.velocity;

        InputManager();
        Move();
        Jump();
        ChangeAnimation();
        Flip();
    }

    private void FixedUpdate()
    {
        PlayerController.Instance.Rigidbody2D.velocity = velocity;
        PlayerController.Instance.transform.localScale = scale;
    }

    private void InputManager()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        isJumpPressed = Input.GetKey("k");
    }

    private void Move()
    {
        if (isActing) { velocity.x = 0; return; }
        velocity.x = inputX * MoveSpeed;
    }

    private void Jump()
    {
        if (isActing) return;
        if (!isJumpPressed) return;
        isJumpPressed = false;
        if (!isGrounded) return;
        velocity.y = JumpForce;
    }

    private void ChangeAnimation()
    {
        if (isActing) return;
        if (!isGrounded) { AnimationJump(); return; }
        if (inputX != 0) AnimationWalk(); else AnimationIdle();
    }

    private void Flip()
    {
        if (isActing) return;
        if (inputX > 0) scale.x = 1;
        if (inputX < 0) scale.x = -1;
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

    public void CheckActing(bool acting)
    {
        isActing = acting;
    }
}
