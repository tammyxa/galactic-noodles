using UnityEngine;

public class PlayerSkinChoice : MonoBehaviour
{
    public Material[] skinMaterials; // Array of different skin materials
    private Renderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();

        // Check if the PlayerPrefs key exists before trying to access it
        if (PlayerPrefs.HasKey("selectedCharacter"))
        {
            // Load the selected skin index
            int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);

            // Ensure the selected index is within bounds
            if (selectedCharacter >= 0 && selectedCharacter < skinMaterials.Length)
            {
                // Apply the selected skin to the player in the next scene
                playerRenderer.material = skinMaterials[selectedCharacter];
            }
            else
            {
                Debug.LogError("Invalid skin index!");
            }
        }
        else
        {
            Debug.LogError("Selected skin information not found in PlayerPrefs!");
        }
    }
}
