using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {


    public bool past = true;
    public int cointToPast = 10;
     
    private Animator guardAnimator;
    private Pingwin pingwin;

    private float animationTimeLeft = 0.75f;

    // Use this for initialization
    void Start () {
		guardAnimator = gameObject.GetComponent<Animator>();
        pingwin = GameObject.FindGameObjectWithTag("Player").GetComponent<Pingwin>();
    }

	// Update is called once per frame
	void Update () {

        BindingVariable();

        if (!past)
        {
            countTime();
        }
    }

    private void countTime()
    {
        animationTimeLeft -= Time.deltaTime;
        if (animationTimeLeft < 0)
        {
            past = true;
            animationTimeLeft = 0.75f;
        }
    
    }

    private void BindingVariable()
    {
        // binding the variable in animator to variable in the script
        guardAnimator.SetBool("Past", past);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (pingwin.controller.coints < cointToPast)
        {
            past = false;
            StartCoroutine(pingwin.Knockback(0.02f, 10, pingwin.transform.position));
            pingwin.Damage(1);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
