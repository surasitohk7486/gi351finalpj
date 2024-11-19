using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform itemSlot,itemSlotTp;

    private void Awake()
    {
        itemSlot = transform.Find("ItemSlot");
        itemSlotTp = itemSlot.Find("ItemSlotTp");
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 120f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTp,itemSlot).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            //image.sprite = item.GetSprite();

            x++;
            if(x > 4 )
            {
                x = 0 ; y++;
            }
        }
    }
}
