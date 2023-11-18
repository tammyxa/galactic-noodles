using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    public GameObject cam;

   Transform transform;
   Camera camComp;
   public GameObject player;
   bool inView = true;


    void Start()
    {
        transform = GetComponent<Transform>();
        camComp = cam.GetComponent<Camera>();
        player = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector3 dirVec = player.transform.position - transform.position;

        transform.Translate(dirVec * Time.deltaTime, Space.World);
        //camRb.velocity = dirVec + ( dirVec.normalized * (dirVec.magnitude > 10.5f ? accel += 0.01f : 0f));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag != "Player") return;

        player = null;
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
