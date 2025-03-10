using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoInteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;
    private bool isTamed = false;

    public GameObject dino; // set in inspector
    public GameObject dinoTextBox; // set in inspector



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
        dinoTextBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerNearby = false;
        dinoTextBox.SetActive(false);
    }

    private void Interact()
    {
        // initiate foraging mini game here
        Debug.Log("Interacted with object"); //can be deleted




        // if player successfully tames dino
        isTamed = true;
        dino.GetComponent<BoxCollider2D>().enabled = false;
    }


}
