using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPlacement : MonoBehaviour
{
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* PointerEventData pointerData = (PointerEventData)data;
         Ray ray = Camera.main.ScreenPointToRay(pointerData.position);
         if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
         {
             transform.position = raycastHit.point;
         }

         if ((pointerData.button == PointerEventData.InputButton.Left))
         {
             Instantiate(itemPrefab, transform.position, transform.rotation);
             Destroy(gameObject);
         }*/
    }

    /*public void ItemPlacing(BaseEventData data) 
    {
        Debug.Log("hi");
        PointerEventData pointerData = (PointerEventData)data;
        Ray ray = Camera.main.ScreenPointToRay(pointerData.position);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            transform.position = raycastHit.point;
        } 
    }

    public void ItemPlace(BaseEventData data) 
    {
        Debug.Log("Hi");
        PointerEventData pointerData = (PointerEventData)data; 
        
        if (pointerData.button == PointerEventData.InputButton.Left)
        {
            Instantiate(itemPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }*/
}
