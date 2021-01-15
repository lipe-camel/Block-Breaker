using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [Header("Audio")]
    [SerializeField] AudioClip[] destroySounds;
    [Header("Particle")]
    [SerializeField] GameObject BlockSparklesVFX;
    [SerializeField] float destroyVFXTime = 1f;
    [Header("Sprite")]
    [SerializeField] int maxHits =3;
    [SerializeField] Sprite[] hitSprites;

    //state
    int timesHit = 0;

    //cached component references
    Level level;
    GameSession gameSession;

    private void Start()
    {
        level = FindObjectOfType<Level>();              //this is needed so it can be linked to other game object (this is what I need to implement in other game projects)
        gameSession = FindObjectOfType<GameSession>();

        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (gameObject.tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            ManageBlockDestruction();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void ManageBlockDestruction()
    {
        PlayDestroyBlockSFX();
        PlayDestroyBlockVFX();
        level.CountBreakedBlocks();
        gameSession.AddToScore();
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
