using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;
using static PlayableObject;
using static ProgressBar;

public class OreObject : PlayableObject
{
    public ProgressBar bar;
    public float maxHealth = 100f;
    public float destroyRate = 0.5f;
    public GameObject drops;
    private List<PlayerInput> players;
    private float health;
    

    public OreObject() 
    {
        health = maxHealth;
        this.OnInteract = _interaction;
        this.OnRangeExit = _rangeExit;
        players = new List<PlayerInput>();
        grab = false;
        interact = true;
    }

    void Update()
    {
        if (players.Count < 1) return;

        if (health <= 0f) {
            dropItems( (int)(Time.fixedTime % 3) + 1);
            GameObject.Destroy(this.gameObject);
            return;
        }

        health -= destroyRate * (float)players.Count;
        bar.displayPercent = health / maxHealth;
        //display.text = ((int)health).ToString();
    }


    void OnDestroy()
    {
        foreach (PlayerInput p in players) {
            if (!p.playObjs.Remove(this.gameObject))
                p.fixNullObj();
            p.interacting = null;
        }
    }

    
    private void _interaction(PlayerInput player)
    {
        if (player.interacting != null)
        {
            players.Add(player);
        }
        else
        {
            players.Remove(player);
        }
    }


    private void _rangeExit(PlayerInput player)
    {
        if (player.interacting != this) return;
            
        player.interacting = null;
        players.Remove(player);
    }


    private void dropItems(int count=1)
    {
        if (drops == null) return;
        GameObject newObj = GameObject.Instantiate(drops);
        newObj.transform.position = this.transform.position;
    }
    
}