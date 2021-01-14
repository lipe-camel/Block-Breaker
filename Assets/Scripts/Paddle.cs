using UnityEngine;

public class Paddle : MonoBehaviour
{
    //    //config params
    [SerializeField] float horizontalScreenUnits = 16f;
    [SerializeField] float minxPos = 1f;
    [SerializeField] float maxPos = 15f;

    void Update()
    {
        ManagePaddleMovement();
    }

    private void ManagePaddleMovement()
    {
        float getMouseXPos = Input.mousePosition.x / Screen.width * horizontalScreenUnits;      //for the number to be between zero and 1, then multiplied for the horizontal unity units
        Vector2 paddlePos = gameObject.transform.position;                                      //also can be written new Vector2(transform.position.x, transform.position.y)
        paddlePos.x = Mathf.Clamp(getMouseXPos, minxPos, maxPos);                               //calculate the x position
        transform.position = paddlePos;                                                         //applying the x position
    }
}
