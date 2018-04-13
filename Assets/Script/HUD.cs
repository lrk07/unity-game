using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;

	public Image HeartUI;

	private GameController controller;

	void Start() {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<GameController>();
    }

	void Update() {
		HeartUI.sprite = HeartSprites[controller.currentHealth];
	}

}
