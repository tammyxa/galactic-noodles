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
    public Transform spawnPoint;
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    public void OnJoin(UnityEngine.InputSystem.PlayerInput p)
    {
        gm.AddPlayer(p.gameObject.GetComponent<PlayerInput>());
        
        //if single player, set spawn to that join player
        if (gm.players.Count < 1)
        {
            spawnPoint.SetParent(p.gameObject.transform);
            spawnPoint.localPosition = Vector3.zero;
        }

        //spawn on point
        gm.players[ gm.players.IndexOf(p.gameObject.GetComponent<PlayerInput>()) ].transform.position = spawnPoint.position;
    }
}