using UnityEngine;

public class Rock : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDistance = 5f;
    public int damage = 10;
    public float startDelay = 0f;

    private bool movingRight = true;
    private Vector3 initialPosition;

    private bool isMoving = false;

    void Start()
    {
        initialPosition = transform.position;
        Invoke("StartRockMovementWithDelay", startDelay);
    }

    void StartRockMovementWithDelay()
    {
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            MoveRock();
        }
    }

    void MoveRock()
    {
        float movement = moveSpeed * Time.deltaTime;

        if (movingRight)
        {
            transform.Translate(Vector3.right * movement);

            if (transform.position.x >= initialPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * movement);

            if (transform.position.x <= initialPosition.x)
            {
                movingRight = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle player collision (e.g., deal damage)

            // Destroy the rock upon collision with the player
            Destroy(gameObject);
        }
    }
}
