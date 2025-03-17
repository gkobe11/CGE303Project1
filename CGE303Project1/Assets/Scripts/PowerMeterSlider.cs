using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PowerMeterSlider : MonoBehaviour
{
    public float speed = 4f;
    public float minPosition = -6.5f;
    public float maxPosition = 8.2f;
    private bool isMoving = true;
    private float currentPosition;

    public TMP_Text textbox;


    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // Move the bar back and forth
            currentPosition = Mathf.PingPong(Time.time * speed, maxPosition - minPosition) + minPosition;
            transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);

            // Stop movement when spacebar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StopBar();
            }
        }

        void StopBar()
        {
            isMoving = false; // Stop movement
            CheckTargetRegion(); // Check if stopped in target region
        }

        void CheckTargetRegion()
        {
            // Define target region (example: between -1.5 and 1.5)
            if (currentPosition > -0.9f && currentPosition < 2.2f)
            {
                textbox.text = "You win! Press R to Try Again!";

            }
            else
            {
                textbox.text = "You missed! Press R to Try Again!";
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
            {
                //reload the current scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
}
    


