﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManagerNew : MonoBehaviour
{
    [SerializeField] private List<CraftingClass> crafting = new List<CraftingClass>();
    [SerializeField] private GameObject slotsHolder;

    [SerializeField] private GameObject contextMenu;

    //[SerializeField] private ItemClass itemToAdd;
    //[SerializeField] private ItemClass itemToRemove;

    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;

    [SerializeField] private PlayerController playerController;
    public void Start()
    {
        slots = new GameObject[slotsHolder.transform.childCount];

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;
        }
            RefreshUI();
    }

    private void Update()
    {
        Craft(crafting[0]);

        Craft(crafting[1]);

        Craft(crafting[2]);

        Craft(crafting[3]);
        
    }

    public void RefreshUI()
    {
        for (int i = 0;i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
                
                if (items[i].GetItem().isStackable)
                {
                    slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].GetQuantity() + "";
                }
                else
                {
                    slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                }
               
            }
            catch 
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }
            
        }
    }

    public bool Add(ItemClass item,int quantity)
    {
        Debug.Log("Adding item: " + item.itemName + ", quantity: " + quantity);

        SlotClass slot = Contains(item);
        if (slot != null)
        {
            if (slot.GetItem().isStackable)
            {
                slot.AddQuantity(quantity);
                Debug.Log("Increased quantity of existing item: " + item.itemName);
            }
            else
            {
                items.Add(new SlotClass(item, quantity));
            }
        }
        else
        {
            if (items.Count < slots.Length)
            {
                items.Add(new SlotClass(item, quantity));
                Debug.Log("Added new item: " + item.itemName);
            }
            else
            {
                Debug.LogError("Inventory is full!");
                return false;
            }
        }

        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {
        //items.Remove(item);
        SlotClass temp = Contains(item);
        if(temp != null)
        {
            if(temp.GetQuantity() > 1)
            temp.SubQuantity(1);
            else
            {
                SlotClass slotToRemove = new SlotClass();

                foreach (SlotClass slot in items)
                {
                    if (slot.GetItem() == item)
                    {
                        temp = slot;
                        break;
                    }
                }

                items.Remove(slotToRemove);
            }
        }
        else
        {
            return false;
        }

      
        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item,int quantity)
    {
        //items.Remove(item);
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            
            temp.SubQuantity(quantity);

            // ลบ Slot หาก Quantity <= 0
            if (temp.GetQuantity() <= 0)
            {
                items.Remove(temp);
            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if(slot.GetItem() == item)
            {
                return slot;
            }
        }
            return null;
    }

    public bool Contains(ItemClass item,int quantity)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetItem() == item && items[i].GetQuantity() >= quantity)
            {
                return true;
            }
        }


        return false;
    }

    private void Craft(CraftingClass recipe)
    {
        if (recipe.CanCrafting(this))
        { 
            if(recipe == crafting[0])
            {
                playerController.Hp += 10; 
                Debug.Log("Crafting Armor HP increased.");
            }
            else if(recipe == crafting[1])
            {
                playerController.Atk += 5; 
                Debug.Log("Crafting Sword HP increased.");
            }
            else if (recipe == crafting[2])
            {
                playerController.Hp += 1; 
                Debug.Log("Crafting HealthPotion HP increased.");
            }
            else if (recipe == crafting[3])
            {
                playerController.hasKey = true;
            }
            recipe.Craft(this);
        }
    }
}
