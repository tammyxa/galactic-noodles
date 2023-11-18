using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceShip : MonoBehaviour
{
    Rigidbody SpaceshipRB;
    public float speed = 0.5f;
    float verticalMove;
    float horizontalMove;
    //Speed Multipliers
    [SerializeField]
    float speedMult = 0.3f;
    float minX = -3.2f;
    float maxX = 3.5f;
    float minY = -0.1f;
    float maxY = 3.2f;
    // [SerializeField]
    // float speedMultAngle = 0.5f;
    //player cannot move while count down is on screen
    static public bool canMove = false;


    float mouseInputX;
    float mouseInputY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SpaceshipRB = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {

        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");

        
        // mouseInputX = Input.GetAxis("Mouse X");
        // mouseInputY = Input.GetAxis("Mouse Y");
        // horizontalMove = Input.GetAxis("Horizontal");
        // verticalMove = Input.GetAxis("Vertical");
    }
    
void FixedUpdate(){

     SpaceshipRB.AddForce(SpaceshipRB.transform.TransformDirection(Vector3.forward)*speed*speedMult,ForceMode.VelocityChange);

    if(canMove == true){
        // SpaceshipRB.AddForce(SpaceshipRB.transform.TransformDirection(Vector3.forward)* verticalMove * speedMult, ForceMode.VelocityChange);

        // SpaceshipRB.AddForce(SpaceshipRB.transform.TransformDirection(Vector3.right)* horizontalMove * speedMult, ForceMode.VelocityChange);

        // SpaceshipRB.AddTorque(SpaceshipRB.transform.right * speedMultAngle * mouseInputY * -1, ForceMode.VelocityChange);
        // SpaceshipRB.AddTorque(SpaceshipRB.transform.up * speedMultAngle * mouseInputX, ForceMode.VelocityChange);


        // Move forward/backward (up/down)
    SpaceshipRB.AddForce(SpaceshipRB.transform.TransformDirection(Vector3.up) * verticalMove * speed * speedMult, ForceMode.VelocityChange);

    // Move left/right
    SpaceshipRB.AddForce(SpaceshipRB.transform.TransformDirection(Vector3.right) * horizontalMove * speed * speedMult, ForceMode.VelocityChange);

    float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
    float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // Update the spaceship's position
    transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            other.GetComponent<SpaceRock>().ApplyDamageToPlayer();
        }
    }


}
