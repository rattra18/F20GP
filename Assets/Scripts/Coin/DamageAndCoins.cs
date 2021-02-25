using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAndCoins : MonoBehaviour
{

    public Skills skills;
    public float DamageUpgradeCost;

    public void Start()
    {
        DamageCostCalulator();
    }

    public void DamageCostCalulator()
    {
        if(GameManager.coinUpgradeCounter == 0)
        {
            //sets the price of the upgrade based on the number of times it has already been upgraded after loading
            GameManager.coinUpgradeCounter = 1;
            DamageUpgradeCost = (GameManager.coinUpgradeCounter * (GameManager.coinUpgradeCounter + 100f)) /2.5f;
            skills.SetCostText(DamageUpgradeCost);
        } else if( GameManager.coinUpgradeCounter >=0)
        {
            DamageUpgradeCost = (GameManager.coinUpgradeCounter * (GameManager.coinUpgradeCounter + 100f)) /2.5f;
            skills.SetCostText(DamageUpgradeCost);
        }
    }
}
