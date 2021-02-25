using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text killCounterTxt;
    public int killCount;

    void Start()
    {
        //loads the number of kills if it has been saved
        killCount = GameManager.actCounter;
        SetKillCounterText();
    }
    
    public void SetKillCounterText()
    {
        killCounterTxt.text = killCount.ToString(); 
    }

    public void UpdateKillCounterText()
    {
        killCounterTxt.text = killCount.ToString();
    }
    
    void Update()
    {
        //continously checks if the number of kills has changed
        killCount = GameManager.actCounter;
        UpdateKillCounterText();
    }
}
