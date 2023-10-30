using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using static PlayerInput;
using static PlayableObject;
using static LaunchPad;
using static MainUiHandler;


public class GameMaster : MonoBehaviour
{
    public MainUiHandler mainUiHandler;
    public LaunchPad launchPad;
    public static List<PlayerInput> players;

    GameMaster()
    {
        players = new List<PlayerInput>();
    }

    public enum WinState {
        WIN,
        LOSE
    };

    void Update()
    {

    }

    public void EndGame(WinState state)
    {
        // * code to switch scenes here *

        //temp endgame
        mainUiHandler.ShowWinState(true);
        Time.timeScale = 0f;
    }
}