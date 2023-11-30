using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NPCController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the NPC moves
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Calculate NPC's movement based on its local forward direction
        Vector3 movement = transform.forward * moveSpeed * Time.deltaTime;

        // Move the NPC forward
        rb.MovePosition(transform.position + movement);
    }

    // Detect collision with a wall
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reflect the NPC's forward direction when it hits a wall
            ReflectDirection();
        }
        if (collision.gameObject.CompareTag("Wall2"))
        {
            // Reflect the NPC's forward direction when it hits a wall
            ReflectDirection();
        }
    }

    void ReflectDirection()
    {
        // Reflect the NPC's forward direction
        transform.forward = -transform.forward;
    }
}
