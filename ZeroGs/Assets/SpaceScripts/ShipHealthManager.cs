using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth = 100;
    public GameObject levelControl;
    public AudioSource hitFX;

    void Start()
    {
          currentHealth = maxHealth;
    }

        public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hitFX.Play();

        if(currentHealth<=0){
            
            levelControl.GetComponent<EndRunSequence>().enabled = true;
        }
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        

    }

        public int GetCurrentHealth()
    {
        return currentHealth;
    }
}


