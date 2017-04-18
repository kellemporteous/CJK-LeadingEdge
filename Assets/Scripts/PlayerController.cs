using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;
    public float moveSpeed;
    public float maxSpeed;
    public float currentStamia;
    public float maxStamina;

    public bool isSwooping = false;

    public float heightTravelled;
    public float heightModifier;
    public float staminaDrain = 0.5f;
    //public Vector3 lastPosition;


    // Use this for initialization
    void Start ()
    {

        heightTravelled = 0;

        //lastPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();

        
        maxSpeed = moveSpeed * 4;
        currentStamia = maxStamina;
    }
	
	// Update is called once per frame
	void Update ()
    {

        heightTravelled += rb.velocity.magnitude * heightModifier;
        PlayerWin();
        //Scene scene = SceneManager.GetActiveScene();

        //if (scene.name != "Level 1")
        //{
        //    SceneManager.UnloadScene("Level 1");
        //}

        if (currentStamia > maxStamina)
        {
            currentStamia = maxStamina;
        }

        if (currentStamia > 0)
        {
            Controls();
        }

        if (isSwooping == true)
        {
            currentStamia -= staminaDrain;
            //heightModifier = 2;
        }

        else if (currentStamia <= 0)
        {
            //heightModifier = 1;
            currentStamia = 0;
            isSwooping = false;
        }
    }

    void FixedUpdate()
    {
    }


    void PlayerWin()
    {
        if (heightTravelled >= 500)
        {
            SceneManager.LoadScene("Win Screen");
        }
    }

    public void Death()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    void Controls()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");        

        Vector2 movement = new Vector2 (moveHorizontal, 0);
        rb.AddForce(movement * moveSpeed);

        if (Input.GetKeyDown("space"))
        {
            isSwooping = true;
            rb.AddForce(movement * maxSpeed);

            
        }

        if (Input.GetKeyUp("space"))
        {
            isSwooping = false;
        }
    }
}
