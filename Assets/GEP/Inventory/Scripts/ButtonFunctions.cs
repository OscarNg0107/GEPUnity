using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private ItemMenu itemMenu; 

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        itemMenu = FindObjectOfType<ItemMenu>();
    }

    public void UseItem() 
    {
        Item itemUsing = inventoryManager.UseItem();
        itemMenu.CloseItemMenu();
    }

    public void PlaceItem() 
    {
        Item ItemPlacing = inventoryManager.PlaceItem();
        itemMenu.CloseItemMenu();
    }

    public void Dropitem() 
    {
        Item ItemDrop = inventoryManager.DropItem();
        itemMenu.CloseItemMenu();
    }

    public void DropAllItem() 
    {
        Item ItemDrop = inventoryManager.DropAll();
        itemMenu.CloseItemMenu();
    }
}

   
