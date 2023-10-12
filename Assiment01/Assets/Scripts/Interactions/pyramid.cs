using UnityEngine;

public class AutoDissolve : MonoBehaviour
{
    public Material dissolveMaterial;
    public float dissolveSpeed = 0.5f;
    private float dissolveAmount = 0f;
    public float dissolveDuration = 3f; // Time in seconds after which the object starts to dissolve

    void Start()
    {
        InvokeRepeating("TriggerDissolve", dissolveDuration, 0.1f); // Start dissolve after dissolveDuration seconds, repeat every 0.1 seconds
    }

    void TriggerDissolve()
    {
        dissolveAmount += dissolveSpeed * Time.deltaTime;
        dissolveAmount = Mathf.Clamp01(dissolveAmount);
        dissolveMaterial.SetFloat("_DissolveAmount", dissolveAmount);

        if (dissolveAmount >= 1f)
        {
            // Optional: Handle what happens after the object is completely dissolved, e.g., destroy the object
            Destroy(gameObject);
        }
    }
}
