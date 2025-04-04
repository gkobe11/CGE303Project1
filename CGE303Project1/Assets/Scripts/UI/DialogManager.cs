using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TMP_Text textbox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject dialogPanel;
    public GameObject continueText;

    private bool isTyping = false;



    void Update()
    {
        if (!isTyping)
        {
            continueText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                NextSentence();
            }
        }
    }

    void OnEnable()
    {
        StartCoroutine(Type());
        isTyping = false;
    }

    IEnumerator Type()
    {
        isTyping = true;
        continueText.SetActive(false);
        textbox.text = "";
        foreach (char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    public void NextSentence()
    {
        isTyping = false;

        if (index < sentences.Length - 1)
        {
            index++;
            textbox.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textbox.text = "";
            dialogPanel.SetActive(false);
        }
    }
}

