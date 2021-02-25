using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text CoinCounterTxt;
    private int coinCount;

    void Start()
    {
        //sets the counter to what has been loaded by any previous games
        coinCount = GameManager.actCoins;
        SetCoinCounterText();
    }
    
    public void SetCoinCounterText()
    {
        //sets the counter to the loaded value
        CoinCounterTxt.text = coinCount.ToString(); 
    }

    public void UpdateCoinCounterText()
    {
        //updates the counter during gameplay
        CoinCounterTxt.text = coinCount.ToString();
    }

    void Update()
    {
        //constantly updates the counter value
        coinCount = GameManager.actCoins;
        UpdateCoinCounterText();

    }
}
