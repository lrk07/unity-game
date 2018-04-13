using System.Collections;
using UnityEngine;

public class Pingwin : MonoBehaviour
{

    public float maxSpeed = 3;
    public float minSpeed = -0.1f;

    public float speed = 20f;
    public float jumpPower = 300f;
    public bool graunded;
    public bool canDoubleJump = false;

    // TODO STATS
    public int currentHealth;
    public int maxHealth = 5;

    // Reference to Pingwin Object
    private Rigidbody2D pingwinBody2D;
    private Animator pingwinAnimator;

    // Referemce to gameController;
    public GameController controller;

    // Use this for initialization
    void Start()
    {

        pingwinBody2D = gameObject.GetComponent<Rigidbody2D>();
        // fix rotation in jump
        pingwinBody2D.freezeRotation = true;
        pingwinAnimator = gameObject.GetComponent<Animator>();
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<GameController>();
        controller.currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        BindingVariable();
        CheckJump();
        CheckDirection();
        CheckHealth();
    }

    void FixedUpdate()
    {
        MovePingwin();
        LimitMaxSpeed();
    }

    private void CheckHealth()
    {
        if (controller.currentHealth > maxHealth)
        {
            controller.currentHealth = maxHealth;
        }
        if (controller.currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int value)
    {
        controller.currentHealth -= value;
    }

    // custom method

    private void BindingVariable()
    {
        // binding the variable in animator to variable in the script
        pingwinAnimator.SetBool("Graunded", graunded);
        pingwinAnimator.SetFloat("Speed", Mathf.Abs(pingwinBody2D.velocity.x));
    }
    private void CheckDirection()
    {
        if (Input.GetAxis("Horizontal") < minSpeed)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > minSpeed)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void CheckJump()
    {
        if (Input.GetButton("Jump"))
        {
            if(graunded)
            {
                pingwinBody2D.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            } else if(canDoubleJump)
            {
                pingwinBody2D.velocity = new Vector2(pingwinBody2D.velocity.x, 0);
                pingwinBody2D.AddForce(Vector2.up * jumpPower);
                canDoubleJump = false;
            }
        }
    }

    private void MovePingwin()
    {
        float horizotalVector = Input.GetAxis("Horizontal");
        pingwinBody2D.AddForce((Vector2.right * speed) * horizotalVector);

        if (graunded)
        {
            pingwinBody2D.velocity = FixedVelocity();
        }
    }

    private Vector3 FixedVelocity()
    {
        Vector3 tmpVelocity = pingwinBody2D.velocity;
        tmpVelocity.z = 0.0f;
        tmpVelocity.x *= 0.75f;

        return tmpVelocity;
    }

    private void LimitMaxSpeed()
    {
        if (pingwinBody2D.velocity.x > maxSpeed)
        {
            pingwinBody2D.velocity = new Vector2(maxSpeed, pingwinBody2D.velocity.y);
        }

        if (pingwinBody2D.velocity.x < -maxSpeed)
        {
            pingwinBody2D.velocity = new Vector2(-maxSpeed, pingwinBody2D.velocity.y);
        }
    }

    public IEnumerator Knockback(float knockDuration, float knockPower, Vector3 knockDirection)
    {

        float timer = 0;
        while (knockDuration > timer)
        {
            timer += Time.deltaTime;
            if (knockDirection.x < 0)
            {
                pingwinBody2D.AddForce(new Vector3(knockDirection.x * 15, knockDirection.y + knockPower));
            }
            else
            {
                pingwinBody2D.AddForce(new Vector3(knockDirection.x * -15, knockDirection.y + knockPower));
            }
            
        }

        yield return 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {

            Destroy(collision.gameObject);
            controller.coints += 1;

        }
        else if (collision.CompareTag("Heart"))
        {

            Destroy(collision.gameObject);
            AddHeart();
        }
    }

    private void AddHeart()
    {
        if (controller.currentHealth < maxHealth)
        {
            controller.currentHealth += 1;
        }
    }
}
