using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    //necessary varibles go here
    public GameObject player;

	// Use this for initialization
	void Start ()
    {

        // this is so that the player is attached to the correct gameobject
        player = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.transform.position.y > 0)
        {
            if (player.transform.position.y > transform.position.y + 4.5f)
            {
                this.transform.position = new Vector3(transform.position.x, player.transform.position.y - 4.5f, -10);
            }
        }
	}
}
