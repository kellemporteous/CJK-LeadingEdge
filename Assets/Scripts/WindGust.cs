using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGust : MonoBehaviour {

    PlayerController player;
    public float deathCounter;
    public float windBoost = 15.0f;
    

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        deathCounter -= Time.deltaTime;

        if (deathCounter <= 0.0f)
        {
            deathCounter = 10.0f;
            Despawn();
        }

        transform.Translate(Vector2.down * GameManager.inst.FallSpeed * Time.deltaTime);
    }

    void Despawn()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.rb.AddForce(Vector3.up * windBoost, ForceMode2D.Impulse);
        }
    }
}
