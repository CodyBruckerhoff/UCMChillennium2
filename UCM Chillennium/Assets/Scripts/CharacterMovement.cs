using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] public float speed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpCoolDown;

    [SerializeField] private float jumpCoolDownReset;
    private bool startCoolDown;

    [SerializeField] private CircleCollider2D groundChecker;
    public bool isGrounded = true;

    [SerializeField] private LayerMask whatIsGroud;

    private SpriteRenderer spriteRender;

    public static CharacterMovement instance;

    [SerializeField] private Animator animator;

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        jumpCoolDownReset = jumpCoolDown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        FloorFall();

        animator.SetBool("isJumping", !isGrounded);
    }

    private void movement()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        if (xDir < 0)
        {
            spriteRender.flipX = true;
        }
        else if (xDir > 0)
        {
            spriteRender.flipX = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(xDir));

        rb.velocity = new Vector2(xDir * speed, rb.velocity.y);

        if (Input.GetKey(KeyCode.W) && isGrounded && jumpCoolDown == jumpCoolDownReset)
        {
            isGrounded = false;
            CalculateJump();
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            startCoolDown = true;
        }
        if (startCoolDown)
        {
            jumpCoolDown -= Time.deltaTime;
        }
        if (jumpCoolDown <= 0 && isGrounded)
        {
            jumpCoolDown = jumpCoolDownReset;
            startCoolDown = false;
        }
    }

    void CalculateJump()
    {
        rb.velocity += new Vector2(rb.velocity.x, rb.velocity.y * Time.deltaTime + (.5f* jumpForce * Time.deltaTime * Time.deltaTime));
        rb.velocity += new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
    }


    private void FloorFall() 
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            tilemap.GetComponent<TilemapCollider2D>().enabled = false;
        }
        else
        {
            tilemap.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }
}
