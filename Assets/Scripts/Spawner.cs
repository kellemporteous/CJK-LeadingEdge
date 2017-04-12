using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
    public GameObject[] collectables;
    public int numOfEnemies;
    public float enemySpawnTime;
    public float collectablesSpawnTime;
    public float radius;
    Camera cam;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;

        player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("SpawnEnemies", enemySpawnTime, enemySpawnTime);

        InvokeRepeating("SpawnCollectables", collectablesSpawnTime, collectablesSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemies()
    {

            for (int i = 0; i < numOfEnemies; i++)
         {
            Vector2 spawnPosition = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
            Quaternion spawnRotation = Quaternion.identity;
            int enemyTypeIndex = Random.Range(0, enemies.Length);

            if (Vector2.Distance(spawnPosition, player.transform.position) < radius)
            {
                numOfEnemies++;
            }

            else
            {
                Instantiate(enemies[enemyTypeIndex] as GameObject, cam.ScreenToWorldPoint(new Vector3(spawnPosition.x, spawnPosition.y, 10)), spawnRotation);
            }

         }
    }

    void SpawnCollectables()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
        Quaternion spawnRotation = Quaternion.identity;
        int collectableTypeIndex = Random.Range(0, collectables.Length);

        Instantiate(collectables[collectableTypeIndex] as GameObject, cam.ScreenToWorldPoint(new Vector3(spawnPosition.x, spawnPosition.y, 10)), spawnRotation);          
    }
}