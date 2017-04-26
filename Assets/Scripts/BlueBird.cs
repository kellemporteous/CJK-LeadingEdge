using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : BaseEnemy {
    public bool PlaySound = false;

    // Update is called once per frame


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
            Debug.Log("BlueBird played the sound");
        }
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        //this.gameObject.transform.LookAt(new Vector3(0.0f, 0.0f, target.transform.position.z));
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
