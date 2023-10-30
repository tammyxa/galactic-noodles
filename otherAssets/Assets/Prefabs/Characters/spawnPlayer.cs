using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint; // Reference to the spawn point object.

    public float moveSpeed = 5.0f; // Speed of the movement.

    private void Update()
    {
        if (spawnPoint != null)
        {
            // Move this GameObject's transform to the spawn point's position.
            transform.position = Vector3.MoveTowards(transform.position, spawnPoint.position, moveSpeed * Time.deltaTime);
        }
    }
}