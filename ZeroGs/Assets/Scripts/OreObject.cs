using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;
using static playable.PlayableObject;

public class OreObject : playable.PlayableObject
{
    public TextMesh display;
    public float health = 100f;
    public float destroyRate = 0.5f;
    public GameObject drops;
    private List<PlayerInput> players;
    

    void Awake() 
    {
        this.OnInteract = _interaction;
        this.OnRangeExit = _rangeExit;
        players = new List<PlayerInput>();
        grab = false;
        interact = true;
    }

    void Update()
    {
        int miningCount = players.Count;

        if (miningCount < 1) return;

        if (health <= 0f) {
            dropItems();
            foreach (PlayerInput p in players)
                p.playObjs.Remove(this.gameObject);
            GameObject.Destroy(this.gameObject);
            return;
        }

        health -= destroyRate * (float)miningCount;
        display.text = ((int)health).ToString();
    }

    
    private void _interaction(PlayerInput player)
    {
        if (player.interacting == null)
        {
            players.Add(player);
            player.interacting = (playable.PlayableObject)this;
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
        GameObject.Instantiate(drops, this.transform);
    }
    
}