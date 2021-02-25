using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public Text UpgradeCounterValuesTxt;
    public Text DamageValuesTxt;
    public Text CoinCostText;
    
    public void SetValuesText(float damage)
    {
        string text = "DAMAGE: " + damage.ToString();
        DamageValuesTxt.text = text; 
    }

    public void SetCounterText()
    {
        string text = "UPGRADE: " + GameManager.coinUpgradeCounter;
        UpgradeCounterValuesTxt.text = text;
    }

    public void SetCostText(float cost)
    {
        string text = cost.ToString();
        SetCounterText();
        CoinCostText.text = text; 
    }
}
