using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [Header("Launch")]
    [SerializeField] float xLaunchVelocity = 2f;
    [SerializeField] float yLaunchVelocity = 10f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    void Update()
    {
        if (!hasStarted)
        {
            FollowPaddle();
            LaunchOnMouseClick();
        }
    }

    private void FollowPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidBody.velocity = new Vector2(xLaunchVelocity, yLaunchVelocity);
        }
    }

}
