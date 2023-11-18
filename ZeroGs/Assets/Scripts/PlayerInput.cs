using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using static PlayableObject;


public class PlayerInput : MonoBehaviour
{
    public float gravity = 15.0f;
    public float speed = 5.0f;
    public float jumpSpeed = 3.0f;
    public float turnSpeed = 720.0f;
    public List<GameObject> playObjs;

    [HideInInspector]
    public GameObject holding;
    [HideInInspector]
    public PlayableObject interacting;

    private Animator anim;
    private CharacterController controller;
    private Vector2 moveInput;
    private float verticalVelo = 0f;



    void Awake()
    {
        playObjs = new List<GameObject>();
        moveInput = Vector2.zero;
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }


    void Update()
    {
        //animation
        if (isGrounded())
            playAnim("jump", false);
        playAnim("running");

        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

        //rotate towards move direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion rotVec = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotVec, turnSpeed * Time.deltaTime);
        }

        //movement
        moveDirection *= speed * Time.deltaTime;
        moveDirection.y = verticalVelo * Time.deltaTime;
        controller.Move(moveDirection);

        //apply gravity
        if (!isGrounded())
            verticalVelo -= gravity * Time.deltaTime;
        else
            verticalVelo = 0f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayObj" || playObjs.Contains(other.gameObject) || other.gameObject == this.holding) return;

        playObjs.Add(other.gameObject);
        other.GetComponent<PlayableObject>().OnRangeEnter(this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "PlayObj") return;

        if ( playObjs.Remove(other.gameObject) )
            other.GetComponent<PlayableObject>().OnRangeExit(this);
    }


    private bool isGrounded()
    {
        //NOTE: make sure GroundCheck gameObject is first child
        return Physics.Raycast(transform.GetChild(0).position,
            Vector3.down,
            0.1f);
    }


    public void fixNullObj()
    {
        foreach (GameObject obj in playObjs)
        {
            if (obj == null)
                playObjs.Remove(obj);
        }
    }



    //===== Action Events ==========================
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!isGrounded()) return;

        verticalVelo = jumpSpeed;
        playAnim("jump");
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        try
        {
            if (context.canceled || context.performed) return;

            if (holding != null && playObjs.Count < 1)
            {
                holding.GetComponent<PlayableObject>().OnGrab(this);
                return;
            }
            else if (playObjs.Count < 1) return;

            playObjs[0].GetComponent<PlayableObject>().OnGrab(this);
        }
        catch
        {
            fixNullObj();
            playObjs[0].GetComponent<PlayableObject>().OnGrab(this);
        }
    }


    public void OnInteract(InputAction.CallbackContext context)
    {
        try
        {
            if (context.performed) return;

            if (context.started && playObjs.Count > 0)      //While holding
            {
                this.interacting = playObjs[0].GetComponent<PlayableObject>();
                interacting.OnInteract(this);
            }
            else if (context.canceled && this.interacting != null)
            {
                var temp = this.interacting;
                this.interacting = null;
                temp.OnInteract(this);
            }
        }
        catch
        {
            fixNullObj();
        }

        /*
        if (context.started && playObjs.Count > 0 && interacting == null)    //While holding
        {   
            interacting = FetchFirstPlayable().GetComponent<PlayableObject>();
            if (!interacting.isInteract())
            {
                interacting = null;
                return;
            }
            isInteracting = true;
            interacting.OnInteract(this.gameObject);
        }
        else if (context.canceled && interacting != null)
        {
            isInteracting = false;
            interacting.OnInteract(this.gameObject);
            interacting = null;
        }
        */
    }


    //===== Animation Control ======================
    void playAnim(string type, bool play = true)
    {
        switch (type)
        {
            case "running":
                if (!isGrounded()) return;
                if (moveInput.magnitude > 0f)
                    anim.SetBool("isRunning", true);
                else
                    anim.SetBool("isRunning", false);
                break;

            case "interact":
                anim.SetBool("isReacting", play);
                break;

            case "jump":
                anim.SetBool("isJumping", play);
                break;

            default:
                Debug.Log("[ERROR]: Unknown Animation Tag");
                break;
        }

        /*
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey("e"))
        {
            anim.SetBool("isReacting", true);
        }
        else
        {
            anim.SetBool("isReacting", false);
        }

        if (Input.GetKey("space"))
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isJumping", false);
        }*/
    }
}