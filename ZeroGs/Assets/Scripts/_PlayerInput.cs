using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerInput : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 2f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curVelo = rb.velocity;
        float x_in = Input.GetAxis("Horizontal");
        float z_in = Input.GetAxis("Vertical");

        curVelo.x = x_in * speed;
        curVelo.z = z_in * speed;

        rb.velocity = curVelo;
        /*
        if (Input.GetAxis("Horizontal") != 0f) {
            curVelo.x = Input.GetAxis("Horizontal") * speed;
        }
        else curVelo.x = 0f;
        

        if (Input.GetAxis("Vertical") != 0f) {
            curVelo.z = Input.GetAxis("Vertical") * speed;
        }
        else curVelo.z = 0f;
        */
    }
}
