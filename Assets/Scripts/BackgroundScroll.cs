using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //this may also need to be aware of the bg size to scale fallspeed by
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f, (Time.time * GameManager.inst.FallSpeed * 0.1f) % 2);

    }
}
