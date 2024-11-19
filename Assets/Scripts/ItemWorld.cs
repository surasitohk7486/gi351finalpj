using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position,Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position,Quaternion.identity);

        ItemWorld itemworld = transform.GetComponent<ItemWorld>();
        itemworld.SetItem(item);

        return itemworld;
    }
    private Item item;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        //spriteRenderer.sprite = item.GetSprite();
    }
}
