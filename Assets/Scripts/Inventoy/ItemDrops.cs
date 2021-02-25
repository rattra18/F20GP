using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrops : MonoBehaviour
{
    public List<GameObject> itemListObjects = new List<GameObject>();

    void Start()
    {
        //if loading a saved game it adds the list of each item into the list of actual items
        Object[] subItemListObjects = Resources.LoadAll("Items", typeof(GameObject));

        foreach (GameObject subItemListObject in subItemListObjects)
        {
            itemListObjects.Add(subItemListObject);
        }
    }

    public void SpawnRandomItemObject(Transform enemy)
    {
        //sets the chance of an item spawning when an enemy is killed
        int spawnChance = Random.Range(0, 99);
        if(spawnChance == 49)
        {
            int numItems = itemListObjects.Count;
            int whichItem = Random.Range(0, numItems);
            GameObject myObj = (itemListObjects[whichItem]);
            //instantiating a prefab at the location of the death of the enemy
            Instantiate(myObj, enemy.position, Quaternion.identity);
        }
    }
}
