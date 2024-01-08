using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicChestInventory : MonoBehaviour
{
    public GameObject slotPrefab;
    public Chest chest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignSlot() 
    {
        ClearSlot();

        for(int i = 0; i< chest.slotSize; i++) 
        {
            var uiSlot = Instantiate(slotPrefab, transform);
        }
    }

    private void ClearSlot() 
    {
        foreach(var item in transform.Cast<Transform>()) 
        {
            Destroy(item.gameObject);
        }
    }
}
