using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    PlayerController player;

    public GameObject pauseMenu;


    public Slider staminaBar;
    public Text height;
    public Text startPrompt;
    public Text controlPrompt;

	// Use this for initialization
	void Start ()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.GetComponent<PlayerController>();

            if (player != null)
            {
                player.heightTravelled = 0.0f;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (height != null && height.text != null && player != null && staminaBar != null)
        {
            height.text = "Height: " + player.heightTravelled;
            Pause();
            staminaBar.value = player.currentStamia;
        }
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

    public void StartButton()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    /*public void PowerPercentage(float value)
    {
        startPower -= value;
        powerBar.size = startPower / 100.0f;
    }*/
}
