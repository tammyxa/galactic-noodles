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
    public void OnJoin(UnityEngine.InputSystem.PlayerInput p)
    {
        GameMaster.players.Add(p.gameObject.GetComponent<PlayerInput>());
    }
}