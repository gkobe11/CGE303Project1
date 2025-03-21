using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject foragingPanel; // set in inspector
    public GameObject tutorialPanel; // set in inspector

    public GameObject inventoryCanvas; // set in inspector
    public GameObject UICanvas; // set in inspector
    public GameObject StartPanel; // set in inspector

    public bool firstForage = false;
    public bool firstTame = false;
    private bool forageTutorialActivated = false;
    private bool tameTutorialActivated = false;


    private void Start()
    {
        inventoryCanvas.SetActive(false);
        UICanvas.SetActive(false);

        StartCoroutine(wait(StartPanel));
    }

    void Update()
    {
        if (firstForage && !forageTutorialActivated)
        {
            inventoryCanvas.SetActive(false);
            UICanvas.SetActive(false);

            foragingPanel.SetActive(true);
            forageTutorialActivated = true;

            StartCoroutine(wait(foragingPanel));
        }

        if (firstTame && !tameTutorialActivated)
        {
            inventoryCanvas.SetActive(false);
            UICanvas.SetActive(false);

            tutorialPanel.SetActive(true);
            tameTutorialActivated = true;

            StartCoroutine(wait(tutorialPanel));
        }

    }

    IEnumerator wait(GameObject panel)
    {
        while (panel.activeSelf)
        {
            yield return null;
        }

        inventoryCanvas.SetActive(true);
        UICanvas.SetActive(true);
    }
}
