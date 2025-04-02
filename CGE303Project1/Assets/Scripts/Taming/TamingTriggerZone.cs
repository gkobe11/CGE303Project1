using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamingTriggerZone : MonoBehaviour
{
    public bool isNearby = false;
    public GameObject anchor; // set in inspector
    private TamingGame tamingScript;

    PlayerController playerController; // reference to playerController script

    private void Start()
    {
        tamingScript = anchor.GetComponent<TamingGame>();

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // reference to playerController script
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNearby)
        {
            tamingScript.triggerZones--;
            tamingScript.strikes++;
            gameObject.SetActive(false);

            playerController.PlayOneShot(CollectSound); // plays collect sound
        }
         else if (Input.GetKeyDown(KeyCode.E) && !isNearby)
         {
            playerController.PlayOneShot(MissSound); // plays miss sound (might work)
         }
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
