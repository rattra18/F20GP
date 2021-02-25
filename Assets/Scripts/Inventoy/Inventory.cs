using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    public static Inventory instance;
    public List<Item> items = new List<Item>();

    void Awake()
    {
        //creates an inventory system for the player
        if(instance != null)
        {
            Debug.LogWarning("More than one instance  of inventory found!");
            return;
        }
        instance = this;
    }

    void Start()
    {
        //if the game was saved during loading it adds the list of items into the initliased inventory
        int i = 0;
        foreach(Item item in GameManager.items)
        {
            items.Add(item);
        }
        i++;

    }

    public void Add (Item item)
    {
        if(!item.isDefaultItem)
        {
            items.Add(item);
            GameManager.items.Add(item);
            GameManager.newItem = true;

            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        GameManager.items.Remove(item);
        GameManager.newItem = true;

        if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
    }
}
