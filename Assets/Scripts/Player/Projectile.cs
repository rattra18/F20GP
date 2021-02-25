using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private float speed = 25;

    private Transform enemy;
    private Vector2 target;
    private float delayInSeconds = 0.125f;

    public Rigidbody2D rb;

    Vector2 targetPos;

    public GameObject explosionPrefab;

    private GameObject closest;

    public float min = 1f;
    public float max = 1000f;

    public float distance = Mathf.Infinity;

    void Start()
    {
        //upon initlisation of the projetile it searches for the nearest enemy
        FindClosestEnemy();
        try 
        { 
            

            enemy = closest.transform;
            target = new Vector2(enemy.position.x, enemy.position.y);
            //once the closest enemy has been found it changes it rotation to face this enemy
            Vector2 lookDir = target - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90;
            rb.rotation = angle;
            
        } catch(Exception)
        {
        }      
    }
    public void FindClosestEnemy()
    {
        //searches for all enemy tags and concatenates them to one searchable array
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] gos1 = GameObject.FindGameObjectsWithTag("MoleEnemy");
        GameObject[] allGos = gos.Concat(gos1).ToArray();
        closest = null;
        Vector3 position = transform.position;
        
        min = min * min;
        max = max * max;
        //goes through each enemy object in the array
        foreach (GameObject go in allGos)
        {
            //calculates the distance between the enemy and the players projectile
            Vector3 diff = go.transform.position - position;
            //sets the current closest distance to the absoloute distance
            float curDistance = diff.sqrMagnitude;
            //checks whether or not that enemy is closer to any previous enemy
            if (curDistance < distance && curDistance >= min && curDistance <= max)
            {
                //which if one is found to be closer it updates the closest varaible to the enemy object that is currently being checked
                closest = go;
                distance = curDistance;
            }
        }
        //return closest;
    }

    void FixedUpdate()
    {

        //Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        //rb.MovePosition(newPosition);

        //as the projectile has previously been set to face the enemy, here it moves towards it
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //collision checks for the enemies or any wall the projectile may hit if it missed
        if(other.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }

        if(other.CompareTag("MoleEnemy"))
        {
            DestroyProjectile();
        }

        if(other.CompareTag("Canvas"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            DestroyProjectile();
        }
        
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
