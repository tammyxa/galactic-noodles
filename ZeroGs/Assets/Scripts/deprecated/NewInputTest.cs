using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using System;

public class NewInputTest : MonoBehaviour
{
    public Transform groundCheck;
    public float speed = 5f;
    public float rotateSpeed = 720f;
    public float jumpSpeed = 9f;

    private Vector2 moveInput;
    private Rigidbody rb;

    void Awake()
    {
        moveInput = Vector2.zero;
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Vector3 movVec = new Vector3(moveInput.x, 0, moveInput.y);

        if (isGrounded())
            transform.Translate(movVec * speed * Time.deltaTime, Space.World);
        else {
            rb.velocity = new Vector3(
                rb.velocity.x + (Math.Abs(rb.velocity.x) <= 4f ? moveInput.x * 0.25f : 0f),
                rb.velocity.y,
                rb.velocity.z + (Math.Abs(rb.velocity.z) <= 4f ? moveInput.y * 0.25f : 0f)
            );
        }

        if (movVec != Vector3.zero)
        {
            Quaternion rotVec = Quaternion.LookRotation(movVec, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotVec, rotateSpeed * Time.deltaTime);
        }

    }


    private void TapTrigger(InputAction.CallbackContext context)
    {
        if (!isGrounded()) return;
        
        rb.velocity = new Vector3(
            moveInput.x * speed,
            jumpSpeed,
            moveInput.y * speed
        );
    }

    private void MultiTapTrigger(InputAction.CallbackContext context)
    {
        Debug.Log("Multi-Tap Trigger!");
    }


    private bool isGrounded()
    {
        return Physics.Raycast(groundCheck.position, Vector3.down, 0.1f);
    }


    //===== Events ================
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.interaction is MultiTapInteraction) 
        {
            MultiTapTrigger(context);
            return;
        }

        TapTrigger(context);
    }
}
