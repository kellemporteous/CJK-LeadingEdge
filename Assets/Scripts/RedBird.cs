using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : BaseEnemy {
    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;
    public bool PlaySound = false;


    // Update is called once per frame
    void FixedUpdate ()
    {
        if (player != null)
        {
            Movement();
        }
    }


    protected override void Movement()
    {
        if (PlaySound == false) {
            SoundController.instance.BirdChirp();
            PlaySound = true;
            Debug.Log("RedBird played the sound");
        }
        tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }
}