using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamingTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
