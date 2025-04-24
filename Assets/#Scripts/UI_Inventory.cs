using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private InventorySlot[] slots;
    public void Refresh(IReadOnlyList<ItemInstance> items)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                Debug.Log($"[UI_Inventory] Slot {i} set to {items[i].Template.Icon}");
                slots[i].SetItem(items[i]);
                
            }
            else slots[i].Clear();
        }
    }
}
