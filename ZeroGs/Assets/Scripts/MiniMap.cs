using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = player.position;
        newPos.y = transform.position.y;

        transform.position = newPos;
    }
}
