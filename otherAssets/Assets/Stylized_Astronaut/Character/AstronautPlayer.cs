using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace AstronautPlayer
{
    public class AstronautPlayer : MonoBehaviour
    {
        private Animator anim;
        private CharacterController controller;

        public float speed = 600.0f;
        public float turnSpeed = 400.0f;
        private Vector3 moveDirection = Vector3.zero;
        public float gravity = 20.0f;

        public GameObject player;
        public List<GameObject> interactableObjects = new List<GameObject>();
        public List<GameObject> ores = new List<GameObject>();
        public float interactionRadius = 2.0f;
        private int objectsPickedUp = 0;
        public Text counterText;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            HandleObjectInteractions();
            HandlePlayerMovement();
        }
		 public void UpdateObjectCount(int count)
    {
        objectsPickedUp = count;
        counterText.text = "Objects Picked Up: " + objectsPickedUp;
    }
	  public void ObjectPickedUp()
    {
        objectsPickedUp++;
        counterText.text = "Objects Picked Up: " + objectsPickedUp;
		
    }

 private void HandleObjectInteractions()
{
    foreach (GameObject obj in interactableObjects)
    {
        float distanceToObj = Vector3.Distance(player.transform.position, obj.transform.position);

        if (Input.GetKeyDown(KeyCode.E) && distanceToObj <= interactionRadius)
        {
            if (obj.transform.parent == null)
            {
                obj.transform.SetParent(player.transform);
            }
            else
            {
                obj.transform.SetParent(null);
            }
        }
    }

    foreach (GameObject ore in ores)
    {
        float distanceToOre = Vector3.Distance(player.transform.position, ore.transform.position);

        if (Input.GetKey(KeyCode.F) && distanceToOre <= interactionRadius)
        {
            ore.SetActive(false);
            ObjectPickedUp();
			break;
        }
    }

   
    UpdateObjectCount(objectsPickedUp);
}
        private void HandlePlayerMovement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("AnimationPar", 1);
            }
            else
            {
                anim.SetInteger("AnimationPar", 0);
            }

            if (controller.isGrounded)
            {
                moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
            }

            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            controller.Move(moveDirection * Time.deltaTime);
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }
}
