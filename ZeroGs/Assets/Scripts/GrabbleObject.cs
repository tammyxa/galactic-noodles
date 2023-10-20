using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static PlayerInput;
using static PlayableObject;


public class GrabbleObject : PlayableObject
{
    public GrabbleObject()
    {
        grab = true;
        interact = false;
        this.OnGrab = _grab;
    }

    protected void _grab(PlayerInput player)
    {
        try
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
                player.holding.transform.LookAt(player.transform, Vector3.up);
                player.holding.transform.localRotation = Quaternion.LookRotation(new Vector3(0f, player.holding.transform.localRotation.y, 0f), Vector3.up);
            }
        }
        catch (NullReferenceException e)
        {
            player.fixNullObj();
            _grab(player);
        }
    }
}
