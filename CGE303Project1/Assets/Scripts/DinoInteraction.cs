using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoInteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby)
        {
            displayDinoPrompt();
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPlayerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerNearby = false;
    }

    private void Interact()
    {
        // initiate foraging mini game here
        Debug.Log("Interacted with object"); //can be deleted

    }

    private void displayDinoPrompt()
    {
        // display items needed to tame dino
    }
}
