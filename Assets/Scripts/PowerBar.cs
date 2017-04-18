using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    PlayerController player;

    public Slider powerBar;
    public float powerPercentage, powerMin, powerMax;
    public float barSpeed;
    public float powerCounter;
    public float powerBoost;

    public bool isTriggered;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {


        if (Input.GetKey("e"))
        {

            powerCounter += Time.deltaTime * barSpeed;

            if (powerCounter >= powerMax)
            {
                powerCounter = powerMin;
            }
            powerPercentage = Mathf.PingPong(powerCounter, powerMax);
        }

        if (Input.GetKeyUp("e"))
        {
            player.rb.AddForce(Vector3.up * powerBoost, ForceMode2D.Impulse);

            isTriggered = true;
        }

        powerBoost = powerPercentage;
        powerBar.value = powerPercentage;
	}
}
