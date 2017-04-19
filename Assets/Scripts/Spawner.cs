using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] birds;
    public GameObject[] collectables;
    public int numOfEnemies;
    public float enemySpawnTime;
    public float collectablesSpawnTime;
    public Transform[] birdSpawnPoints;
    public float radius;
    Camera cam;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;

        player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("SpawnBirds", enemySpawnTime, enemySpawnTime);

        InvokeRepeating("SpawnCollectables", collectablesSpawnTime, collectablesSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBirds()
    {

            for (int i = 0; i < numOfEnemies; i++)
         {
            int spawnPointIndex = Random.Range(0, birdSpawnPoints.Length);
            int birdTypeIndex = Random.Range(0, birds.Length);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(birds[birdTypeIndex], birdSpawnPoints[spawnPointIndex].position, birdSpawnPoints[spawnPointIndex].rotation);

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