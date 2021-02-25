using UnityEngine;
using UnityEngine.UI;

public class DeathCounters : MonoBehaviour
{
    public Text killValuesTxt;
    public Text highestKillsValueTxt;
    
    public void SetValuesText(int kills)
    {
        string text = "KILLS: " + kills.ToString();
        killValuesTxt.text = text; 
    }

    public void SetHighestValuesText(int kills, bool newHighest)
    {
        if(newHighest == true)
        {
            //brings up the new highest score if it has been met
            string textHighest = "NEW HIGHEST: " + kills.ToString();
            highestKillsValueTxt.text = textHighest;
        } else if(newHighest == false)
        {
            //sets the text to the current highest score that has been saved
            string textHighest = "HIGHEST KILLS: " + kills.ToString();
            highestKillsValueTxt.text = textHighest;
        }
    }
}
