using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static PlayerInput;
using static playable.PlayableObject;
using static GrabbleObject;


public class ResourceObject : GrabbleObject
{
    public int maxStackCount = 5;
    
    void Awake()
    {
        name = "resource_name";
        grab = true;
        interact = false;
        this.OnGrab = grabEvent;
    }

    public void grabEvent(PlayerInput player)
    {
        //playable.PlayableObject playerScript = player.GetComponent<playable.PlayableObject>();
        this._grab(player);
        Debug.Log("Resource Trigger!");
        //check holding; if null || this.gameObject == holding -> return
        
    }

    void popStack(PlayerInput player)
    {

    }
}
