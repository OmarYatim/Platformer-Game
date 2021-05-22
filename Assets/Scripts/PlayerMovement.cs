using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    bool FacingRight = true;
    bool IsGrounded;
    bool IsinWater;
    [SerializeField] float speed;
    [SerializeField] float JumpForce;
    [SerializeField] Collider2D GroundCheck;
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] LayerMask WaterLayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        IsGrounded = GroundCheck.IsTouchingLayers(GroundLayer);
        IsinWater = GroundCheck.IsTouchingLayers(WaterLayer);

        if (Input.GetButtonDown("Jump") && (IsGrounded || IsinWater))
        {
            rb2d.AddForce(new Vector2(0, JumpForce));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        anim.SetBool("Running", x != 0);
        anim.SetBool("Jumping", !IsGrounded);

        Vector2 Veclocity = new Vector2(x * speed, rb2d.velocity.y);

        rb2d.velocity = Veclocity;

        if(x>0 && !FacingRight)
        {
            Flip();
        }
        else
        if(x<0 && FacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        GetComponent<SpriteRenderer>().flipX = !FacingRight;
    }
}
