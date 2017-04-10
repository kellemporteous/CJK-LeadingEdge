using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : BaseEnemy {

	
	// Update is called once per frame
	void Update ()
    {
        if (player != null)
        {
            Movement();
        }
    }

    protected override void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        //this.gameObject.transform.LookAt(new Vector3(0.0f, 0.0f, target.transform.position.z));
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
