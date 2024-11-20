using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;
    public GameObject inventoryUI; // UI ที่แสดงรายการไอเท็ม
    public Transform itemSlotContainer; // ตำแหน่งที่แสดง Slot ไอเท็ม
    public GameObject itemSlotPrefab;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        UpdateUI();
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    private void UpdateUI()
    {
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in itemList)
        {
            GameObject slot = Instantiate(itemSlotPrefab, itemSlotContainer);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = $"{item.itemType} x{item.amount}";
        }
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in itemList)
        {
            GameObject slot = Instantiate(itemSlotPrefab, itemSlotContainer);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = $"x{item.amount}";

            // อัปเดต Sprite ใน Slot
            Image icon = slot.transform.Find("Icon").GetComponent<Image>();
            icon.sprite = item.GetSprite();
        }
    }
}
