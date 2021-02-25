using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded;

    public float restartDelay = 0.125f;
    public static int currentCount = 0;
    public static int currentCoinCount = 0;

    public static int actCounter;
    public static int actCoins;
    public static int lvlCounter;
    public static float difficulty;
    public static int highestKills;
    public static float damage;
    public static float health;
    public static float coinUpgradeCounter;
    public static List<Item> items;
    public static bool newItem = false;

    private int myKillCount;
    private int killCount;
    private int myCoinCount;
    private int coinCount;

    public int firstRun;    

    
    private int lastDigit;

    private bool NewHighest;

    public float DamageUpgradeCost;

    public DeathCounters deathCounters;
    public Skills skills;
    public Player player;
    

    void Awake()
    {   
        gameHasEnded = false;    
        killCount = 0;
        myKillCount = 0;
        coinCount = 0;
        myCoinCount = 0;
        NewHighest = false;
        items = new List<Item>();

        //checks if the game has been played before
        firstRun = PlayerPrefs.GetInt("firstRun");
        if(firstRun == 0)
        {
            //if it hasn't been played before it initialises all of the variables
            PlayerPrefs.SetInt("firstRun", 1);
            actCounter = 0;
            actCoins = 0;
            lvlCounter = 0;
            difficulty = 1;
            highestKills = 0;
            damage = 70f;
            health = 200f;
            coinUpgradeCounter = 1f;

        } else
        {
            //if the manager has detected that the game has been played, it attempts to load any data and configures the difficulty the game will start at
            LoadGame();
            SetDifficulty();
        }
    }

    void Start()
    {
        //manages the last checkpoints value
        lastDigit = (lvlCounter % 10);
        lvlCounter = lvlCounter - lastDigit;
        actCounter = lvlCounter * 10;

        SetDifficulty();

        skills.SetValuesText(damage);

        currentCost();
        skills.SetCostText(DamageUpgradeCost);
        if(damage < 70f)
        {
            damage = 70f;
        }
    }

    public void Died()
    {
        deathCounters.SetValuesText(actCounter);
        deathCounters.SetHighestValuesText(highestKills, NewHighest);
    }

    public void currentCost()
    {
        if(coinUpgradeCounter < 1)
        {
            //calculates the cost of updraging based on the preivous number of upgrades
            coinUpgradeCounter = 1;
            DamageUpgradeCost = (coinUpgradeCounter * (coinUpgradeCounter + 100f)) /1.5f;
        } else if(coinUpgradeCounter >=0)
        {
            DamageUpgradeCost = (coinUpgradeCounter * (coinUpgradeCounter + 100f)) /1.5f;
            
        }
    }

    public void DamageInc()
    {
        //creates and upgrade conditions where every 10th upgrade is more powerful
        currentCost();
        if(actCoins >= DamageUpgradeCost)
        {
            if(coinUpgradeCounter % 10 == 0 && coinUpgradeCounter != 70)
            {
                damage += 2.5f;
                health += 2.5f;
                player.IncreaseCurrentHealth(2.5f);
            } else
            {
                damage += 5f/6f;
                health += 5f/6f;
                player.IncreaseCurrentHealth(5f/6f);
            }
            
            actCoins -= (int)DamageUpgradeCost;
            skills.SetValuesText(damage);
            player.UpgradeHealth();
            coinUpgradeCounter ++;
            currentCost();
            skills.SetCostText(DamageUpgradeCost);
            SaveGame();
        }
    }


    void Update()
    {
        if(newItem == true)
        {
            SaveGame();
            newItem = false;
        }
        //checks for whether or not the highest kill count has been met
        if(actCounter > highestKills)
        {
            highestKills = actCounter;
            NewHighest = true;
        }
        killCount = currentCount;
        coinCount = currentCoinCount;
        //compares two variables tracking the number of coins, and updating the actualt number of coins based on these
        if(myCoinCount != coinCount)
        {
            myCoinCount = coinCount;
            float difficulty1 = difficulty * 10f;
            actCoins = actCoins + (int)difficulty1;
        }

        //updates how many kills have been counted
        if(myKillCount != killCount)
        {
            myKillCount = killCount;
            actCounter ++;
            //this is used to calculate what lvl the player is on, and once they have passed 10 waves the game is saved
            if(actCounter % 10 == 0 && actCounter != 0)
            {
                lvlCounter ++;
                SetDifficulty();
                SaveGame();
            }
        }
    }

    public void SetDifficulty()
    {
        float lvlCount = (float)lvlCounter;
        difficulty = 1f + lvlCount /100f;
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Restart();
        }
        
    }

    void Restart()
    {
        SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Refresh()
    {
        actCounter = 0;
        lvlCounter = 0;
        actCoins = 0;
        highestKills = 0;
        damage = 70f;
        coinUpgradeCounter = 0;
        health = 200f;
        items = new List<Item>();
        SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        //initialises variables to any saved data
        GameData data = SaveSystem.LoadGame();
        lvlCounter = data.level;
        actCounter = data.killCount;
        actCoins = data.coins;
        difficulty = data.difficulty;
        highestKills = data.highestKill;
        damage = data.damage;
        coinUpgradeCounter = data.DamageUpgradeCounter;
        health = data.health;
        items = new List<Item>();
        items = data.items;
    }
}
