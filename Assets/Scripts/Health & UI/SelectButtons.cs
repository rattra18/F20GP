using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtons : MonoBehaviour
{
    public Button EquipmetButton;
    public Button PlayButton;
    public Button SkillsButton;

    public int currentIndex;

    public void GetPosition(int index)
    {
        currentIndex = index;
    }

    void Start()
    {
        currentIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentIndex)
        {
            case 2:
                EquipmetButton.Select();
                break;
            case 1:
                PlayButton.Select();
                break;
            case 0:
                SkillsButton.Select();
                break;
        }
    }
}
