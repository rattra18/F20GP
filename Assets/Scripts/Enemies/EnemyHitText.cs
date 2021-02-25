using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHitText : MonoBehaviour
{
    public Text hitValueTxt;
    private float delayInSeconds = 0.25f;

    public GameObject hitspawner1;
    public GameObject hitspawner2;
    public GameObject hitspawner3;

    private Vector3 spawnTextPosition;
    private Vector3 spawnTextPosition1;
    private Vector3 spawnTextPosition2;

    private int[] spawnIndex;

    private Vector3 randomVertices;

    void Start()
    {
        spawnIndex = new int[3];
        spawnIndex[0] = 0;
        spawnIndex[1] = 1;
        spawnIndex[2] = 2;
    }

    void Update()
    {
        //sets the location for damage info on each enemy prefab
        spawnTextPosition = hitspawner1.transform.position;
        spawnTextPosition1 = hitspawner2.transform.position;
        spawnTextPosition2 = hitspawner3.transform.position;
    }

    public void SetHitText(float damage)
    {
        //if an enemy is hit, it choses from random a location to display the hit damage
        int randomIndex = Random.Range(0, 3);
        int chosenIndex = spawnIndex[randomIndex];
        if( chosenIndex == 0)
        {
            transform.position = spawnTextPosition;
        } else if( chosenIndex == 1)
        {
            transform.position = spawnTextPosition1;
        } else if( chosenIndex == 2)
        {
            transform.position = spawnTextPosition2;
        }
        //displays the damage the prefab has taken
        hitValueTxt.text = damage.ToString();
        Debug.Log(damage);
        //starts a coroutine that will remove the text after a given time
        StartCoroutine(ChangeDelay());
    }

    public void ChangeHitText(float damage)
    {
        hitValueTxt.text = "";
    }

    IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        ChangeHitText(0f);
        
    }
}
