using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //setting all the data which is important for the progress of the game
    public int level;
    public int killCount;
    public int coins;
    public float difficulty;
    public int highestKill;
    public float damage;
    public float DamageUpgradeCounter;
    public float health;
    public List<Item> items = new List<Item>();

    public GameData(GameManager gameManager)
    {
        level = GameManager.lvlCounter;
        killCount = GameManager.actCounter;
        coins = GameManager.actCoins;
        difficulty = GameManager.difficulty;
        highestKill = GameManager.highestKills;
        damage = GameManager.damage;
        DamageUpgradeCounter = GameManager.coinUpgradeCounter;
        health = GameManager.health;
        items = GameManager.items;
    }
}
