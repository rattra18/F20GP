using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 6f;

    public Rigidbody2D rb;
    public Animator animator;
    private Player player;

    Vector2 movement;

    public Joystick joystick;

    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets the movement data based on the joysticks position
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        //updates the variable ismoving if there is any movement data
        player.isMoving = movement.x != 0f || movement.y != 0f;

        movement = movement.normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
