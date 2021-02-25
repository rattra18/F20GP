using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyProjectile : MonoBehaviour
{
    private float speed = 7.5f;

    private Transform enemy;
    private Vector2 target;
    private float delayInSeconds = 1f;

    public Rigidbody2D rb;

    Vector2 targetPos;

    public GameObject explosionPrefab;

    void Start()
    {
        try 
        { 
            
            //sets the target location for the player
            enemy = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector2(enemy.position.x, enemy.position.y);

            //for every bullet that is instantiated, they are set to face the players location
            Vector2 lookDir = target - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90;
            rb.rotation = angle;
            
        } catch(Exception)
        {
        }      
    }

    void FixedUpdate()
    {

        //Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        //rb.MovePosition(newPosition);
        //moves the projectile in the direction it has been set to face
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //conditions for anything the projectile may hit, upon contact it is destoryed
        if(other.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            DestroyProjectile();
        }

        if(other.CompareTag("Canvas1"))
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
