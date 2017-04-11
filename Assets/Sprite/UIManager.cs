using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    PlayerController player;

    public GameObject pauseMenu;
    public Scrollbar powerBar;
    public float startPower;
    public bool increasing = false;

    public Slider staminaBar;

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
        Pause();
        staminaBar.value = player.currentStamia;
	}

    public void Pause()
    {
        if (Input.GetKeyDown("escape"))
        {

            if (Time.timeScale == 1)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void PowerPercentage(float value)
    {
        startPower -= value;
        powerBar.size = startPower / 100.0f;
    }
}
