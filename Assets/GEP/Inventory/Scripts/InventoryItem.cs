using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI")]
    public Image image;
    public Text stackText;

    public Item item;
    public int stackNum = 1;
    public Transform slotAfterDrag;
    public GameObject ItemMenuPrefab;
    public GameObject ItemDescriptionUIPrefab;
    public GameObject ItemDesUI;
   
    public bool selected = false;
    private bool itemDesDisplayed = false;
    private bool inInventory;

    public void InitItem(Item newItem) 
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshStackText();
    }
    public void RefreshStackText() 
    {
        stackText.text = stackNum.ToString();
        bool textActive = stackNum > 1;
        stackText.gameObject.SetActive(textActive);
    }
    public void OnBeginDrag()
    {
        slotAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        stackText.raycastTarget = false;

    }

    public void OnDrag(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        transform.position = pointerData.position;
    }

    public void OnEndDrag()
    {
        transform.SetParent(slotAfterDrag);
        image.raycastTarget = true;
        stackText.raycastTarget = true;
    }

    public void OnPointerClick(BaseEventData data) 
    {
        PointerEventData pointerData = (PointerEventData)data;
        if(pointerData.button == PointerEventData.InputButton.Right) 
        {
            selected = true;
            GameObject newItemMenu = Instantiate(ItemMenuPrefab.gameObject);
            Image buttonList = newItemMenu.GetComponentInChildren<Image>();
            buttonList.transform.position= pointerData.position;
            ItemMenu menu = newItemMenu.GetComponent<ItemMenu>();
            menu.SetItemSelected(this);
            
        }
    }

    public void OnDrop(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        InventorySlot slot = pointerData.pointerDrag.GetComponent<InventorySlot>();

        slotAfterDrag = slot.transform;
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!itemDesDisplayed) 
        {
            ItemDesUI = Instantiate(ItemDescriptionUIPrefab.gameObject);
            ItemDesUI.GetComponent<ItemDescription>().SetItem(item);
            itemDesDisplayed = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemDesDisplayed) 
        {
            Destroy(ItemDesUI);
            itemDesDisplayed = false;
        }
    }
}
