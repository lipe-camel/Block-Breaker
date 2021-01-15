using UnityEngine;

public class Block : MonoBehaviour
{

    //config params
    [SerializeField] AudioClip[] destroySounds;

    //cached component references
    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();              //this is needed so it can be linked to other game object (this is what I need to implement in other game projects)
        gameStatus = FindObjectOfType<GameStatus>();

        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ManageBlockDestruction();
    }

    private void ManageBlockDestruction()
    {
        AudioClip clip = destroySounds[Random.Range(0, destroySounds.Length)];

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        level.CountBreakedBlocks();
        gameStatus.AddToScore();
        Destroy(gameObject);
    }
}
