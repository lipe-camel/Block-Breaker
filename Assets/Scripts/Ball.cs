using UnityEngine;

public class Ball : MonoBehaviour
{

    //config params
    [SerializeField] Paddle paddle1;
    [Header("Launch")]
    [SerializeField] float xLaunchVelocity = 2f;
    [SerializeField] float yLaunchVelocity = 10f;
    [Header("Audio")]
    [SerializeField] AudioClip[] ballSounds;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cached component references
    Rigidbody2D rigidBody;
    AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        paddleToBallVector = transform.position - paddle1.transform.position; //this is to calculate the difference between the paddle and ball positions
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
        Vector2 paddlePos = paddle1.transform.position;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted && collision.gameObject.tag!="Block")
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }

}