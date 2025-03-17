using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForagingTriggerZone : MonoBehaviour
{
    public GameObject slider; // set in the inspector (the moving object)
    public GameObject powerSlider; // set in the inspector (the power slider game)
    private SliderController sliderScript; // reference to the sliderController script
    private bool inZone = false; //true if in the trigger zone
    private int score; // current score
    public int scoreToWin; // set in the inspector (the score needed to win)

    [SerializeField] Item item;
    [SerializeField] InventoryManager inventory;

    // Start is called before the first frame update
    void Start()
    {
        sliderScript = slider.GetComponent<SliderController>(); // setting a reference to the sliderController script to access its variables
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(item);// add the item to the inventory
            score++; // increase the score if the player is in the trigger zone and presses E
        }

        if (score >= scoreToWin) // when the player reaches the score needed to win
        {
            score = 0; // reset the score
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
