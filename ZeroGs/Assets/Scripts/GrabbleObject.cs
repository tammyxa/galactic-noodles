using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static PlayerInput;
using static playable.PlayableObject;


public class GrabbleObject : playable.PlayableObject
{
    void Awake()
    {
        grab = true;
        interact = false;
        this.OnGrab = _grab;
    }

    protected void _grab(PlayerInput player)
    {
        //dropping item
        if (player.holding != null)
        {
            player.holding.transform.SetParent(null);
            Rigidbody rb = player.holding.GetComponent<Rigidbody>();
            if (rb != null)
                rb.constraints = RigidbodyConstraints.None;
            player.holding = null;
            return;
        }


        //picking up item
        else
        {
            player.holding = this.gameObject;
            Rigidbody rb = player.holding.GetComponent<Rigidbody>();
            if (rb != null)
                rb.constraints = RigidbodyConstraints.FreezeAll;
            player.holding.transform.SetParent(player.transform);
            player.holding.transform.localPosition = new Vector3(0f, 1f, 0.85f);
            player.holding.transform.LookAt(player.transform);
            player.holding.transform.rotation = Quaternion.LookRotation(new Vector3(0f, player.holding.transform.rotation.y, 0f), Vector3.up);
        }
    }
}
