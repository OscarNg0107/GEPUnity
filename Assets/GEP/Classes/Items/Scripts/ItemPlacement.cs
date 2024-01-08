using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

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
         /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
         {
             transform.position = raycastHit.point;
         }*/
    }

    public void ItemPlace()
    {
        Instantiate(itemPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
