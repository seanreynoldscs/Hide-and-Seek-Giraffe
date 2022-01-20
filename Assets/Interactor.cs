using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableMask = 8;

    UnityEvent onInteract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10, interactableMask))
        {
                Debug.Log(hit.collider.name);
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                Debug.Log(hit.collider.name);
                onInteract = hit.collider.GetComponent<Interactable>().onInteract;
                onInteract.Invoke();

                //hit.collider.position = new Position(100,100,100);
            }
        }
    }
}
