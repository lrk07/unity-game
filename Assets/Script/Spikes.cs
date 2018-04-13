using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private Pingwin pingwin;

	void Start() {
		pingwin = GameObject.FindGameObjectWithTag ("Player").GetComponent<Pingwin> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			pingwin.Damage (1);
			StartCoroutine (pingwin.Knockback (0.02f, 400, pingwin.transform.position));
		}
	}
		
}
