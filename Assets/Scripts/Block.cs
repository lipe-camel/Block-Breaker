using UnityEngine;

public class Block : MonoBehaviour
{

    //config params
    [SerializeField] AudioClip[] destroySounds;
    [SerializeField] GameObject BlockSparklesVFX;
    [SerializeField] float destroyVFXTime = 1f;


    //cached component references
    Level level;
    GameSession gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();              //this is needed so it can be linked to other game object (this is what I need to implement in other game projects)
        gameStatus = FindObjectOfType<GameSession>();

        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ManageBlockDestruction();
    }

    private void ManageBlockDestruction()
    {
        PlayDestroyBlockSFX();
        PlayDestroyBlockVFX();
        level.CountBreakedBlocks();
        gameStatus.AddToScore();
        Destroy(gameObject);
    }

    private void PlayDestroyBlockSFX()
    {
        AudioClip clip = destroySounds[Random.Range(0, destroySounds.Length)];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void PlayDestroyBlockVFX()
    {
        GameObject sparkles = Instantiate(BlockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, destroyVFXTime);
    }
}
