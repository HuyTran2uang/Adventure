using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;

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
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        minX = -2.3f;
        maxX = 2.3f;
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), 0, -10);
    }
}
