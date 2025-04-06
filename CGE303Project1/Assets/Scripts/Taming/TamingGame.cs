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
    public TMP_Text bestiaryNotification; //set in inspector

    PlayerController playerController; // reference to playerController script

    [SerializeField] Item item1;
    [SerializeField] Item item2;
    [SerializeField] Item item3;
    [SerializeField] InventoryManager inventory;

    // Start is called before the first frame update
    void Start()
    {
        dinoScript = dinoTriggerZone.GetComponent<DinoInteraction>();
        startTriggerZones = triggerZones;

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // reference to playerController script
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
            if (item1 != null)
            {
                inventory.RemoveItem(item1, dinoScript.itemCount);
            }
            if (item2 != null)
            {
                inventory.RemoveItem(item2, dinoScript.itemCount);
            }
            if (item3 != null)
            {
                inventory.RemoveItem(item3, dinoScript.itemCount);
            }


            textBox.text = "You tamed the dino!";

            StartCoroutine(ShowMessage("Bestiary Updated!", 2));

            playerController.PlayWinSound(); // plays win sound

            triggerZones = startTriggerZones;
            tamingGame.SetActive(false);
        }
        else if (strikes <= 0)
        {
            dinoScript.isTamed = false;
            dinoScript.isTaming = false;
            strikes = 3;

            // give player half of items back
            if (item1 != null)
            {
                inventory.RemoveItem(item1, dinoScript.itemCount / 2);
            }
            if (item2 != null)
            {
                inventory.RemoveItem(item2, dinoScript.itemCount / 2);
            }
            if (item3 != null)
            {
                inventory.RemoveItem(item3, dinoScript.itemCount / 2);
            }



            textBox.text = "You failed to tame the dino! Better luck next time!";
            playerController.PlayLoseSound(); // plays lose sound

            triggerZones = startTriggerZones;
            tamingGame.SetActive(false);
        }
    }

    
    IEnumerator ShowMessage(string message, float delay)
    {
        bestiaryNotification.enabled = true;
        bestiaryNotification.text = message;
        yield return new WaitForSeconds(delay);
        bestiaryNotification.text = "";
        bestiaryNotification.enabled = false;
    }
    
}
