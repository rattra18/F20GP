using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    private int maxEnemies = 0;
    private int enemyCount;
    private Vector3 spawnerPosition;
    private Vector3 spawnerPosition1;
    private Vector3 spawnerPosition2;
    private Vector3 spawnerPosition3;

    public bool canSpawn = true;
    private float delayInSeconds = 2f;    
    public GameObject enemyPrefab;
    private int[] spawnIndex;

    private Vector3 randomVertices;

    void Start()
    {
        spawnIndex = new int[4];
        spawnIndex[0] = 0;
        spawnIndex[1] = 1;
        spawnIndex[2] = 2;
        spawnIndex[3] = 3;
        //accesses the potential spwan positions of the prefab
        spawnerPosition = GameObject.FindGameObjectWithTag("MoleSpawner").transform.position;
        spawnerPosition1 = GameObject.FindGameObjectWithTag("MoleSpawner1").transform.position;
        spawnerPosition2 = GameObject.FindGameObjectWithTag("MoleSpawner2").transform.position;
        spawnerPosition3 = GameObject.FindGameObjectWithTag("MoleSpawner3").transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //manages how many of the enemy prefab are currently alive based on the lvl difficulty
        if(GameManager.difficulty >= 1f && GameManager.difficulty < 1.1f)
        {
            maxEnemies = 0;
        }

        if(GameManager.difficulty >= 1.1f && GameManager.difficulty < 1.26f)
        {
            maxEnemies = 5;
        }
        if(GameManager.difficulty >= 1.26f && GameManager.difficulty < 1.51f)
        {
            maxEnemies = 6;
        }

        if(GameManager.difficulty >= 1.51f && GameManager.difficulty < 1.75f)
        {
            maxEnemies = 7;
        }

        if(GameManager.difficulty >= 1.75f && GameManager.difficulty < 2.01f)
        {
            maxEnemies = 8;
        }

        if(GameManager.difficulty >= 2.01f && GameManager.difficulty < 2.26f)
        {
            maxEnemies = 9;
        }

        if(GameManager.difficulty >= 2.26f && GameManager.difficulty < 2.51f)
        {
            maxEnemies = 10;
        }

        if(GameManager.difficulty >= 2.51f && GameManager.difficulty < 2.76f)
        {
            maxEnemies = 11;
        }

        if(GameManager.difficulty >= 2.76f && GameManager.difficulty < 3.01f)
        {
            maxEnemies = 12;
        }

        if(GameManager.difficulty >= 3.01f)
        {
            maxEnemies = 15;
        }

        //finds all the tags of mole prefabs in the game
        enemyCount = GameObject.FindGameObjectsWithTag("MoleEnemy").Length;
        //only when the number of moles is less than the max does one spawn
        if (enemyCount < maxEnemies && canSpawn == true)
        {
            //chooses a random loaction for the next mole to spawn
            int randomIndex = Random.Range(0, 4);
            int chosenIndex = spawnIndex[randomIndex];
            randomVertices = new Vector3 (Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
            if( chosenIndex == 0)
            {
                Instantiate(enemyPrefab, spawnerPosition + randomVertices, Quaternion.identity);
            } else if( chosenIndex == 1)
            {
                Instantiate(enemyPrefab, spawnerPosition1 + randomVertices, Quaternion.identity);
            } else if( chosenIndex == 2)
            {
                Instantiate(enemyPrefab, spawnerPosition2 + randomVertices, Quaternion.identity);
            } else if( chosenIndex == 3)
            {
                Instantiate(enemyPrefab, spawnerPosition3 + randomVertices, Quaternion.identity);
            }
            //delays how quickly the enemy is replenshied to prevent the player being overwhelmed
            canSpawn = false;
            StartCoroutine(SpawnDelay());
        }
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canSpawn = true;
    }
}
