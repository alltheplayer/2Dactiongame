using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_jump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowMultiplier = 2f;
    Rigidbody2D rb;
    [Range(1, 10)]
    public float jumpVelocity;
    private int jumpcount;
    private bool isOnGround;
    private bool jumpPress;
    private Collider2D coll;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>().GetComponentInChildren<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && jumpcount > 0)
        {
            jumpPress = true;
        }

    }
    private void FixedUpdate()
    {
        CheckGround();
        Jump();
        Betterjump();
    }
    void Jump()
    {
        if (isOnGround)
        {
            jumpcount = 1;

        }
        if (jumpPress && isOnGround)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            jumpcount--;
            jumpPress = false;


        }
        else if (jumpPress && jumpcount > 0 && !isOnGround)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            jumpcount--;
            jumpPress = false;
        }


    }
    void Betterjump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier - 1) * Time.deltaTime;
        }
    }
    void CheckGround()
    {
        if (coll.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isOnGround = true;
            animator.SetBool("Isground", true);
        }
        else
        {
            isOnGround = false;
            animator.SetBool("Isground", false);
        }
    }
}
