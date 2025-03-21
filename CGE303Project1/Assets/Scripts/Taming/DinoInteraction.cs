using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DinoInteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;
    public bool isTamed = false;
    public bool isTaming = false;

    public GameObject dino; // set in inspector
    public GameObject dinoTextBox; // set in inspector
    public GameObject tamingGame; // set in inspector
    public GameObject tutorialManager; // set in inspector
    public GameObject image;
    private TutorialManager tutorial;


    public TMP_Text textBox; // set in inspector
    public TMP_Text scoreTextBox; // set in inspector
    private ScoreScript scoreScript;

    [SerializeField] Item item1; // set in inspector
    [SerializeField] Item item2; // set in inspector
    [SerializeField] Item item3; // set in inspector
    [SerializeField] InventoryManager inventory;
    public int itemCount;

    private void Start()
    {
        scoreScript = scoreTextBox.GetComponent<ScoreScript>();
        tutorial = tutorialManager.GetComponent<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !isTamed & !isTaming && findItems(item1) && findItems(item2) && findItems(item3)) //also must check if player has enough resources
        {
            Interact();
        }
        else if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !isTamed & !isTaming)
        {
            textBox.text = "You do not have enough resources to tame the dino!";
            StartCoroutine(wait());
        }

        if (isTamed)
        {
            dino.GetComponent<BoxCollider2D>().enabled = false; //allow player to walk through dino
            image.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerNearby = true;
            if (!isTamed)
            {
                dinoTextBox.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerNearby = false;
            if (!isTamed)
            {
                dinoTextBox.SetActive(false);
            }
        }
    }

    private void Interact()
    {
        tutorial.firstTame = true;
        dinoTextBox.SetActive(false);
        isTaming = true;
        tamingGame.SetActive(true); //start taming mini game
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        while (tamingGame.activeSelf)
        {
            yield return null;
        }
        if (isTamed)
        {
            scoreScript.score++;
        }
        yield return new WaitForSeconds(5);
        textBox.text = "";
    }

    bool findItems(Item item)
    {
        if (item != null)
        {
            int numItems = inventory.findNumItems(item);
            if (numItems >= itemCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
