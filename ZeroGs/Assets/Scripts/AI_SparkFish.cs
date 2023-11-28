using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;
using static GrabbleObject;
using static GameMaster;
//using static PlayableObject;


public class AI_SparkFish : GrabbleObject
{
    public float speed = 5f;
    public bool isFlopping = true;
    public float shockBuildRate = 1f;

    private static float hoverHeight = 0.55f;
    private Rigidbody rb;
    private PlayerInput heldPlayer = null;
    public float shockBuildUp = 0f;
    private float flopTime = 0;

    AI_SparkFish()
    {
        this.OnGrab = grabFish;
    }

    void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //shocking player status build up
        if (heldPlayer != null)
        {
            shockBuildUp += shockBuildRate * Time.deltaTime;
            if (shockBuildUp >= 100f)
            {
                //drops fish and stuns player
                this._grab(heldPlayer);
                SetFlopState(true);
                this.heldPlayer.Stun(1.8f);
                this.heldPlayer = null;
                this.shockBuildUp = 0f;
            }
        }

        /*
        //flopping state
        else if (this.isFlopping)
            floppingState();

        //normal AI state
        else normalState();
        */
    }

    void grabFish(PlayerInput player)
    {
        if (this.heldPlayer == null)
        {
            SetFlopState(false);
            this._grab(player);
            this.heldPlayer = player;
        }
        else if (this.heldPlayer == player)
        {
            this._grab(player);
            SetFlopState(true);
            this.heldPlayer = null;
        }
    }


    void floppingState()
    {
        //disable flopState after 3 seconds
        if (Time.fixedTime - this.flopTime >= 3f)
        {
            SetFlopState(false);
            return;
        }

        //bounce in semi-random direction
        if (Physics.Raycast(this.transform.position, Vector3.down, 0.1f) /*&& Math.Abs(this.rb.velocity.y) < 0.1f*/ )
            this.rb.velocity = new Vector3(
                (0.75f * (Time.deltaTime % 5 == 0 ? 1f : -1f)),
                5f,
                (0.75f * (Time.deltaTime % 5 == 0 ? 1f : -1f))
            );
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.collider.isTrigger || !this.isFlopping) return;

        this.rb.velocity = new Vector3(
            0.75f * Random.Range(-1, 1),
            7f,
            0.75f * Random.Range(-1, 1)
        );
    }

    //disabled
    /*
    void normalState()
    {
        //TODO: make AI to random wander and run away from nearby players

        //set postion to hover level
        RaycastHit[] hit;
        hit = Physics.RaycastAll( new Ray(this.transform.position, Vector3.down), 999f, 1, QueryTriggerInteraction.Ignore);
        if (hit[0].distance > AI_SparkFish.hoverHeight) 
        {
            Vector3 globalVec = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

            globalVec.y -= hit[0].distance - hoverHeight;

            this.transform.position = globalVec;
        }

        //----- movement -----
        //25% to change direction after 3 seconds
        if (Time.fixedTime % 3 == 0 && Random.Range(0f, 100f) > 75f) {
            Quaternion rotVec = Quaternion.LookRotation(
                new Vector3(
                    Random.Range(-1f, 1f),
                    0,
                    Random.Range(-1f, 1f)
                ),
                Vector3.up
            );
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, rotVec, 360f);
        }

        //if move direction hits a collider 2 meters away, turn 180 +/- random number
        if ( Physics.Raycast(
            this.transform.position, 
            this.transform.rotation * Vector3.forward,
            2f, 1, QueryTriggerInteraction.Ignore)
        )
        {
            this.transform.rotation.SetLookRotation(new Vector3(Random.Range(-0.5f, 0.5f), 0, -1 ));
        }

        //move forward direction
        this.transform.Translate(this.transform.rotation * Vector3.forward * this.speed * Time.deltaTime);
    }*/


    public void SetFlopState(bool state)
    {
        this.isFlopping = state;
        this.rb.velocity = Vector3.zero;

        if (this.isFlopping)
        {
            this.rb.constraints = RigidbodyConstraints.FreezeRotation;
            this.rb.useGravity = true;
            this.flopTime = Time.fixedTime;
            this.transform.rotation = Quaternion.Slerp(
                this.transform.rotation,
                Quaternion.Euler(0f, 90f, 90f),
                360f
            );
        }
        else
        {
            this.rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
            this.rb.useGravity = false;
        }
    }
}