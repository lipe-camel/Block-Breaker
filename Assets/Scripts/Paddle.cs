using UnityEngine;

public class Paddle : MonoBehaviour
{
    //    //config params
    [SerializeField] float horizontalScreenUnits = 16f;
    [SerializeField] float minxPos = 1f;
    [SerializeField] float maxPos = 15f;

    //state
    bool autoplayIsActive;

    //cached references
    Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        ManagePaddleMovement();
    }

    private void ManagePaddleMovement()
    {
        Vector2 paddlePos = gameObject.transform.position;                                       //also can be written new Vector2(transform.position.x, transform.position.y)
        paddlePos.x = Mathf.Clamp(GetXPos(), minxPos, maxPos);                                        //calculate the x position and also limit the x position
        transform.position = paddlePos;                                                          //applying the x position
    }

    private float GetXPos()
    {
        if (autoplayIsActive)
        {
            return ball.transform.position.x;                                                   //used for debugging
        }
        else
        {
            return Input.mousePosition.x / Screen.width * horizontalScreenUnits;                //for the number to be between zero and 1, then multiplied for the horizontal unity units
        }
    }

    public void ToggleAutoplay()
    {
        autoplayIsActive = !autoplayIsActive;
    }
}
