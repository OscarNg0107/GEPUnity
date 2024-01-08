using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMenu : MonoBehaviour,IPointerExitHandler
{
    public InventoryItem item; 

    public void SetItemSelected(InventoryItem newItem) 
    {
        item = newItem;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CloseItemMenu();
    }

    public void CloseItemMenu() 
    {
        item.selected = false;
        Destroy(gameObject);
    }
}
