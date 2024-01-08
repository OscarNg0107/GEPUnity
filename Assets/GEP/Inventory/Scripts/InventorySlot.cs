using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public void OnDrop(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        if (transform.childCount == 0) 
        {
            if(pointerData.pointerDrag.TryGetComponent<InventoryItem>(out InventoryItem inventoryItem)) 
            {
                inventoryItem.slotAfterDrag = transform;
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
