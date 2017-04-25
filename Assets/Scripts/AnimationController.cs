using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    PlayerController player;

    Animator anim;

    // Use this for initialization
    void Start ()
    {
        player = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        switch (player.playerState)
        {
            case PlayerController.PlayerState.Idle:
                anim.SetTrigger("Idle");
                break;
            case PlayerController.PlayerState.Boost:
                break;
            case PlayerController.PlayerState.Death:
                anim.SetTrigger("Death");
                break;
        }
    }
}
