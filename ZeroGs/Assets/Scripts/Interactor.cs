using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueTrigger;

interface IInteractable {
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    private Transform InteractorSource;
    public float InteractRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            InteractorSource = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found!");
        }
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)){
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)){
                    interactObj.Interact();
                }
            }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        
        GetComponent<DialogueTrigger>().Interact();
    }
}
