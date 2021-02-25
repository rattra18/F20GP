using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Player : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    public GameObject projectile;
    public GameObject projectile2;

    public HealthBar healthBar;
    public Health health;

    public bool isMoving;
    public int  Shot;
    private float delayInSeconds = 0.375f;
    public bool canShoot;
    private int enemyCount;
    public float damage = 0.1f;

    private Transform enemy;

    public PauseMenu pauseMenu;

    public HitText hitText;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //initialises all the variables of the player
        maxHealth = 200f;
        maxHealth = GameManager.health;
        damage = damage * (GameManager.difficulty * 100f);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        health.SetMaxHealthText(maxHealth);
        Shot = 0;
        canShoot = true;

    }

    void Update()
    {
        //creates a list of all enemies in the screen, by searching for their tags
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("MoleEnemy").Length;
        //prevents the player from consitently firing projectiles
        if(Shot == 1)
        {
            Shot = 0;
        }
        //ensures that while the player is stationary can they fire a projectile
        if(isMoving != true && enemyCount != 0)
        {
            if(Shot == 0 && canShoot == true)
            {
                Shot = 1;
                LaunchProjectile(1);
                
                canShoot = false;
                //delays to when the next shot can be taken
                StartCoroutine(ShootDelay());
            }
        }
    }

    public void LaunchProjectile(int shotNumber)
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            //when collided with a treant the player takes the full damage based on the lvl
            TakeDamage(damage);
        } else if(other.CompareTag("Coin"))
            {
                GameManager.currentCoinCount ++;
                //updates the number coins in possesion if colided with a coin
                Destroy(other.gameObject);
            } else if(other.CompareTag("EnemyProjectile"))
            {
                //when collided with a projectile the player takes half the damage based on the lvl
                TakeDamage((damage / 2f));
            }
    }

    public void UpgradeHealth()
    {
        //checks if the players health has been upgraded
        maxHealth = GameManager.health;
        healthBar.UpdateMaxHealth(maxHealth);
    }

    public void IncreaseCurrentHealth(float health1)
    {
        //manages all the UI to do with representing the players health continuosly
        currentHealth += health1;
        healthBar.SetHealth(currentHealth);
        health.SetHealthText(currentHealth);
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        health.SetHealthText(currentHealth);
        hitText.SetHitText(damage);
        
        if(currentHealth <= 0)
        {
            pauseMenu.Died();
            gameManager.Died();
            //FindObjectOfType<GameManager>().EndGame();

        }
    }

    
}
