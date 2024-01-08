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

    [SerializeField] private InventoryController inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TryGetComponent<InventoryController>(out inventory))
        {
             if (!inventory.gameObject.activeSelf ) 
            {
                Destroy(gameObject);
            }
        }
        Destroy(gameObject);

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
