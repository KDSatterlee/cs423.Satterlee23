using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 5f;
    public Camera targetCamera; // Assign the camera in the Inspector

    private Vector3 initialPosition;
    private Vector3 targetPositionDown;
    private Vector3 targetPositionUp;
    private bool isMovingDown = false;

    void Start()
    {
        initialPosition = transform.position;
        targetPositionDown = initialPosition - transform.up * moveDistance;
        targetPositionUp = initialPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Toggle between moving down and moving back up
                isMovingDown = !isMovingDown;

                if (isMovingDown)
                {
                    Debug.Log("Clicked on the object. Moving down.");
                }
                else
                {
                    Debug.Log("Clicked on the object. Moving back up.");
                }
            }
        }

        float step = moveSpeed * Time.deltaTime;
        Vector3 targetPosition = isMovingDown ? targetPositionDown : targetPositionUp;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position == targetPosition)
        {
            // Optionally, perform any actions when the object has reached the target position
        }
    }
}
