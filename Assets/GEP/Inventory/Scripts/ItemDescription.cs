using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemWeight;
    [SerializeField] private Text itemDescript;

    [SerializeField] private GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inventory.activeSelf) 
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
