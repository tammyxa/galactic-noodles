using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    public Vector3 checkpointPosition;  // Made public for manual setting in the Unity Editor



    public void ResetPlayerPosition()
    {
        // Reset the player to the checkpoint position
        transform.position = checkpointPosition;



        // Print a message to the console
        Debug.Log("Player position and state reset to checkpoint.");
    }
}
