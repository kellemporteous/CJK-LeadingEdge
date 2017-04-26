using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBird : BaseEnemy {

    public bool PlaySound = false;

    void FixedUpdate()
    {
        if (player != null)
        {
            Movement();
        }
    }

    protected override void Movement()
    {
        if (PlaySound == false)
        {
            SoundController.instance.BirdChirp();
            PlaySound = true;
            Debug.Log("GreenBird played the sound");
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        //this.gameObject.transform.LookAt(new Vector3(0.0f, 0.0f, target.transform.position.z));
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
