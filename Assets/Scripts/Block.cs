using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [Header("Audio")]
    [SerializeField] AudioClip[] collisionSounds;
    [SerializeField] AudioClip[] destroySounds;
    [Header("Particle")]
    [SerializeField] GameObject BlockDestructionVFX;
    [SerializeField] GameObject BlockDamageVFX;
    [SerializeField] Vector3 particleOffset;
    [SerializeField] float destroyVFXTime = 1f;
    [Header("Sprite")]
    [SerializeField] Sprite[] hitSprites;

    //state
    int timesHit = 0;

    //cached component references
    Level level;
    ScoreSystem scoreSystem;

    private void Start()
    {
        //assigning valors of cached references
        level = FindObjectOfType<Level>();
        scoreSystem = FindObjectOfType<ScoreSystem>();

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
        if(gameObject.tag == "Breakable" && collision.gameObject.tag == "Ball")
        {
            HandleHit();
        }
        if (gameObject.tag == "Unbreakable" && collision.gameObject.tag == "Ball")
        {
            HandleUnbreakableHit();
        }
    }

    private void HandleUnbreakableHit()
    {
        AudioClip clip = collisionSounds[Random.Range(0, collisionSounds.Length)];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            ManageBlockDestruction();
        }
        else
        {
            ManageBlockDamage();
        }
    }

    private void ManageBlockDamage()
    {
        ShowNextHitSprite();
        PlayDamageSFX();
        PlayDamageVFX();
        scoreSystem.AddToScore();

    }

    private void PlayDamageSFX()
    {
        int randomCollisionSound = Random.Range(0, collisionSounds.Length);

        if (collisionSounds[randomCollisionSound] != null)
        {
            AudioClip clip = collisionSounds[randomCollisionSound];
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        }
        else
        {
            Debug.LogError(gameObject.name + " collision audio is missing from array");
        }
    }

    private void PlayDamageVFX()
    {
        GameObject vFX = Instantiate(BlockDamageVFX, transform.position + particleOffset, transform.rotation);
        Destroy(vFX, destroyVFXTime);

    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(gameObject.name + " sprite is missing from array");
        }
    }

    private void ManageBlockDestruction()
    {
        PlayDestroyBlockSFX();
        PlayDestroyBlockVFX();
        level.CountBreakedBlocks();
        scoreSystem.AddToScore();
        Destroy(gameObject);
    }

    private void PlayDestroyBlockSFX()
    {
        AudioClip clip = destroySounds[Random.Range(0, destroySounds.Length)];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void PlayDestroyBlockVFX()
    {
        GameObject vFX = Instantiate(BlockDestructionVFX, transform.position + particleOffset, transform.rotation);
        Destroy(vFX, destroyVFXTime);
    }
}
