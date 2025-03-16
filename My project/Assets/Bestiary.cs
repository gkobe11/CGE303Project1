using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bestiary : MonoBehaviour
{

    public GameObject[] entries;
    public Button[] buttons;

    public void EnableEntryButton(int id) {
        buttons[id - 1].interactable = true;
    }

    public void EnableEntry (int id) {
        for (int i = 0; i < entries.Length; i++) {
            
            entries[i].SetActive(false);
        }
        entries[id].SetActive(true);
    }
}
