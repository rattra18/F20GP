using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantEnemy : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    public HealthBar healthBar;
    public Health health;
    public float repeatDelay = 1f;
    public GameObject coinPrefab;
    public GameObject deathPrefab;
    public ItemDrops itemDrops;

    // Start is called before the first frame update

    void Start()
    {
        maxHealth = GameManager.difficulty * 50f;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        health.SetMaxHealthText(maxHealth);
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Projectile"))
        {
          TakeDamage();
        }
        
    }

    public void TakeDamage()
    {
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
        GameManager.currentCount ++;
        Instantiate(deathPrefab, transform.position, Quaternion.identity);
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        itemDrops.SpawnRandomItemObject(transform);
        Destroy(gameObject);
        }

}
