using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    //necessary varibles go here
    public GameObject player;

    public float leftConstraint = Screen.width;
    public float rightConstraint = Screen.width;
    public float buffer = 0f;
    public float distZ;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
        distZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0, 0, distZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, distZ)).x;
    }
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

        if (player.transform.position.x < leftConstraint - buffer)
        {
            player.transform.position = new Vector3(rightConstraint + buffer, transform.position.y, 0);
        }
        if (player.transform.position.x > rightConstraint + buffer)
        {
            player.transform.position = new Vector3(leftConstraint - buffer, transform.position.y, 0);
        }
    }
}
