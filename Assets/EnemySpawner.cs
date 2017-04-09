using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemies;
    public int numOfEnemies;
    public float spawnTime;
    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnWaves()
    {

            for (int i = 0; i < numOfEnemies; i++)
         {
                Vector2 spawnPosition = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
                Quaternion spawnRotation = Quaternion.identity;
                int enemyTypeIndex = Random.Range(0, enemies.Length);

                Instantiate(enemies[enemyTypeIndex] as GameObject, cam.ScreenToWorldPoint(new Vector3(spawnPosition.x, spawnPosition.y, 10)), spawnRotation);
         }
    }
}