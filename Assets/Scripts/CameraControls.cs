using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    //necessary varibles go here
    public GameObject player;
    PlayerController playerInfo;


    private float leftConstraint = Screen.width;
    private float rightConstraint = Screen.width;
    private float bottomConstraint = Screen.height;
    private float topConstraint = Screen.height;
    public float buffer = 0f;
    public float distZ;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
        distZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0, 0, distZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, distZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distZ)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distZ)).y;
    }
    // Use this for initialization
    void Start ()
    {
        // this is so that the player is attached to the correct gameobject
        player = GameObject.FindGameObjectWithTag("Player");
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }


    // Update is called once per frame
    void Update ()
    {

        if (player.transform.position.x < leftConstraint - buffer)
        {
            player.transform.position = new Vector3(rightConstraint + buffer, player.transform.position.y, distZ);
        }
        if (player.transform.position.x > rightConstraint + buffer)
        {
            player.transform.position = new Vector3(leftConstraint - buffer, player.transform.position.y, distZ);
        }
        if (transform.position.y < bottomConstraint - buffer)
        {

        }
        if (player.transform.position.y >= topConstraint + buffer)
        {
            player.transform.position = new Vector3(player.transform.position.x, topConstraint - buffer, distZ);
        }

        if (player.transform.position.y < bottomConstraint - buffer)
        {
            playerInfo.Death();
        }
    }
}
