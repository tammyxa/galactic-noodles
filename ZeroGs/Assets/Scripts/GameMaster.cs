using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using Cinemachine;
using static PlayerInput;
using static PlayableObject;
using static LaunchPad;
using static MainUiHandler;


public class GameMaster : MonoBehaviour
{
    public GameObject shipProp;
    public CinemachineTargetGroup CineCam;
    public MainUiHandler mainUiHandler;
    public LaunchPad launchPad;
    public List<PlayerInput> players;

    public static LaunchPad pad;
    public static MainUiHandler mainUi;

    private int cutsceneState = 0;
    private float curTime = 0f;


    GameMaster()
    {
        players = new List<PlayerInput>();
        GameMaster.mainUi = mainUiHandler;
        GameMaster.pad = launchPad;
    }

    void Start()
    {
        shipProp = GameObject.Find("PodOnLegs");
        CineCam = GameObject.Find("TargetGroup").GetComponent<CinemachineTargetGroup>();
    }

    public enum WinState {
        WIN,
        LOSE
    };

    void Update()
    {
        //cutscene
        if (cutsceneState != 1) return;

        //fly ship
        if (Time.fixedTime - curTime >= 2.4f)
        {
            shipProp.transform.Translate(Vector3.up * Time.deltaTime * 250f);
        }

        //endgame
        if (Time.fixedTime - curTime >= 7f) 
        {
            mainUiHandler.ShowWinState(true);
            Time.timeScale = 0f;
            cutsceneState = 2;
        }
    }


    public void AddPlayer(PlayerInput p) 
    {
        if (cutsceneState != 0) return;
        players.Add(p);
        CineCam.AddMember(p.gameObject.transform, 1, 1);
    }

    public void EndGame(WinState state)
    {
        if (cutsceneState != 0) return;
        // * code to switch scenes here *

        //stick ship and players together on pad
        shipProp.transform.position = launchPad.transform.position + (Vector3.up * 1.7f);
        CineCam.AddMember(shipProp.transform, 1, 1);
        foreach (PlayerInput p in players)
        {
            //p.transform.SetParent(shipProp.transform);
            //p.transform.Translate(Vector3.down * 10f);
            p.Stun(999f);
            CineCam.RemoveMember(p.transform);
            p.gameObject.SetActive(false);
        }
        cutsceneState = 1;
        curTime = Time.fixedTime;
    }
}