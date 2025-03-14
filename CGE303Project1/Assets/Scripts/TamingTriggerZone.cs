using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamingTriggerZone : MonoBehaviour
{
    private bool isNearby = false;
    public GameObject anchor; // set in inspector
    private TamingGame tamingScript;


    private void Start()
    {
        tamingScript = anchor.GetComponent<TamingGame>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isNearby)
            {
                tamingScript.triggerZones--;
                Destroy(gameObject);
            }
            else
            {
                tamingScript.strikes--;
            }
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
