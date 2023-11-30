using UnityEngine;

public class WalkthroughBox : MonoBehaviour
{
    public string[] disallowedTags;  // List of tags that are not allowed to walk through

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a tag that is not allowed
        if (!IsTagAllowed(collision.gameObject.tag))
        {
            // Implement your logic here for allowing walkthrough
            GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            // Implement your logic here for disallowing walkthrough
            GetComponent<Collider>().isTrigger = false;
        }
    }

    private bool IsTagAllowed(string tag)
    {
        // Check if the provided tag is in the disallowed tag list
        foreach (string disallowedTag in disallowedTags)
        {
            if (tag == disallowedTag)
            {
                return true;  // Tag is not allowed
            }
        }

        return false;  // Tag is allowed
    }
}
