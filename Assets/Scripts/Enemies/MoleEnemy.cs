using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoleEnemy : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    public GameObject projectile;

    public HealthBar healthBar;
    public Health health;
    public GameObject coinPrefab;
    public GameObject deathPrefab;

    public int Shot;
    private bool canShoot;
    private float delayInSeconds = 2.5f;
    public ItemDrops itemDrops;
    // Start is called before the first frame update

    void Start()
    {
        //initialises all the important variables of the mole
        maxHealth = GameManager.difficulty * 100f;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        health.SetMaxHealthText(maxHealth);
        Shot = 0;
        canShoot = true;
    }
    void Update()
    {
        //prevents the mole from continuously firing projectiles at the player
        if(Shot == 1)
        {
            Shot = 0;
        }

        if(Shot == 0 && canShoot == true)
        {
            Shot = 1;
            Instantiate(projectile, transform.position, Quaternion.identity);
            canShoot = false;
            //delays when the mole can next fire a projectile utlising coroutines
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }
    public void SetEnemyHealth(int health)
    {
        maxHealth = health;
        Start();
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //begins the process of the enemy prefab being hit by a projectile
        if(other.CompareTag("Projectile"))
        {
          TakeDamage();
        }
        
    }

    public void TakeDamage()
    {
        //accesses the current damage value of the player, and give it to the prefab
        float damage2 = GameManager.damage;
        currentHealth -= damage2;
        healthBar.SetHealth(currentHealth);
        health.SetHealthText(currentHealth);
        
        if(currentHealth <= 0)
        {

            Die();
        }
    }

    public void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //updates the kill count in the manager
        GameManager.currentCount ++;
        Instantiate(deathPrefab, transform.position, Quaternion.identity);
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        itemDrops.SpawnRandomItemObject(transform);
        Destroy(gameObject);
        }

}
