﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

	public Text timerText;
	public float startTime;
	public float endTime;
	public float initTime = 200;
	public bool isTimeOut;

	private Pingwin pingwin;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		endTime = startTime + initTime;
		isTimeOut = false;
		pingwin = GameObject.FindGameObjectWithTag ("Player").GetComponent<Pingwin> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		float time = endTime - Time.time;
		if (time <= 10) {
			timerText.color = Color.red;
		}
		if (time <= 0) {
			time = 0;
			isTimeOut = true;
		}
		timerText.text = "Time left: " + time.ToString("f0");

	}

	public void ResumeTime() {
		isTimeOut = false;
	}
}
