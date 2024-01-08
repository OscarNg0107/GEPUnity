using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ItemPlacement : MonoBehaviour
{
    public GameObject itemPrefab;

    public void ItemPlace()
    {
        Instantiate(itemPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
