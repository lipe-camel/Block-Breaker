using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] float timeUntillRevive = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip reviveSound;

    //cached component references
    Collider2D thisCollider2D;
    Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        thisCollider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        Invoke("Revive", timeUntillRevive);
    }

    private void Revive()
    {
        AudioSource.PlayClipAtPoint(reviveSound, Camera.main.transform.position);
        ball.ManageDeath();
    }

    public void ToggleIsTrigger() //this is used fo debugging
    {
        thisCollider2D.isTrigger = !thisCollider2D.isTrigger;
    }
}
