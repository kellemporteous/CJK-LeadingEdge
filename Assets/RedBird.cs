using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : BaseEnemy {

    public float freq;
    public float magn;

    private Vector3 axis;
    private Vector3 pos;



    // Use this for initialization
    void Start ()
    {

        pos = transform.position;
        axis = transform.right;

    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
    }

   

    protected override void Movement()
    {
        pos += transform.up * Time.deltaTime * moveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * freq) * magn;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

    }

}
