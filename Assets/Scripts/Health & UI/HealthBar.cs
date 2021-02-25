using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider slider;
    //manages the health bar of the player, updating it after the player has been hit or when the max health has been upgraded
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health; 
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void UpdateMaxHealth(float health)
    {
        slider.maxValue = health;
    }
}
