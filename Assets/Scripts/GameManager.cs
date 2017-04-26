using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int score = 0;
    public int highScore = 0;

    [SerializeField]
    private float fallSpeed = 1;
    public Spawner spawner;
    UIManager UI;
    PlayerController player;


    public float FallSpeed
    {
        get
        {
            if (state == State.LevelMain)
                return fallSpeed;
            else
                return 0;
        }
    }

    public static GameManager inst;

    public enum State
    {
        Launch,
        LevelMain
    }

    public State state;

    private void Awake()
    {
        inst = this;
    }

    // Use this for initialization
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }

        if (PlayerPrefs.HasKey("Score"))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Level 1")
            {
                PlayerPrefs.DeleteKey("Score");
                score = 0;
            }
        }
        spawner.enabled = false;
        UI.staminaBar.enabled = false;
        player.staminaDrain = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Launch:
                //launcher is enabled
                //scrolling is disabled
                break;
            case State.LevelMain:
                //launcheris disabled
                //scrolling is enabled
                break;
            default:
                break;
        }
    }

    public void GoToLevelMain()
    {
        state = State.LevelMain;
        spawner.enabled = true;
        UI.startPrompt.enabled = false;
        UI.controlPrompt.enabled = false;
        UI.staminaBar.enabled = true;
        player.staminaDrain = 0.5f;

    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }

        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
