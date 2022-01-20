using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    // Start is called before the first frame update
    void Start()
    {
        if( onInteract == null){
            onInteract = new UnityEvent();
        }
        onInteract.AddListener(SetPosition);
        // self.position = new Position(100, 100, 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(){
        SumScore.Add(1);
        transform.position = new Vector3(Random.Range(-75, 75), 0, Random.Range(-75, 75));
        Debug.Log("HERE");
    }
}
