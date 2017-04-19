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
    

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.rb.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update ()
    {


        if (Input.GetKey("space"))
        {

            powerCounter += Time.deltaTime * barSpeed;

            if (powerCounter >= powerMax)
            {
                powerCounter = powerMin;
            }
            powerPercentage = Mathf.PingPong(powerCounter, powerMax);
        }

        if (Input.GetKeyUp("space"))
        {
            player.rb.isKinematic = false;
            player.rb.AddForce(Vector3.up * powerBoost, ForceMode2D.Impulse);
            GameManager.inst.GoToLevelMain();
            gameObject.SetActive(false);
        }

        powerBoost = powerPercentage;
        powerBar.value = powerPercentage;
	}
}
