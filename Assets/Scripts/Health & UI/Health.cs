using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthValueTxt;

    
    public void SetMaxHealthText(float health)
    {
        healthValueTxt.text = health.ToString("F0"); 
    }

    public void SetHealthText(float health)
    {
        healthValueTxt.text = health.ToString("F0");
    }
}
