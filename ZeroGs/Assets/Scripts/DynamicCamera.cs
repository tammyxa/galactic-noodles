using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    public GameObject cam;

   Rigidbody camRb;
   Camera camComp;
   public GameObject player;
   float accel = 0f;


    // Start is called before the first frame update
    void Start()
    {
        camRb = GetComponent<Rigidbody>();
        camComp = cam.GetComponent<Camera>();
        player = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector3 dirVec = player.transform.position - this.gameObject.transform.position;
        dirVec.y = 0;
        
        camRb.velocity = dirVec + ( dirVec.normalized * (dirVec.magnitude > 10.5f ? accel += 0.01f : 0f));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Player") return;

        camRb.velocity = new Vector3(0,0,0);
        player = null;
        accel = 0f;
    }

    /*
    private void OnTriggerStay(Collider other) {
        if (other.tag != "Player") return;

        player = null;
        accel = 0f;
    }*/

    private void OnTriggerExit(Collider other) {
        if (other.tag != "Player") return;

        player = other.gameObject;
    }
}
