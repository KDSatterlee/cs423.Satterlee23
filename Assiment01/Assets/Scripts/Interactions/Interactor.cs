using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float  _interactionPointRad = 0.5f;
    [SerializeField] private LayerMask _interactionMask;

    private readonly Collider[] _conlider = new Collider[3];
    [SerializeField] private int _numFound;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRad, _conlider, _interactionMask);
        if (_numFound > 0){
            var interacable = _conlider[0].GetComponent<IInterabale>();

            if (interacable != null && Keyboard.current.eKey.wasPressedThisFrame) {

                interacable.InterACT(this);
            }
           
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRad);
    }
}
