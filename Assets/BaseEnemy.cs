using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start ()
    {

        target = GameObject.FindGameObjectWithTag("player");

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    protected virtual void Movement()
    {

    }
}
