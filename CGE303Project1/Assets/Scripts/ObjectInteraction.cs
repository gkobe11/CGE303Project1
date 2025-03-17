using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;
    public GameObject objectTextBox; // set in inspector
    [SerializeField] Item item;
    [SerializeField] InventoryManager inventory;

    public GameObject slider;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            objectTextBox.SetActive(false);
            Interact();
            //inventory.AddItem(item);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerNearby = true;
            objectTextBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerNearby = false;
            objectTextBox.SetActive(false);
        }
    }

    private void Interact()
    {
        // initiate foraging mini game here
        //Debug.Log("Interacted with object"); //can be deleted

        //PowerMeterSlider.SetActive(true);

        slider.SetActive(true); // make the powerSlider visible

          
    }
}
