using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamingTriggerZoneManager : MonoBehaviour
{
    public bool isNearbyAny = false;
    public GameObject anchor; // set in inspector
    private TamingGame tamingScript;

    public GameObject z1; // set in inspector
    public GameObject z2; // set in inspector
    public GameObject z3; // set in inspector
    public GameObject z4; // set in inspector
    public GameObject z5; // set in inspector

    private TamingTriggerZone zone1;
    private TamingTriggerZone zone2;
    private TamingTriggerZone zone3;
    private TamingTriggerZone zone4;
    private TamingTriggerZone zone5;


    // Start is called before the first frame update
    void Start()
    {
        zone1 = z1.GetComponent<TamingTriggerZone>();
        zone2 = z2.GetComponent<TamingTriggerZone>();
        zone3 = z3.GetComponent<TamingTriggerZone>();
        zone4 = z4.GetComponent<TamingTriggerZone>();
        zone5 = z5.GetComponent<TamingTriggerZone>();
        tamingScript = anchor.GetComponent<TamingGame>();
    }

    // Update is called once per frame
    void Update()
    {
        /*CheckZones();
        if (Input.GetKeyDown(KeyCode.E) && !isNearbyAny)
        {
            tamingScript.strikes--;
        }*/
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            tamingScript.strikes--;
        }

        //reset game
        if (tamingScript.strikes <= 0)
        {
            z1.SetActive(true);
            z2.SetActive(true);
            z3.SetActive(true);
            z4.SetActive(true);
            z5.SetActive(true);
        }
    }
    /*
    private void CheckZones()
    {
        if (zone1.isNearby == false && zone2.isNearby == false && zone3.isNearby == false && zone4.isNearby == false && zone5.isNearby == false)
        {
            isNearbyAny = false;
        }
        else
        {
            isNearbyAny = true;
        }
    }*/
}
