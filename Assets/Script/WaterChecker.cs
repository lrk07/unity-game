using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterChecker : MonoBehaviour {

    // Reference to pingwin class to set the graunded variable
    private Pingwin pingwin;

    // Use this for initialization
    void Start () {

        pingwin = GameObject.FindGameObjectWithTag("Player").GetComponent<Pingwin>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        pingwin.Die();
    }
}
