using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesDictionary : MonoBehaviour
{

    public static Dictionary<int, string> itemsSprite = new Dictionary<int, string>();

    void Start()
    {
        itemsSprite[0] = "coin-1";
    }
}
