using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    public int maxScore = 3;
    public TMP_Text scoreTextBox; // set in inspector
    public TMP_Text winTextBox; // set in inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextBox.text = "Score: " + score + "/3";
        if (score >= maxScore)
        {
            winTextBox.text = "You have tamed all the dinosaurs! Press R to play again!";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}
