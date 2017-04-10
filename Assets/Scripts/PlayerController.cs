using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;
    public float moveSpeed;

    public float heightTravelled;
    public Vector3 lastPosition;

    public Vector3 previousPosition;
    public float calculatedDistance;

    void Awake()
    {
        previousPosition = transform.position;
    }

    // Use this for initialization
    void Start ()
    {
        lastPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        calculatedDistance += (transform.position - previousPosition).magnitude;
        previousPosition = transform.position;
        heightTravelled = Mathf.Round(calculatedDistance/2);
	}

    void FixedUpdate()
    {
        Controls();
    }

    void Controls()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        rb.AddForce(movement * moveSpeed);
    }
}
