using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))] // Ensures that a Rigidbody component is attached to the GameObject
public class MyMovement : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space; // Customizable input key to toggle movement
    public float moveSpeed = 5f; // Speed at which the NPC moves
    private bool isMoving = false;
    private Animation myAnimation;
    private bool hasWon = false;


    private Rigidbody rb; // Reference to the Rigidbody component

    public Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the GameObject
        rb.freezeRotation = true; // Prevent the Rigidbody from rotating and falling over

        initialPosition = transform.position;
        myAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        // Check for customizable input key to toggle movement
        if (Input.GetKeyDown(toggleKey))
        {
            if (isMoving == false) {
                isMoving = true;
                myAnimation.Play("Run");

            }
            else if(isMoving == true)
            {
                isMoving = false;
                myAnimation.Play();
                myAnimation.Play("idle");
            }
           
        }

        // Move the NPC if isMoving is true
        if (isMoving == true)
        {
            // Calculate NPC's movement based on its local forward direction
            Vector3 movement = transform.forward * moveSpeed * Time.deltaTime;

            // Move the NPC forward
            rb.MovePosition(transform.position + movement);


        }
    }

    // Detect collision with a wall
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall2"))
        {
            ReverseDirection();
        }
        if (collision.gameObject.CompareTag("Wall3")) {
            RotateAround();
        }
        if (collision.gameObject.CompareTag("Wall4"))
        {
            RotateAround2();
        }

        if (collision.gameObject.CompareTag("Enemy")) {
            Respawn();
        }

        if (collision.gameObject.CompareTag("Win") && !hasWon)
        {
            // The character has hit the winning object
            Debug.Log("You win!");
            hasWon = true;

            // Add any additional win-related actions here
            Victory.score = Victory.score + 1;
        }
    }
        void RotateAround() {
            transform.Rotate(Vector3.up, 90f);
        }
        void RotateAround2()
    {
        transform.Rotate(Vector3.down, 90f);
    }
    void ReverseDirection()
        {
            // Reverse the NPC's forward direction
            transform.forward = -transform.forward;
        }

    void Respawn() {
        transform.position = initialPosition;
    }
    
}
