using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : BaseEnemy {

    public float delay;
    public float duration;

    private float startTime;
    private float elapsedTime;
    
	// Use this for initialization
	void Start ()
    {
        startTime = delay;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void Movement()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= delay)
        {
            this.transform.position = Vector3.Lerp(transform.position, target.transform.position, (Time.time - delay) / duration);
        }
    }
}
