using UnityEngine;

public class LoseCollider : MonoBehaviour
{
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
        ball.ManageDeath();
    }

    public void ToggleIsTrigger() //this is used fo debugging
    {
        thisCollider2D.isTrigger = !thisCollider2D.isTrigger;
    }
}
