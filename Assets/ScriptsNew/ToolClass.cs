using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Tool")]
public class ToolClass : ItemClass
{
    [Header("Tool")]
    public ToolType toolType;
    public int statValue = 10;
    public enum ToolType
    {
        Sword,
        Armor
    }
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return this; }
    public override MiscClass GetMisc() { return null; }
    public override ConsumableClass GetConsumable() { return null; }
}
