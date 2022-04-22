using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public Transform TransformModelPlayer { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }

    public PlayerMovement PlayerMovement { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        LoadComponent();
    }

    private void LoadComponent()
    {
        LoadPlayer();
        LoadScript();
    }

    private void LoadPlayer()
    {
        TransformModelPlayer = transform.Find("Model");
        Animator = TransformModelPlayer.GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void LoadScript()
    {
        PlayerMovement = transform.Find("PlayerMovement").GetComponent<PlayerMovement>();
    }
}
