using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    // The name of the scene to load
    public PlayerSpaceShip player;

    public GameObject fadeOut;
    // OnTriggerEnter is called when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the player (or has a specific tag)
        if (other.CompareTag("Player"))
        {   
            player.speed = 0;
            // Change the scene
            fadeOut.SetActive(true);
            Invoke("ChangeScene", 2.5f);
        }
    }

        private void ChangeScene()
    {
       

        SceneManager.LoadScene(2);
    }
}
