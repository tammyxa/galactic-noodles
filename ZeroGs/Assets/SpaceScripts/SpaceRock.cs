using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRock : MonoBehaviour
{
    public int damageAmount = 10;

    public void ApplyDamageToPlayer()
    {
        ShipHealthManager healthManager = FindObjectOfType<ShipHealthManager>();

        if (healthManager != null)
        {
            healthManager.TakeDamage(damageAmount);
        }

        // Make the rock disappear
        Destroy(gameObject);
    }
}
