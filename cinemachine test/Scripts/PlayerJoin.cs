using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using static PlayerInput;
using static GameMaster;


public class PlayerJoin : MonoBehaviour
{
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    public void OnJoin(UnityEngine.InputSystem.PlayerInput p)
    {
        gm.AddPlayer(p.gameObject.GetComponent<PlayerInput>());


    }
}