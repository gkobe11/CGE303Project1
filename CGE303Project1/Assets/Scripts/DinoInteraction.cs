using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoInteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;
    public bool isTamed = false;
    public bool isTaming = false;

    public GameObject dino; // set in inspector
    public GameObject dinoTextBox; // set in inspector
    public GameObject tamingGame; // set in inspector


    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !isTamed &!isTaming)
        {
            Interact();
        }

        if (isTamed)
        {
            dino.GetComponent<BoxCollider2D>().enabled = false; //allow player to walk through dino
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPlayerNearby = true;
        if (!isTamed) { 
            dinoTextBox.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerNearby = false;
        if (!isTamed)
        {
            dinoTextBox.SetActive(false);
        }
    }

    private void Interact()
    {
        dinoTextBox.SetActive(false);
        isTaming = true;
        //check if player has enough items to start taming
        tamingGame.SetActive(true); //start taming mini game
    }
}
