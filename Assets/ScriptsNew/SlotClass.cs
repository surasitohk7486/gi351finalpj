using System.Collections;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
    [SerializeField] private ItemClass item;
    [SerializeField] private int quantity;

    private bool isSlotEmpty = true; // ตัวแปรตรวจสอบว่าว่างหรือไม่

    public SlotClass()
    {
        
        quantity = 0;
    }

    public SlotClass(ItemClass _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }

    public ItemClass GetItem() { return item; }

    public void SetItem(ItemClass newItem)
    {
        if (newItem != null)
        {
            item = newItem;
            isSlotEmpty = false; // ตั้งค่าช่องเป็นไม่ว่าง
        }
        else
        {
            item = null;
            isSlotEmpty = true; // ตั้งค่าช่องเป็นว่าง
        }
    }

    public bool IsSlotEmpty()
    {
        return isSlotEmpty;
    }

    public bool IsSword()
    {
        return item is ToolClass && ((ToolClass)item).toolType == ToolClass.ToolType.Sword;
    }

    public bool IsArmor()
    {
        return item is ToolClass && ((ToolClass)item).toolType == ToolClass.ToolType.Armor;
    }

    public void SetQuantity(int newQuantity)
    {
        quantity = newQuantity;
    }

    public int GetQuantity() { return quantity; }
    public void AddQuantity(int _quantity) { quantity += _quantity; }
    public void SubQuantity(int _quantity) { quantity -= _quantity; }
}
