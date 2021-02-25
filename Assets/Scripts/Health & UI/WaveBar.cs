using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    
    public Slider slider;
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;
    private int maxVal = 1;
    private int startVal = 0;
    
    private int myKillCount;
    private int actKillCount;
    private int maxCounter = 10;
    private int lvlCounter;

    void Start()
    {
        actKillCount = GameManager.actCounter;
        myKillCount = 0;
        lvlCounter = 0;

        slider.maxValue = maxVal;
        slider.value = startVal;

        slider1.maxValue = maxVal;
        slider1.value = startVal;

        slider2.maxValue = maxVal;
        slider2.value = startVal;

        slider3.maxValue = maxVal;
        slider3.value = startVal;

        slider4.maxValue = maxVal;
        slider4.value = startVal;
    }

    public void IncrementLvlCounter()
    {
        if(lvlCounter >=  maxCounter)
        {
            lvlCounter = 0;
            slider.value = startVal;
            slider1.value = startVal;
            slider2.value = startVal;
            slider3.value = startVal;
            slider4.value = startVal;
        }
    }

    void Update()
    {
        //updates the wave counter based on the number of kills within the current lvl
        actKillCount = GameManager.actCounter;
        IncrementLvlCounter();
        if(myKillCount != actKillCount)
        {
            myKillCount = actKillCount;
            lvlCounter++;
        }


        if(lvlCounter >=2)
        {
            slider.value = maxVal;
        }

        if(lvlCounter >=4)
        {
            slider1.value = maxVal;
        }

        if(lvlCounter >=6)
        {
            slider2.value = maxVal;
        }

        if(lvlCounter >=8)
        {
            slider3.value = maxVal;
        }

        if(lvlCounter >=10)
        {
            slider4.value = maxVal;
        }
    }
}
