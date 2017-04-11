using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;
    public float moveSpeed;
    public float maxSpeed;
    public float currentStamia;
    public float maxStamina;

    public bool isSwooping = false;

    public float heightTravelled;
    //public Vector3 lastPosition;


    // Use this for initialization
    void Start ()
    {
        //lastPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();

        maxSpeed = moveSpeed * 4;
        currentStamia = maxStamina;
    }
	
	// Update is called once per frame
	void Update ()
    {

        heightTravelled = Time.time;
        

        Controls();

        if (isSwooping == true)
        {
            currentStamia -= currentStamia * 2;
        }

        else if (currentStamia <= 0)
        {
            
            currentStamia = 0;
            isSwooping = false;
        }
    }

    void FixedUpdate()
    {

    }


    void Controls()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
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
