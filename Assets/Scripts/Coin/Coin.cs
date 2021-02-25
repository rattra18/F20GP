using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{

    public float Speed = 10;
    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        try 
        {
            //Searches for the player, and sets it as a destination
            player = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector2(player.position.x, player.position.y);   
        } catch(Exception)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        //begins to move the coin towards the player, based on the framerate of the screen
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        Start();
    }
}
