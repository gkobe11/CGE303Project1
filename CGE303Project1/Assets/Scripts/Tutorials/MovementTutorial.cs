using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
