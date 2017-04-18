using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int score = 0;
    public int highScore = 0;

    // Use this for initialization
    void Start()
    {


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
    }
    // Update is called once per frame
    void Update()
    {

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
