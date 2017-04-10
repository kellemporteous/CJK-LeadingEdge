using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

    public GameObject player;
    public float moveSpeed;
    public Vector3 target;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(LockOn());
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    protected virtual void Movement()
    {

    }

    IEnumerator LockOn()
    {
        yield return new WaitForSeconds(2);
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
        target.z = transform.position.z;
    }
}
