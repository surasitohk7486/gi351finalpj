using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CollectItem : MonoBehaviour
    {
        public ItemClass item; // ไอเทมที่จะเก็บ
        public int quantity = 1; // จำนวนไอเทม

        [SerializeField] InventoryManagerNew inventoryManager;

    void Start()
    {
        inventoryManager = GetComponent<InventoryManagerNew>();
    }

    void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                inventoryManager.Add(item,quantity);
            }
        }
    }

