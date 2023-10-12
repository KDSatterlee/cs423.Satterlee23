using UnityEngine;
using UnityEngine.UI;

public class ImageChangeOnClick : MonoBehaviour
{
    public Sprite newImage; // Drag your new image sprite to this variable in the inspector
    private Image imageComponent;

    private void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse click hits this object
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Change the image
                imageComponent.sprite = newImage;
            }
        }
    }
}
