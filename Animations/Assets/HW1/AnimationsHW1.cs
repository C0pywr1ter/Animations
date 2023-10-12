using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHW1 : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    float speed = 100f;
    bool isjump;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetFloat("crouch", 3f);
            
           
        }
        else
        {
            animator.SetFloat("crouch", 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetFloat("speed", 2f);
                rb.AddRelativeForce(0, 0, speed * 1.8f);
            }
            
            else
            {
                rb.AddRelativeForce(0, 0, speed);
                PlayAnim();
            }
          

        }
        else
        {
            StopAnim();
        }
      if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeTorque(0, -speed, 0);
          
        }
      
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(0, 0, -speed);
            PlayAnim();
        }
        
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeTorque(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isjump == false)
            {
                Jump();
            }
            
            
        }
    }
    
    public void PlayAnim()
    {
        animator.SetFloat("speed", 1f);
    }
    public void StopAnim()
    {
        animator.SetFloat("speed", 0f);
    }
    private void Jump()
    {
        rb.AddRelativeForce(0, 70, 0);
        animator.SetFloat("speed", -1f);
        StartCoroutine(JumpCoroutine());
    }
    IEnumerator JumpCoroutine()
    {
        yield return new WaitForSeconds(1);
        isjump = true;
        StopAnim();
        yield return new WaitForSeconds(1);
        isjump = false;

    }
}
