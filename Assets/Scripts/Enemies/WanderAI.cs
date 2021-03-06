﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class WanderAI : MonoBehaviour
{
    public float wanderSpeed;
    float currentSpeed;

    public float directionChangeInterval;
    Coroutine moveCoroutine;

    Rigidbody2D rb2d;


    Vector3 endPosition;
    float currentAngle = 0;

    void Start()
    {
        currentSpeed = wanderSpeed;
        rb2d = GetComponent<Rigidbody2D>();

        StartCoroutine(WanderRoutine());
    }

    public IEnumerator WanderRoutine()
    {
        while (true)
        {
            ChooseNewEndpoint();

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));

            // wait directionChangeInterval seconds then change direction
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void ChooseNewEndpoint()
    {
        currentAngle += Random.Range(0, 360); // degrees

        // if currentAngle is greater than 360, loop so it starts at 0 again, keeping the value between 0 and 360
        currentAngle = Mathf.Repeat(currentAngle, 360);
        endPosition += Vector3FromAngle(currentAngle);
    }

    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        // equal to (PI * 2) / 360, the degrees to radians conversion constant
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;

        return new Vector3(Mathf.Cos(inputAngleRadians), Mathf.Sin(inputAngleRadians), 0);
    }

    public IEnumerator Move(Rigidbody2D rigidBodyToMove, float speed)
    {
        float remainingDistance = (transform.position - endPosition).sqrMagnitude;

        while (remainingDistance > float.Epsilon)
        {

            if (rigidBodyToMove != null)
            {
                Vector3 newPosition = Vector3.MoveTowards(rigidBodyToMove.position, endPosition, speed * Time.deltaTime);
                rb2d.MovePosition(newPosition);
                remainingDistance = (transform.position - endPosition).sqrMagnitude;
            }
            yield return new WaitForFixedUpdate();
        }

        // enemy has reached endPosition and waiting for new direction selection
    }
}
