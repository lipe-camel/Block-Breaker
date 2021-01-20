using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] float timeUntillRevive = 1f;
    [SerializeField] AudioClip deathSound;

    //cached component references
    Collider2D thisCollider2D;
    AudioSource audioSource;
    Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        thisCollider2D = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.PlayOneShot(deathSound);
        FindObjectOfType<ScoreSystem>().AddToDeathCount();
        Invoke("Revive", timeUntillRevive);
    }

    private void Revive()
    {
        ball.ManageDeath();
    }

    public void ToggleIsTrigger() //this is used fo debugging
    {
        thisCollider2D.isTrigger = !thisCollider2D.isTrigger;
    }
}
