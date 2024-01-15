using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemWeight;
    [SerializeField] private Text itemDescript;
    [SerializeField] private Image description_border;

    private InventoryController inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindAnyObjectByType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        description_border.transform.position = Mouse.current.position.ReadValue();
        //description_border.transform.position = new Vector3(Mouse.current.position.ReadValue().x - 10, Mouse.current.position.ReadValue().y, 0);
        if (!inventory.gameObject.activeSelf ) 
        {
            Destroy(gameObject);
        } 
    }

    public void SetItem(Item item) 
    {
        gameObject.SetActive(true);
        itemImage.sprite = item.image;
        itemName.text = item.itemName;
        itemWeight.text = item.weight.ToString();
        itemDescript.text = item.desciption;
    }

    public void Close() 
    {
        gameObject.SetActive(false);
    }
}
