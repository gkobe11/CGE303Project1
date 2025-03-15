using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public void AddItem (Item item) {

        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot == null) {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    void SpawnNewItem(Item item, InventorySlot slot) {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DraggableItem inventoryItem = newItemGo.GetComponentInChildren<DraggableItem>();
        inventoryItem.InitializeItem(item);
    }
}