using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractUIPrompt interactUIPrompt;
    [SerializeField] private GameObject inventory;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numOfCollidersFound;

    private IInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numOfCollidersFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (numOfCollidersFound > 0) 
        {
            if (!inventory.activeSelf) 
            {
                interactable = colliders[0].GetComponent<IInteractable>();

            if(interactable != null) 
            {
                if (!interactUIPrompt.isDisplayed) 
                {
                    interactUIPrompt.SetText(interactable.InteractPrompt);
                }
                if (Keyboard.current.eKey.wasPressedThisFrame) 
                {
                    interactable.Interact(this);    
                }
                
            }
            }
            
        }

        else 
        {
            if(interactable!= null) 
            {
                interactable = null;
            }

            if (interactUIPrompt.isDisplayed) 
            {
                interactUIPrompt.Close();
            }
        }

        if (inventory.activeSelf) 
        {
            interactUIPrompt.Close();
        }
    }

   /* void OnCollisionEnter(Collision collision)
    {
        IPickupable pickupable = collision.gameObject.GetComponent<IPickupable>();
        if (pickupable != null)
        {
            pickupable.Pickup();
        }
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
