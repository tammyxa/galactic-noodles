using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform SpawnPoint; // Reference to the spawn point's transform component.

    public float moveSpeed = 5.0f; // Speed of the movement.

    private void Update()
    {
        if (SpawnPoint != null)
        {
            // Move this GameObject's transform to the spawn point's position.
            transform.position = Vector3.MoveTowards(transform.position, SpawnPoint.position, moveSpeed * Time.deltaTime);
        }
    }
}
