using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    private InventoryItem childInvent;
    public void OnDrop(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        if (transform.childCount == 0) 
        {
            if(pointerData.pointerDrag.TryGetComponent<InventoryItem>(out InventoryItem inventoryItem)) 
            {
                inventoryItem.slotAfterDrag = transform;
                childInvent = inventoryItem;
            }
        }
        else 
        {   
            childInvent = gameObject.GetComponentInChildren<InventoryItem>();
            if (pointerData.pointerDrag.TryGetComponent<InventoryItem>(out InventoryItem inventoryItem))
            {
                if (childInvent.item.itemName == inventoryItem.item.itemName) 
                {
                    childInvent.stackNum += inventoryItem.stackNum;
                    if(childInvent.stackNum > childInvent.item.MaxStack) 
                    {
                        inventoryItem.stackNum = childInvent.stackNum - childInvent.item.MaxStack;
                        childInvent.stackNum = childInvent.item.MaxStack;
                    }
                    else 
                    {
                        Destroy(inventoryItem);
                    }
                    childInvent.RefreshStackText();


                }    
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
