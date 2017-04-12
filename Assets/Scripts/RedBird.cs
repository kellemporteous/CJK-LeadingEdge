using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : BaseEnemy {

    public float horizontalSpeed;
    public float verticalSpeed;
    public float altitude;

    Vector3 tempPos;

    void Start()
    {
        StartCoroutine(base.LockOn());
        tempPos = transform.position;
    }


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
        if (Vector3.Dot(target.normalized, this.transform.position.normalized) == 1)
        {
            horizontalSpeed = -horizontalSpeed;
        }
        else
        {
            horizontalSpeed = 0.01f;
        }
        tempPos.x += horizontalSpeed;
        tempPos.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * altitude;
        transform.position = tempPos;
        transform.position = Vector3.MoveTowards(transform.position, target, horizontalSpeed);
    }

}