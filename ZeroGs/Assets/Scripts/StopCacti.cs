using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCacti : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find all GameObjects with the Rock script and stop their movement
            Rock[] rocks = FindObjectsOfType<Rock>();
            foreach (Rock rock in rocks)
            {
                rock.StopMovement();
            }
        }
    }
}
