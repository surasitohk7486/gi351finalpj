using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Crafting : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI swordText;
    [SerializeField] private TextMeshProUGUI armorText;
    [SerializeField] private TextMeshProUGUI hpPtText;

    private void Start()
    {
        UpdateResourceUI(); // อัปเดตค่าเริ่มต้น
    }

    // Generalized crafting method
    private void CraftItem(int woodRequired, int stoneRequired, string itemName, ref int itemCount)
    {
        if ((playerController.wood >= woodRequired) && (playerController.stone >= stoneRequired))
        {
            playerController.wood -= woodRequired;
            playerController.stone -= stoneRequired;
            itemCount += 1;

            Debug.Log($"Craft {itemName} Success!!!");
            UpdateResourceUI(); // อัปเดต UI หลังจากคราฟต์สำเร็จ
        }
        else
        {
            Debug.Log("Can't Craft");
        }
    }

    // Public methods for specific items, allowing them to be linked to UI buttons
    public void CraftSword()
    {
        CraftItem(3, 5, "Sword", ref playerController.sword);
    }

    public void CraftArmor()
    {
        CraftItem(2, 7, "Armor", ref playerController.armor);
    }

    public void CraftHealthPotion()
    {
        CraftItem(1, 1, "Health Potion", ref playerController.hpPt);
    }

    public void UpdateResourceUI()
    {
        // ตรวจสอบว่า PlayerController ถูกตั้งค่าไว้หรือไม่
        if (playerController == null)
        {
            Debug.LogWarning("PlayerController not assigned to UI_ResourceDisplay.");
            return;
        }

        // อัปเดตค่าใน UI Text แต่ละตัว
        woodText.text = $"{playerController.wood}";
        stoneText.text = $"{playerController.stone}";
        swordText.text = $"{playerController.sword}";
        armorText.text = $"{playerController.armor}";
        hpPtText.text = $"{playerController.hpPt}";
    }

}
