using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundedChecker : MonoBehaviour {

    // Reference to pingwin class to set the graunded variable
    private Pingwin pingwin;

    void Start()
    {
        pingwin = gameObject.GetComponentInParent<Pingwin>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        pingwin.graunded = true;
    }

    // bug fix
    void OnTriggerStay2D(Collider2D collision)
    {
        pingwin.graunded = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        pingwin.graunded = false;
    }
}
