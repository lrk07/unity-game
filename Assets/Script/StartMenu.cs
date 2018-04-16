using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {

	public GameObject StartUI;
	public static bool isGameStarted = false;


	// Use this for initialization
	void Start () {
	}

	void Update() {
		if (isGameStarted) {
			StartUI.SetActive (false);
		}
		if (!isGameStarted) {
			StartUI.SetActive (true);
		}
	}

	public void StartPanelHide() {
		isGameStarted = true;
		Application.LoadLevel (Application.loadedLevel);
	}
}


