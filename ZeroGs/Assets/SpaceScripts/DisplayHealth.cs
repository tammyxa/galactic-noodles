using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public ShipHealthManager healthManager;

    public Text healthText;


    void Update()
    {
        if (healthText != null && healthManager != null)
        {
            healthText.text = "Health: " + healthManager.GetCurrentHealth();
        }
    }
}
