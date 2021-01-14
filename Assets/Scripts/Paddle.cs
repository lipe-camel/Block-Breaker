using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float horizontalScreenUnits = 16f;
    [SerializeField] float minxPos = 1f;
    [SerializeField] float maxPos = 15f;


    void Update()
    {
        float getMouseXPos = Input.mousePosition.x / Screen.width * horizontalScreenUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(getMouseXPos, minxPos, maxPos);
        transform.position = paddlePos;
    }
}
