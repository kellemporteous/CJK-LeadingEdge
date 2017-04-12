using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

    public GameObject player;
    public float moveSpeed;
    public Vector3 target;
    public float deathCounter;

    PlayerController playerInfo;


    // Use this for initialization
    void Start ()
    {
        StartCoroutine(LockOn());
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        deathCounter -= Time.deltaTime;

        if (deathCounter <= 0.0f)
        {
            deathCounter = 5.0f;
            Despawn();
        }
    }

    protected virtual void Movement()
    {

    }

    protected IEnumerator LockOn()
    {
        yield return new WaitForSeconds(2);
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
        target.z = transform.position.z;
    }

    void Despawn()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInfo.Death();
        }
    } 
}
