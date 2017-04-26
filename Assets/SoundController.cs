using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public static SoundController instance;

    AudioSource audioSource;

    public AudioClip balloonPop;
    public AudioClip birdChirp;

    // Use this for initialization
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void BalloonPop()
    {
        audioSource.PlayOneShot(balloonPop);
    }

    public void BirdChirp()
    {
        audioSource.PlayOneShot(birdChirp);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
