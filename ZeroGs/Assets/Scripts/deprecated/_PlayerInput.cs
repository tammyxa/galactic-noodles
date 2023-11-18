using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player_Input : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 2f;

    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical") );

        transform.Translate(movVec * speed * Time.deltaTime, Space.World);
        
        if (movVec != Vector3.zero)
        {
            Quaternion rotVec = Quaternion.LookRotation(movVec, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotVec, rotateSpeed * Time.deltaTime);
        }
    }
}
