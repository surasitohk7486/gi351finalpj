using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crafting",menuName = "Crafting/Recipe")]
public class CraftingClass : ScriptableObject
{
    [Header("Crafting Recipe")]
    public List<SlotClass> inputItems;
    public SlotClass outputItems;

    public bool CanCrafting(InventoryManagerNew inventory)
    {
        bool canCraft = true;

        for (int i = 0;i < inputItems.Count;i++)
        {
            if (!inventory.Contains(inputItems[i].GetItem(), inputItems[i].GetQuantity()))
            {
                return false;
            }
        }
        return true;
    }

    public void Craft(InventoryManagerNew inventory)
    {
        //remove the input items from the inventory
        for (int i = 0; i < inputItems.Count; i++)
        {
            inventory.Remove(inputItems[i].GetItem(), inputItems[i].GetQuantity());
        }

        //add the output item to the inventory
        inventory.Add(outputItems.GetItem(), outputItems.GetQuantity());
    }
}
