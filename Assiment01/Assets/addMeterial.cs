using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addMeterial : MonoBehaviour
{
    public Material customMaterial;

    void Start()
    {
        GetComponent<Renderer>().material = customMaterial;
    }
}
