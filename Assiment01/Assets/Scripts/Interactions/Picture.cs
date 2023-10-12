using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class Picture : MonoBehaviour, IInterabale
{
    
    [SerializeField] private string _prompt;
    public string InteractPromp => _prompt;
    public int max = 3;

    public int rnd = 0;
    public bool set = false;
    public GameObject Respawn;
    public GameObject Player;
    public Material duck2;
    public Material duck1;

    public bool InterACT(Interactor interactor)
    {

       
        rnd = Random.Range(1, 4);


        if (rnd == 1) {
            Debug.Log("nothing");
        }
        else if (rnd == 2) {
          Player.transform.position = Respawn.transform.position;
        }
        else {
            Debug.Log("CHANGE");
            if (set == false)
            {
                GetComponent<Renderer>().material = duck2;
                set = true;
            }
            else
            {
                GetComponent<Renderer>().material = duck1;
                set = false;
            }
        }
        return true;
    }
}
