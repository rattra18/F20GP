using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitText : MonoBehaviour
{
    public Text hitValueTxt;
    private float delayInSeconds = 0.25f;


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
        //sets the location for damage info for the player
        spawnTextPosition = GameObject.FindGameObjectWithTag("PlayerHitBox1").transform.position;
        spawnTextPosition1 = GameObject.FindGameObjectWithTag("PlayerHitBox2").transform.position;
        spawnTextPosition2 = GameObject.FindGameObjectWithTag("PlayerHitBox3").transform.position;
    }

    public void SetHitText(float damage)
    {
        //if the player is hit, it choses from random a location to display the hit damage
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
        //displays the damage the player has taken
        hitValueTxt.text = damage.ToString("F0");
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
