using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] slots;
    public GameObject InventitemPrefab;
    public GameObject Inevntory;

    public float DropRangeX = 3;
    public float DropRangeZ = 3;

    int selectedSlot = -1;


    public void ChangedSelectedSlot(int newValue) 
    {
        selectedSlot = newValue;
    }

    public bool AddItem(Item item) 
    {
        // Stack items
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i];
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if ((slotItem != null) && (slotItem.item == item) && (slotItem.stackNum < item.MaxStack) && item.stackable)
            {
                slotItem.stackNum++;
                slotItem.RefreshStackText();
                return true;
            }
        }

        //find am empty slot to add 
        for (int i =0; i < slots.Length; i++) 
        {
            InventorySlot slot = slots[i];
            InventoryItem slotItem = slot.GetComponentInChildren<InventoryItem>();
            if(slotItem == null) 
            {
                SpawnItemAtSlot(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnItemAtSlot(Item item, InventorySlot slot) 
    {
        GameObject newItemGO = Instantiate(InventitemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.InitItem(item);
    }

    public Item UseItem()
    {
        ItemMenu itemMenu = FindObjectOfType<ItemMenu>();
        InventoryItem slotItem = itemMenu.item;
        if (slotItem.selected) 
        {
            Item item = slotItem.item;
            slotItem.stackNum--;
            if(slotItem.stackNum <= 0) 
            {
                Destroy(slotItem.gameObject);
            }
            else 
            {
                slotItem.RefreshStackText(); 
            }    
            return item;
        } 
        return null;
    }

    public Item PlaceItem() 
    {
        ItemMenu itemMenu = FindObjectOfType<ItemMenu>();
        InventoryItem slotItem = itemMenu.item;
        if (slotItem.selected)
        {
            Item item = slotItem.item;
            slotItem.stackNum--;
            if (slotItem.stackNum <= 0)
            {
                Destroy(slotItem.gameObject);
            }
            else
            {
                slotItem.RefreshStackText();
            }
            Inevntory.SetActive(false);
            Instantiate(item.Mesh_blueprint);
            return item;
        }
        return null;
    }

    public Item DropItem() 
    {
        ItemMenu itemMenu = FindObjectOfType<ItemMenu>();
        InventoryItem slotItem = itemMenu.item;
        if (slotItem.selected)
        {
            Item item = slotItem.item;
            slotItem.stackNum--;
            if (slotItem.stackNum <= 0)
            {
                Destroy(slotItem.gameObject);
            }
            else
            {
                slotItem.RefreshStackText();
            }
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 playerForward = GameObject.FindGameObjectWithTag("Player").transform.forward;
            Vector3 DropPos = new Vector3(playerPos.x,
                                          playerPos.y + 1,
                                           (float)(playerPos.z + playerForward.z * 0.3));
            Instantiate(item.Mesh, DropPos, item.Mesh.transform.rotation);
            return item;
        }
        return null;
    }

    public Item DropAll() 
    {
        ItemMenu itemMenu = FindObjectOfType<ItemMenu>();
        InventoryItem slotItem = itemMenu.item;
        if (slotItem.selected)
        {
            Item item = slotItem.item;
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 playerForward = GameObject.FindGameObjectWithTag("Player").transform.forward;
            Vector3 DropPos = new Vector3(playerPos.x,
                                          playerPos.y + 1,
                                           (float)(playerPos.z + playerForward.z * 0.3));
            for (int i =0; i < slotItem.stackNum; i++) 
            {
                Instantiate(item.Mesh, DropPos, item.Mesh.transform.rotation);
            }
            slotItem.stackNum = 0;
            Destroy(slotItem.gameObject);
           
            return item;
        }
        return null;
    }
}
