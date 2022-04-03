using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            CharacterMovement.instance.isGrounded = true;
        }
    }
}
