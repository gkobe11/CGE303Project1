using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject foragingPanel;
    public GameObject tutorialPanel;

    public bool firstForage = false;
    public bool firstTame = false;
    private bool forageTutorialActivated = false;
    private bool tameTutorialActivated = false;

    void Update()
    {
        if (firstForage && !forageTutorialActivated)
        {
            foragingPanel.SetActive(true);
            forageTutorialActivated = true;
        }

        if (firstTame && !tameTutorialActivated)
        {
            tutorialPanel.SetActive(true);
            tameTutorialActivated = true;
        }

    }
}
