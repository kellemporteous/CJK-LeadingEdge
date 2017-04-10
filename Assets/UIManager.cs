using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    PlayerController player;

    public Scrollbar powerBar;
    public float startPower;
    public bool increasing = false;

    public Text height;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        height.text = "Height: " + player.heightTravelled;
	}

    public void PowerPercentage(float value)
    {
        startPower -= value;
        powerBar.size = startPower / 100.0f;
    }
}
