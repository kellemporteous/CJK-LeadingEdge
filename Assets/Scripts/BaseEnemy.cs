using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

    public GameObject player;
    public float moveSpeed;
    public Vector3 target;
    public float deathCounter;
    public Vector2 tempPosition;

    public EnemyState enemyState;

    public int minDistance = 6;

    PlayerController playerInfo;
    SoundController soundManager;

    public enum EnemyState
    {
        Idle,
        Attack
    }

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(LockOn());
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        soundManager = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<SoundController>();
        tempPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {

        deathCounter -= Time.deltaTime;

        if (deathCounter <= 0.0f)
        {
            deathCounter = 5.0f;
            Despawn();
        }

        EnemyLogic();
        EnemyBehaviour();

    }

    protected virtual void Movement()
    {

    }

    void Idle()
    {
        transform.Translate(Vector2.down * GameManager.inst.FallSpeed * Time.deltaTime * 2.0f);

    }

    protected IEnumerator LockOn()
    {
        yield return new WaitForSeconds(2);
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
        target.z = transform.position.z;
    }

    void Despawn()
    {
        Destroy(gameObject);
    }

    void EnemyLogic()
    {

        var currentDiff = playerInfo.transform.position - transform.position;
        var currentDistance = currentDiff.magnitude;

        if (currentDistance <= minDistance)
        {
                //STATE TRANSITION: ATTACK
                enemyState = EnemyState.Attack;

        }
    }

    void EnemyBehaviour()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
                Idle();//Idle
                break;

            case EnemyState.Attack:
                Movement();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            soundManager.PlaySound(soundManager.ballonPop);
            playerInfo.Death();
        }
    } 
}
