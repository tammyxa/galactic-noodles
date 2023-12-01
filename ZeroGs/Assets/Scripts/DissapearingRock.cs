using UnityEngine;

public class DisappearingRock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Wait for 1 second, then call the Fall method
            Invoke("Fall", 1f);
        }
    }

    private void Fall()
    {
        // Perform actions when the rock falls (e.g., deactivate the rock)
        gameObject.SetActive(false);
    }
}
