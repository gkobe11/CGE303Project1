using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamingTriggerZone : MonoBehaviour
{
    public bool isNearby = false;
    public GameObject anchor; // set in inspector
    private TamingGame tamingScript;

    public bool hitTarget = false; // checks if the target is hit
    public TamingTriggerZoneManager manager; // assign in inspector
    // PlayerController playerController; // reference to PlayerController script

    private void Start()
    {
        tamingScript = anchor.GetComponent<TamingGame>();

        if (manager == null)
        {
            manager = FindObjectOfType<TamingTriggerZoneManager>();
        }

        // playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // reference to PlayerController script
    }

    private void Update()
    {
        // hitTarget = false;

        if (Input.GetKeyDown(KeyCode.E) && isNearby)
        {
            tamingScript.triggerZones--;
            tamingScript.strikes++;
            gameObject.SetActive(false);

            hitTarget = true;
            manager.OnPlayerInput(true); // success
            // playerController.PlayCollectSound(); // plays collect sound
        }
        else if (Input.GetKeyDown(KeyCode.E) && hitTarget == false)
        {
            // hitTarget = false;
            manager.OnPlayerInput(false); // fail
        }
        /* else if (Input.GetKeyDown(KeyCode.E) && !isNearby)
        {
            playerController.PlayMissSound(); // plays miss sound
        } */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rotator")
        {
            isNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rotator")
        {
            isNearby = false;
        }
    }
}
