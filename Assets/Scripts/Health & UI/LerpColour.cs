using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpColour : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float lerpTime;

    [SerializeField] Color[] myColors;

    int colorIndex = 0;

    int len;

    float t = 0f;
    Image panel;
    // Start is called before the first frame update
    void Start()
    {
        len  = myColors.Length;
        panel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //shifts the colour between the two values based on the framerate of the screen, ensuring it is smooth
        panel.color = Color.Lerp(panel.color, myColors[colorIndex], lerpTime * Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if(t > 0.9f)
        {
            t = 0f;
            colorIndex ++;
            colorIndex = (colorIndex >= len) ? 0: colorIndex;
        }
    }
}
