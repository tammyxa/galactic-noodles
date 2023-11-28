using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayableObject;
using static AI_SparkFish;



public class Spawner_SparkFish : MonoBehaviour
{
    public bool active = false;
    public GameObject entity;
    public float spawnRate = 5f;

    private float curTime = 0;

    void Update()
    {   
        if (!active || Time.fixedTime - curTime < spawnRate) return;

        curTime = Time.fixedTime;
        GameObject newObj = GameObject.Instantiate(entity);
        newObj.GetComponent<AI_SparkFish>().SetFlopState(true);
        newObj.transform.position = this.transform.position;
        newObj.GetComponent<Rigidbody>().velocity = new Vector3(
                    Random.Range(-3f, 3f),
                    12f,
                    Random.Range(-3f, 3f)
                );

    }

}