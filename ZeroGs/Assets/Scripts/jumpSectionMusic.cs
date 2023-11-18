using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpSectionMusic : MonoBehaviour
{
    // The name of the scene to load
    public GameObject fadeOut;
    public AudioSource musicFX;
    public AudioSource BackGroundMusic;
    private bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the player (or has a specific tag)
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger, set the flag to true
            // Check if the music is not playing
            if (!musicFX.isPlaying && BackGroundMusic.isPlaying)
            {
                musicFX.Play(); // Start playing the music if not already playing
                BackGroundMusic.Stop();
            }else{
                musicFX.Stop();
                BackGroundMusic.Play();
            }
        }
    }

    // Use OnTriggerExit to check when the player exits the trigger 
}

