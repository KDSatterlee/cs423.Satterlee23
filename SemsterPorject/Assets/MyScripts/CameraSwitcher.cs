using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;  // An array to hold your cameras
    private int currentCameraIndex = 0;

    void Start()
    {
        // Disable all cameras except the first one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check for a key press to switch cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Disable the current camera
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Move to the next camera index
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Enable the new current camera
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }
    }
}
