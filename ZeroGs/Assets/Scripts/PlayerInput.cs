using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


class PlayerInput : MonoBehaviour
{
    public float gravity = 15.0f;
    public float speed = 5.0f;
    public float jumpSpeed = 3.0f;
    public float turnSpeed = 720.0f;
    public List<GameObject> playObjs;

    private Animator anim;
    private CharacterController controller;
    private Vector2 moveInput;
    private float verticalVelo = 0f;
    private bool isInteracting = false;
    private GameObject holding;
    private int x = 0;


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
        if (other.tag != "PlayObj") return;

        playObjs.Add(other.gameObject);
    }

     private void OnTriggerExit(Collider other)
    {
        if (other.tag != "PlayObj") return;

        playObjs.Remove(other.gameObject);
    }


    private bool isGrounded()
    {
        //NOTE: make sure GroundCheck gameObject is first child
        return Physics.Raycast(transform.GetChild(0).position,
            Vector3.down, 
            0.1f);
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
        if (context.canceled || context.performed) return;

        Rigidbody rb;

        //dropping item
        if (holding != null)
        {
            holding.transform.SetParent(null);
            rb = holding.GetComponent<Rigidbody>();
            if (rb != null)
                rb.constraints = RigidbodyConstraints.None;
            holding = null;
            return;
        }

        if (playObjs.Count <= 0) return;

        holding = playObjs[0];
        rb = holding.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.FreezeAll;
        holding.transform.SetParent(transform);
        holding.transform.localPosition = new Vector3(0f, 1f, 0.85f);
        holding.transform.LookAt(transform);
        holding.transform.rotation = Quaternion.LookRotation(new Vector3(0f, holding.transform.rotation.y, 0f), Vector3.up);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        
        //playAnim("interact", true);
    }


    //===== Animation Control ======================
    void playAnim(string type, bool play=true)
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