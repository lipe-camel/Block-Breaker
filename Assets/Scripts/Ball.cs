using UnityEngine;

public class Ball : MonoBehaviour
{

    //config params
    [Header("Velocity")]
    [SerializeField] float xLaunchVelocity = 2f;
    [SerializeField] float yLaunchVelocity = 10f;
    //[SerializeField] float bounceRandomFactor = 0.2f;
    [Header("Audio")]
    [SerializeField] AudioClip[] ballSounds;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cached component references (so this valor is found only once)
    Rigidbody2D rigidBody2D;
    AudioSource audioSource;
    Paddle paddle;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        paddle = FindObjectOfType<Paddle>();

        paddleToBallVector = transform.position - paddle.transform.position; //this is to calculate the difference between the paddle and ball positions
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
        Vector2 paddlePos = paddle.transform.position;
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidBody2D.velocity = new Vector2(xLaunchVelocity, yLaunchVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector2 velocityTweak = new Vector2(Random.Range(0f, ), Random.Range(0f, bounceRandomFactor));
        if (hasStarted && collision.gameObject.tag!="Breakable")
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            //rigidBody2D.velocity += velocityTweak;
        }
    }
}