using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> inventoryItems;

    private void Start()
    {
        inventoryItems = new List<InventorySlot>();
    }

    public void AddItem(ItemBase item, int count = 1)
    {
        if (item.CanStack)
        {
            var slot = FindItem(item);
            if (slot != null) slot.count += count;
            else inventoryItems.Add(new InventorySlot(item, count));
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                inventoryItems.Add(new InventorySlot(item));
            }
        }
        Debug.Log("Added " + count + " " + item.ItemName + " to inventory");
    }

    public void RemoveItem(ItemBase item, int count = 1)
    {
        var slot = FindItem(item);
        if (slot == null) return;

        if (slot.count > count) slot.count -= count;
        else if (slot.count == count) inventoryItems.Remove(slot);
        else
        {
            //Continue to remove until no more items or count is reduced to 0
            while(slot != null && count > 0)
            {
                count -= slot.count;
                inventoryItems.Remove(slot);
                slot = FindItem(item);
            }
        }
        Debug.Log("Removed " + item.ItemName + " to inventory");
    }

    private InventorySlot FindItem(ItemBase item)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].item == item) return inventoryItems[i];
        }
        return null;
    }
}
