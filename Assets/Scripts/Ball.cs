using UnityEngine;

public class Ball : MonoBehaviour
{

    //config params
    [Header("Velocity")]
    [SerializeField] float xLaunchVelocity = 2f;
    [SerializeField] float yLaunchVelocity = 10f;
    [SerializeField] float minBounceAngle = 10f;
    [Header("Rotation")]
    [SerializeField] float rotationFactor = 1f;
    [SerializeField] float torqueLimit = 10f;
    [Header("Audio")]
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] AudioClip reviveSound;
    [Header("Debug")]
    [SerializeField] float timeUntillReset = 1f;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    int framesSinceLastCollision;
    int comboFactor;

    //cached component references (so this valor is found only once)
    Rigidbody2D rigidBody2D;
    AudioSource audioSource;
    Paddle paddle;
    ScoreSystem scoreSystem;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        paddle = FindObjectOfType<Paddle>();
        scoreSystem = FindObjectOfType<ScoreSystem>();

        paddleToBallVector = transform.position - paddle.transform.position; //this is to calculate the difference between the paddle and ball positions
    }

    void Update()
    {
        if (!hasStarted)
        {
            FollowPaddle();
            LaunchOnMouseClick();
        }
        else
        {
            framesSinceLastCollision++;
        }

        ResetIfBugged();
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
            rigidBody2D.freezeRotation = false;
            hasStarted = true;
            rigidBody2D.velocity = new Vector2(xLaunchVelocity, yLaunchVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        framesSinceLastCollision = 0;

        AdjustBallVector();
        AddRotation();
        PlayDefaultSFX(collision);
        ActivateCombo(collision);
    }

    private void ActivateCombo(Collision2D collision)
    {
        if (hasStarted && (collision.gameObject.tag == "Breakable" || collision.gameObject.tag == "Paddle"))
        {
            comboFactor++;
        }
        else
        {
            comboFactor = 0;
        }
        Debug.Log(comboFactor);
    }
    public int ComboNumber()
    {
        return comboFactor;
    }

    private void AdjustBallVector()
    {
        float bounceAngle = Mathf.Atan2(rigidBody2D.velocity.y, rigidBody2D.velocity.x) * Mathf.Rad2Deg;
        float magnitude = rigidBody2D.velocity.magnitude;
        float newAngle = 0;
        if (IsNumInRange(bounceAngle, 0, 90))
        {
            newAngle = Mathf.Clamp(bounceAngle, minBounceAngle, 90 - minBounceAngle);
        }
        else if (IsNumInRange(bounceAngle, 90, 180))
        {
            newAngle = Mathf.Clamp(bounceAngle, 90 + minBounceAngle, 180 - minBounceAngle);
        }
        else if (IsNumInRange(bounceAngle, -90, 0))
        {
            newAngle = Mathf.Clamp(bounceAngle, -90 + minBounceAngle, -minBounceAngle);
        }
        else if (IsNumInRange(bounceAngle, -180, -90))
        {
            newAngle = Mathf.Clamp(bounceAngle, -180 + minBounceAngle, -90 - minBounceAngle);
        }
        Vector2 newVelocity = new Vector2(Mathf.Cos(newAngle * Mathf.Deg2Rad), Mathf.Sin(newAngle * Mathf.Deg2Rad)) * magnitude;
        rigidBody2D.velocity = newVelocity;
    }

    private bool IsNumInRange(float num, float min, float max)
    {
        return num >= min && num <= max;
    }

    private void AddRotation()
    {
        if (hasStarted)
        {
            float randomTorque = Random.Range(rotationFactor *-1, rotationFactor);
            rigidBody2D.AddTorque(Mathf.Clamp(randomTorque, torqueLimit*-1, torqueLimit));
        }
    }

    private void PlayDefaultSFX(Collision2D collision)
    {
        if (hasStarted && (collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Paddle"))
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }

    public void ResetBall()
    {
        rigidBody2D.rotation = 0; rigidBody2D.freezeRotation = true;
        hasStarted = false;
        comboFactor = 0;
        AudioSource.PlayClipAtPoint(reviveSound, Camera.main.transform.position);
    }

    public void ManageDeath()
    {
        ResetBall();
        scoreSystem.LoseScore();
    }

    private void ResetIfBugged()
    {
        float secondsPassed = (1 / Time.deltaTime) * timeUntillReset;
        if (framesSinceLastCollision >= secondsPassed)
        {
            ResetBall();
        }
        //Debug.Log(secondsPassed);
    }
}