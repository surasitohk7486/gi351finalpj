using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Sword,
        Armor,
        HpPotion,
        Wood,
        Stone
    }

    public ItemType itemType;
    public int amount;

    /*public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:

            case ItemType.Sword:return ItemAssets.Instance.swordSprite;
               
            case ItemType.HpPotion: return ItemAssets.Instance.hpPtSprite;
                
            case ItemType.Armor: return ItemAssets.Instance.armorSprite;

            case ItemType.Wood: return ItemAssets.Instance.woodSprite;

            case ItemType.Stone: return ItemAssets.Instance.stoneSprite;

        }
    }*/
}
