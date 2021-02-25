using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public Text currentLevelTxt;
    public Text nextLevelTxt;

    public int currentLvl;
    private int nextLvl;

    void Update()
    {
        SetLevelTexts();
    }

    void Start()
    {
        //loads the current lvl, and setting the text value to it
        currentLvl = GameManager.lvlCounter;
        nextLvl = currentLvl + 1;
        SetLevelTexts();
    }
    
    public void SetLevelTexts()
    {
        currentLvl = GameManager.lvlCounter;
        nextLvl = currentLvl + 1;

        currentLevelTxt.text = currentLvl.ToString();
        nextLevelTxt.text = nextLvl.ToString(); 
    }
}
