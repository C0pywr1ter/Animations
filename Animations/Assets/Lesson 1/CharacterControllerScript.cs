using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float maxSpeed = 10f;
    private bool isFacingRight = true;
    private Animator anim;
    private Rigidbody2D rigidbody;
    bool isGrounded = true;

    private void Start()
    {
    
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            isGrounded = false;
            anim.SetBool("jump", true);
            rigidbody.AddForce(new Vector2(0, 2000));
        }
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(move));

        rigidbody.velocity = new Vector2(move * maxSpeed, rigidbody.velocity.y);

        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            anim.SetBool("jump", false);
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
