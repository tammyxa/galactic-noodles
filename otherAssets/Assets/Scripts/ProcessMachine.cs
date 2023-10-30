// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using static PlayerInput;
// using static PlayableObject;
// using static ProgressBar;

// public class ProcessMachine : PlayableObject
// {
//     public float health = 50f;
//     public int maxOutputStack = 5;
//     public int maxInputStack = 5;
//     public float processRate = 0.1f;
//     public GameObject outputItem;
//     public ProgressBar uiBar;


//     private float progress = 0f;
//     private int inCount = 0;
//     private int outCount = 0;
    

//     ProcessMachine()
//     {
//         this.type = "MACHINE";
//         this.OnGrab = _grab;
//         this.OnInteract = _interact;
//     }

//     void Awake()
//     {
//         //check if output item is grabbleObject
//         if (outputItem.GetComponent<GrabbleObject>() == null)
//         {
//             this.outputItem = null;
//             Debug.Log("outputItem was not a GrabbleObject");
//         }
//     }

//     void Update()
//     {
//         if (inCount < 1 || outCount >= maxOutputStack)
//         {
//             //turn off animation
//             return;
//         }

//         progress += processRate;
        
//         if (progress >= 100f) {
//             inCount -= 1;
//             outCount += 1;
//             progress = 0f;
//         }

//         uiBar.displayPercent = progress / 100f;

//         //turn on animation
//     }


//     void _grab(PlayerInput player)
//     {
//         //grabbing output
//         if (player.holding == null && outCount > 0)
//         {
//             GameObject newItem =  GameObject.Instantiate(outputItem);
//             newItem.GetComponent<PlayableObject>().OnGrab(player);
//             outCount -= 1;
//             return;
//         }

//         //check if player is holing metal resource
//         PlayableObject heldItem = player.holding.GetComponent<PlayableObject>();
//         if (heldItem.type != "RESOURCE" || heldItem.name != "metal" || inCount >= maxInputStack) return;

//         //remove metal from player and add to machine
//         heldItem.Delete();
//         player.holding = null;
//         inCount += 1;
//     }


//     void _interact(Playerinput player)
//     {

//     }
// }