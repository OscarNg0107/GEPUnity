using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IPickupable, IInteractable
{
    public Item itemType;
    public string promptString;
    private InventoryManager inventoryManager;
    public void Pickup()
    {
        bool inventHasFreeSpace = inventoryManager.AddItem(itemType);
        if (inventHasFreeSpace) 
        {
            Destroy(gameObject);
        }
    }

    public string InteractPrompt => promptString;

    public bool Interact(PlayerInteraction interactor)
    {
        Pickup();
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
