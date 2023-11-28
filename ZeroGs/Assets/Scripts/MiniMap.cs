using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] Transform playerPrefab;  
    private Transform playerInstance;  

    void Start()
    {
        playerInstance = Instantiate(playerPrefab, new Vector3(-6.58f, 22f, -4.62f), Quaternion.identity);
    }


    void Update()
    {
        if (playerInstance != null)
        {
            Vector3 newPos = playerInstance.position;
            newPos.y = transform.position.y;

            transform.position = newPos;
        }
    }
}
