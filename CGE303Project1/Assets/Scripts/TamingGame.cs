using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamingGame : MonoBehaviour
{
    public int speed; //set in inspector
    public int triggerZones; //set in inspector
    public int strikes = 3;

    private DinoInteraction dinoScript; //set in inspector

    public GameObject tamingGame; //set in inspector
    public GameObject dinoTriggerZone; //set in inspector

    // Start is called before the first frame update
    void Start()
    {
        dinoScript = dinoTriggerZone.GetComponent<DinoInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        if (triggerZones == 0)
        {
            dinoScript.isTamed = true;
            dinoScript.isTaming = false;

            // take all items from player
            // win screen

            tamingGame.SetActive(false);
        }
        else if (strikes <= 0)
        {
            dinoScript.isTamed = false;
            dinoScript.isTaming = false;
            strikes = 3;

            // give player half of items back
            // lose screen

            tamingGame.SetActive(false);
        }
    }
}
