using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TreantAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        //Access the seeker to generate path, invoking it immediately and repeats it every half a second
        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }

    void UpdatePath()
    {
        //Waits for the current path to complete before creating a new one
        if(seeker.IsDone())
         seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    //deletes the path once its detination has been met
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        
            return;
        //based on how far along the path, it decides if the end of the path has been met
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;
        }
        //maps each waypoint in a 2d location, using the current waypoint and the current location
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
        //checks how far along the waypoints is the enemy location
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        //once it has met the waypoint it updates to move to the next waypoint
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
