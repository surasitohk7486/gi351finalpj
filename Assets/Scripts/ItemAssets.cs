using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite swordSprite;
    public Sprite armorSprite;
    public Sprite hpPotionSprite;
    public Sprite woodSprite;
    public Sprite stoneSprite;
}
