using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMenu : MonoBehaviour {

	public GameObject TimeUI;
	private Pingwin pingwin;
	private Timer timer;

	// Use this for initialization
	void Start () {
		TimeUI.SetActive (false);
		pingwin = GameObject.FindGameObjectWithTag("Player").GetComponent<Pingwin>();
		timer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Timer> ();
	}

	void Update()
	{
		if (timer.isTimeOut)
		{
			TimeUI.SetActive(true);
			pingwin.speed = 0;
			pingwin.jumpPower = 0;
		}
		if(!timer.isTimeOut)
		{
			TimeUI.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void Restart() {
		timer.ResumeTime ();
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Quit() {
		Application.Quit ();
	}
}


