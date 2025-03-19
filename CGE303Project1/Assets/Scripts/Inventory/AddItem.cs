using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] InventoryManager inventory;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.E;

    private bool isInRange;

    private void Update(){
        if (isInRange && Input.GetKeyDown(itemPickupKeyCode)) {
            inventory.AddItem(item);
        }
    }
}
