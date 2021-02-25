using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int maxEnemies = 5;
    private int enemyCount;
    private Vector3 spawnerPosition;
    private Vector3 spawnerPosition1;
    
    public bool canSpawn = true;
    private float delayInSeconds = 0.25f;    
    public GameObject enemyPrefab;
    private int[] spawnIndex;

    void Start()
    {
        spawnIndex = new int[2];
        spawnIndex[0] = 0;
        spawnIndex[1] = 1;
        //creates the locations where te enemy can spawn
        spawnerPosition = GameObject.FindGameObjectWithTag("Spawner").transform.position;
        spawnerPosition1 = GameObject.FindGameObjectWithTag("Spawner1").transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //manages how many enemies can be present based on the difficulty of the lvl
        if(GameManager.difficulty >= 1f && GameManager.difficulty < 1.26f)
        {
            maxEnemies = 8;
        }
        if(GameManager.difficulty >= 1.26f && GameManager.difficulty < 1.51f)
        {
            maxEnemies = 10;
        }

        if(GameManager.difficulty >= 1.51f && GameManager.difficulty < 1.75f)
        {
            maxEnemies = 12;
        }

        if(GameManager.difficulty >= 1.75f && GameManager.difficulty < 2.01f)
        {
            maxEnemies = 14;
        }

        if(GameManager.difficulty >= 2.01f && GameManager.difficulty < 2.26f)
        {
            maxEnemies = 16;
        }

        if(GameManager.difficulty >= 2.26f && GameManager.difficulty < 2.51f)
        {
            maxEnemies = 18;
        }

        if(GameManager.difficulty >= 2.51f && GameManager.difficulty < 2.76f)
        {
            maxEnemies = 20;
        }

        if(GameManager.difficulty >= 2.76f && GameManager.difficulty < 3.01f)
        {
            maxEnemies = 22;
        }

        if(GameManager.difficulty >= 3.01f)
        {
            maxEnemies = 25;
        }
        //checks how many enemies are currently present in the lvl
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount < maxEnemies && canSpawn == true)
        {
            //if there aren't enough present it randomly choses between the two spawner locations
            int randomIndex = Random.Range(0, 2);
            int chosenIndex = spawnIndex[randomIndex];
            if( chosenIndex == 0)
            {
                Instantiate(enemyPrefab, spawnerPosition, Quaternion.identity);
            } else if( chosenIndex == 1)
            {
                Instantiate(enemyPrefab, spawnerPosition1, Quaternion.identity);
            }
            //delays when the next enemy can be instantiated, to prevent overwhelming the player
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
