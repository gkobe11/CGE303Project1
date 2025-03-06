using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;
    public GameObject objectTextBox; // set in inspector


    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPlayerNearby = true;
        objectTextBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerNearby = false;
        objectTextBox.SetActive(false);
    }

    private void Interact()
    {
        // initiate foraging mini game here
        Debug.Log("Interacted with object"); //can be deleted

    }
}
