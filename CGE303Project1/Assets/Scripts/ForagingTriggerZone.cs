using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForagingTriggerZone : MonoBehaviour
{
    public GameObject slider; // set in the inspector (the moving object)
    public GameObject powerSlider; // set in the inspector (the power slider game)
    private SliderController sliderScript; // reference to the sliderController script
    private bool inZone = false; //true if in the trigger zone
    private int score; // current score
    public int scoreToWin; // set in the inspector (the score needed to win)
    public int strikes = 3;

    public TMP_Text StrikesTextBox; // set in the inspector (the text box to display the score)

    PlayerController playerController; // reference to the playerController script

    [SerializeField] Item item;
    [SerializeField] InventoryManager inventory;

    // Start is called before the first frame update
    void Start()
    {
        sliderScript = slider.GetComponent<SliderController>(); // setting a reference to the sliderController script to access its variables

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // setting a reference to the playerController script to access its variables 
    }

    // Update is called once per frame
    void Update()
    {
        StrikesTextBox.text = "Strikes: " + strikes; // display the score in the text box
        if (inZone && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(item);// add the item to the inventory
            score++; // increase the score if the player is in the trigger zone and presses E

            playerController.PlayCollectSound(); // plays collect sound
        }
        else if (!inZone && Input.GetKeyDown(KeyCode.E))
        {
            strikes--; // decrease the strike if the player is not in the trigger zone and presses E
            playerController.PlayMissSound(); // plays miss sound
        }

        if (score >= scoreToWin) // when the player reaches the score needed to win
        {
            score = 0; // reset the score
            strikes = 3; // reset the strikes
            powerSlider.SetActive(false); // hide the powerSlider game
        }

        if (strikes <= 0) // when the player runs out of strikes
        {
            strikes = 3; // reset the strikes
            powerSlider.SetActive(false); // hide the powerSlider game
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // activates when the player enters the trigger zone
    {
        if (other.gameObject == slider) // check if the slider was the object that entered the trigger zone
        {
            inZone = true; // set inZone to true
        }
    }

    private void OnTriggerExit2D(Collider2D other) // activates when the player exits the trigger zone
    {
        if (other.gameObject == slider) // check if the slider was the object that exited the trigger zone
        {
            inZone = false; // set inZone to false
        }
    }
}
