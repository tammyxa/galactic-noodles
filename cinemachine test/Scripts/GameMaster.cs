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
    public CinemachineTargetGroup CineCam;
    public MainUiHandler mainUiHandler;
    public LaunchPad launchPad;
    public List<PlayerInput> players;

    GameMaster()
    {
        players = new List<PlayerInput>();
    }

    void Start()
    {
        //CineCam = GameObject.Find("TargetGroup").GetComponent<CinemachineTargetGroup>();
    }

    public enum WinState {
        WIN,
        LOSE
    };

    void Update()
    {

    }


    public void AddPlayer(PlayerInput p) 
    {
        players.Add(p);
        CineCam.AddMember(p.gameObject.transform, 1, 1);
    }

    public void EndGame(WinState state)
    {
        // * code to switch scenes here *

        //temp endgame
        mainUiHandler.ShowWinState(true);
        Time.timeScale = 0f;
    }
}