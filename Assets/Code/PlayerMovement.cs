using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float moveH = 0f;
    float moveSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;

        //Jumping
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        animator.SetBool("IsJumping", Input.GetKey(KeyCode.Space));
        //animator.SetBool("IsFalling", Input)

        //Crouching
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            crouch = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            crouch = false;
        }

        //Animations
        if(moveH != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        animator.SetBool("IsCrouching", Input.GetKey(KeyCode.LeftShift));
    }

    void FixedUpdate()
    {
        controller.Move(moveH * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }
}
