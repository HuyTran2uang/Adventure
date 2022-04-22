using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public static bool IsGrounded { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
            IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
            IsGrounded = false;
    }
}
