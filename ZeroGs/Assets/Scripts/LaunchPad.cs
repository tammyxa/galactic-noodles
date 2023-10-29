using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static PlayableObject;
using static RadialProgressBar;


public class LaunchPad : PlayableObject
{
    public RadialProgressBar radialBar;
    public float requiredBuild = 10f;
    public float scrapBuildCost = 1f;
    public GameObject escapeRender;

    [HideInInspector]
    public int totalPlayers = 1;    //will get this from GameMaster 
    [HideInInspector]
    public float buildProgress = 0f;

    private int playerCount = 0;
    private Collider buildCollider;
    private Collider escapeCollider;
    private bool escapeState = false;
    

    void Awake()
    {
        radialBar.displayPercent = 0f;

        escapeCollider = GetComponent<SphereCollider>();
        escapeCollider.enabled = false;

        buildCollider = GetComponent<BoxCollider>();
        buildCollider.enabled = true;
        
        escapeRender.SetActive(false);

        this.OnGrab = _grab;
    }


    void Update()
    {
        if (!escapeState || playerCount < totalPlayers)
        {
            radialBar.displayPercent = radialBar.displayPercent <= 0f ? 0f
                : radialBar.displayPercent - 0.001f;
            return;
        }

        radialBar.displayPercent += 0.005f;
        if (radialBar.displayPercent >= 1f)
        {
            //trigger end game
            Debug.Log("EndGame!");
        }
    }

    //TODO: change to 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" || other.isTrigger || !escapeState) return;
        playerCount += 1;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" || other.isTrigger || !escapeState) return;
        playerCount -= 1;
    }

    void _grab(PlayerInput player)
    {
        if (player.holding == null || escapeState) return;
        PlayableObject heldItem = player.holding.GetComponent<PlayableObject>();
        if (heldItem.name != "scrap" || heldItem.type != "RESOURCE") return;

        heldItem.Delete();
        player.holding = null;
        buildProgress += scrapBuildCost;

        //enter escape state
        if (buildProgress >= requiredBuild)
        {
            buildCollider.enabled = false;
            escapeCollider.enabled = true;
            escapeRender.SetActive(true);
            escapeState = true;
        }
    }

    public int getPlayerCount() { return this.playerCount; }
}