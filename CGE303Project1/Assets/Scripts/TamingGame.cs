using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TamingGame : MonoBehaviour
{
    public int speed; //set in inspector
    public int triggerZones; //set in inspector
    private int startTriggerZones;
    public int strikes = 3;

    private DinoInteraction dinoScript; 

    public GameObject tamingGame; //set in inspector
    public GameObject dinoTriggerZone; //set in inspector

    public TMP_Text textBox; //set in inspector

    // Start is called before the first frame update
    void Start()
    {
        dinoScript = dinoTriggerZone.GetComponent<DinoInteraction>();
        startTriggerZones = triggerZones;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        textBox.text = "Strikes: " + strikes;
        if (triggerZones <= 0)
        {
            dinoScript.isTamed = true;
            dinoScript.isTaming = false;

            // take all items from player
            
            textBox.text = "You tamed the dino!";

            triggerZones = startTriggerZones;
            tamingGame.SetActive(false);
        }
        else if (strikes <= 0)
        {
            dinoScript.isTamed = false;
            dinoScript.isTaming = false;
            strikes = 3;

            // give player half of items back

            textBox.text = "You failed to tame the dino! Better luck next time!";

            triggerZones = startTriggerZones;
            tamingGame.SetActive(false);
        }
    }
}
