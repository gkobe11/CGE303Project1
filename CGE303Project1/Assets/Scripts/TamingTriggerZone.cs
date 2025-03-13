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
        if (isNearby && Input.GetKeyDown(KeyCode.E))
        {
            tamingScript.triggerZones--;
            Destroy(gameObject);
        }
        else if (!isNearby && Input.GetKeyDown(KeyCode.E))
        {
            tamingScript.strikes--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isNearby = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearby = false;
    }
}
