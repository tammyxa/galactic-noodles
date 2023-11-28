using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;
using static PlayableObject;
using static ProgressBar;
using static RadialProgressBar;




public class ChargeTank : PlayableObject
{
    public Spawner_SparkFish spawner;
    public ProgressBar bar;
    public RadialProgressBar startBar;
    public GameObject reward;
    public float progress = 0f;
    public float progressAmount = 10f;

    private bool isStarting = false;
    private int state = 0;

    ChargeTank() 
    {
        this.OnGrab = placeFish;
        this.OnInteract = _interact;
    }


    void Update()
    {
        if (!isStarting || state != 0) return;

        progress++;
        startBar.displayPercent = progress / 100f;
        if (progress >= 100f) {
            progress = 0f;
            isStarting = false;
            spawner.active = true;
            state = 1;
        }
    }


    private void placeFish(PlayerInput player)
    {
        if (!spawner.active) return;
        if (progress >= 100f) return;
        PlayableObject heldItem = player.holding.GetComponent<PlayableObject>();
        
        if (heldItem.name != "spark_fish") return;

        heldItem.Delete();
        player.holding = null;

        progress += progressAmount;
        this.bar.displayPercent = progress / 100f;
        if (progress >= 100f)
        {
            spawner.active = false;
            state = -1;
            //spawn reward
            for (int i = Random.Range(5, 8); i > 0; i--)
            {
                GameObject newObj = GameObject.Instantiate(reward);
                newObj.transform.position = this.transform.position + (Vector3.up * 2f);
                newObj.GetComponent<Rigidbody>().velocity = new Vector3(
                    Random.Range(-3f, 3f),
                    18f,
                    Random.Range(-3f, 3f)
                );
            }
        }
    }


    void _interact(PlayerInput player)
    {
        isStarting = player.interacting != null;
    }
    
}