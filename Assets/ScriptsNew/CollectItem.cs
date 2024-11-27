using Searching;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : Identity
{
    public ItemClass item; // ไอเทมที่จะเก็บ
    public int quantity = 1; // จำนวนไอเทม
    public int endurance = 100;

    [SerializeField] InventoryManagerNew inventoryManager;

    void Start()
    {
        if (inventoryManager == null)
        {
            inventoryManager = FindObjectOfType<InventoryManagerNew>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collided with item: " + item.itemName);
            if (inventoryManager != null)
            {
                inventoryManager.Add(item, quantity);
                endurance -= 10;
                
                if (endurance <= 0)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("InventoryManager is null!");
            }
        }
    }
}

