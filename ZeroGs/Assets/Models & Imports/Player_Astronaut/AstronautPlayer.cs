using UnityEngine;
using System.Collections;



	public class __PlayerMovement : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;

				if (Input.GetKey ("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d")) {
					anim.SetBool ("isRunning", true);
				} else {
					anim.SetBool ("isRunning", false);
				}

				// if (Input.GetKey ("e")) {
				// 	anim.SetBool ("isReacting", true);
				// } else {
				// 	anim.SetBool ("isReacting", false);
				// }

				if (Input.GetKey ("space")) {
					anim.SetBool ("isJumping", true);
					// moveDirection = transform.up * Input.GetAxis("Vertical") * speed;
				}else{
					anim.SetBool ("isJumping", false);
				}
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}

		void FixedUpdate(){

			
		}
	}
