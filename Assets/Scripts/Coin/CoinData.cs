using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinData
{
    public int level;
    public int killCount;
    public int coins;

    public CoinData(GameManager gameManager)
    {
        coins = GameManager.actCoins;
    }
}
