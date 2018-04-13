using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public GameObject WinUI;

    public bool isWin = false;
    private Pingwin pingwin;
    // Use this for initialization
    void Start () {
        WinUI.SetActive(false);
        pingwin = GameObject.FindGameObjectWithTag("Player").GetComponent<Pingwin>();
    }

    void Update()
    {
        if (isWin)
        {
            WinUI.SetActive(true);
            pingwin.speed = 0;
            pingwin.jumpPower = 0;
        }
        if(!isWin)
        {
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isWin = true;
    }
}
