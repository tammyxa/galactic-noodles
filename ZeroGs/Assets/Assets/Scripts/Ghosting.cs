using UnityEngine;
using System.Collections;

public class GhostlyRock : MonoBehaviour
{
    public float timeToGhost = 2f; // Time before the rock starts becoming ghostly
    public float fadeDuration = 1f; // Time it takes for the rock to become completely transparent

    private Material rockMaterial;
    private Color originalColor;

    void Start()
    {
        rockMaterial = GetComponent<Renderer>().material;
        originalColor = rockMaterial.color;

        Invoke("StartGhosting", timeToGhost);
    }

    void StartGhosting()
    {
        // Gradually change the transparency of the material
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f); // Adjust alpha as needed

        while (elapsedTime < fadeDuration)
        {
            rockMaterial.color = Color.Lerp(originalColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
