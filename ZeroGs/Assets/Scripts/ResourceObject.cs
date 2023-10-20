using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static PlayerInput;
using static PlayableObject;
using static GrabbleObject;


public class ResourceObject : GrabbleObject
{
    public int maxStackCount = 5;
    [HideInInspector]
    public bool isStack = false;
    

    public ResourceObject()
    {
        name = "resource_name";
        type = "RESOURCE";
        grab = true;
        interact = false;
        this.OnGrab = grabEvent;
    }

    protected void grabEvent(PlayerInput player)
    {
        _grab(player);
    }
}
