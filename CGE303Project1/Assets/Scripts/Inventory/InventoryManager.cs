using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItems = 16;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;


    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null &&
            itemInSlot.item == item &&
            itemInSlot.count < maxStackedItems)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }

            if (Input.GetKeyDown(KeyCode.F)) {
            Destroy(itemInSlot);
        }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot == null) 
            {
                SpawnNewItem(item, slot);
                return true; 
            }
        }
        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DraggableItem inventoryItem = newItemGo.GetComponent<DraggableItem>();
        inventoryItem.InitializeItem(item);
    }

    public int findItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null &&
            itemInSlot.item == item)
            {
                return i; // item found in slot i
            }
        }
        return -1; // item not found
    }

    public int findNumItems(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null &&
            itemInSlot.item == item)
            {
                return itemInSlot.count;
            }
        }
        return 0;
    }

    public void RemoveItem(Item item, int num)
    {
        int slotIndex = findItem(item);
        if (slotIndex != -1)
        {
            InventorySlot slot = inventorySlots[slotIndex];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot.count > 1)
            {
                itemInSlot.count -= num;
                itemInSlot.RefreshCount();
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
            }
            else
            {
                Destroy(itemInSlot.gameObject);
            }
        }
    }
}