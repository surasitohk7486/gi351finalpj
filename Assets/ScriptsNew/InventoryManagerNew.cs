using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerNew : MonoBehaviour
{
    [SerializeField] private GameObject slotsHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;
    public void Start()
    {
        slots = new GameObject[slotsHolder.transform.childCount];

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;
        }

        RefreshUI();
       
        Add(itemToAdd);
        Remove(itemToRemove);
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
    public bool Add(ItemClass item)
    {
        //items.Add(item);
        //check if inventory contains item


        SlotClass slot = Contains(item);
        if(slot != null && slot.GetItem().isStackable)
        {
            slot.AddQuantity(1);
        }
        else
        {
            Debug.Log("num items: " + items.Count);
            Debug.Log("inven size: " + slots.Length);
            if (items.Count < slots.Length)
            {
                items.Add(new SlotClass(item, 1));
            }
            else
            {
                return false;
            }
        }

        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {
        //items.Remove(item);
        SlotClass temp = new SlotClass();
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
}
