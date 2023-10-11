using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;
using System;

namespace playable {
    public class PlayableObject : MonoBehaviour
    {
        public string name;
        protected bool grab = true;
        protected bool interact = false;

        public Action<PlayerInput> OnInteract;      //trigger as main code
        public Action<PlayerInput> OnGrab;          //trigger before main player grab code
        public Action<PlayerInput> OnRangeEnter;    //triggered when PlayObject enters interactive collider
        public Action<PlayerInput> OnRangeExit;     //triggered when PlayObject exits interactive collider


        public bool isGrabble() {return grab;}
        public bool isInteract() {return interact;}
        public void Delete() { GameObject.Destroy(this.gameObject); }
    }
}