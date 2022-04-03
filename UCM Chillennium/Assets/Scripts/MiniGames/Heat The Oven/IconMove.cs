using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;

    private void Update()
    {
        iconMovement();
    }

    private void iconMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
