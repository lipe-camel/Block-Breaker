using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [Header("Audio")]
    [SerializeField] AudioClip[] collisionSounds;
    [SerializeField] AudioClip[] destroySounds;
    [SerializeField] AudioClip[] vocalizedDeathSounds;
    [Header("Particle")]
    [SerializeField] GameObject BlockDestructionVFX;
    [SerializeField] GameObject BlockDamageVFX;
    [SerializeField] Vector3 particleOffset;
    [SerializeField] float destroyVFXTime = 1f;
    [Header("Sprite")]
    [SerializeField] Sprite[] hitSprites;

    //state
    int timesHit = 0;
    bool isOnlyDamage;

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
            PlayUnbreakableSound();
        }
    }

    private void PlayUnbreakableSound()
    {
        AudioClip clip = collisionSounds[Random.Range(0, collisionSounds.Length)];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1; //this is so the life is defined by the number of sprites
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
        isOnlyDamage = true;
        ShowNextHitSprite();
        PlaySFX();
        PlayVFX();
        scoreSystem.AddToScore();
    }

    private void ManageBlockDestruction()
    {
        isOnlyDamage = false;
        PlaySFX();
        PlayVFX();
        level.CountBreakedBlocks();
        scoreSystem.AddToScore();
        Destroy(gameObject);
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void PlaySFX()
    {
        AudioSource.PlayClipAtPoint(DecideSFXToPlay(), Camera.main.transform.position);
        if (vocalizedDeathSounds.Length > 0)
        {
            AudioSource.PlayClipAtPoint(vocalizedDeathSounds[Random.Range(0, vocalizedDeathSounds.Length)], Camera.main.transform.position);
        }

    }

    private AudioClip DecideSFXToPlay()
    {
        AudioClip clip;
        if (isOnlyDamage)
        {
            return clip = collisionSounds[Random.Range(0, collisionSounds.Length)];
        }
        else
        {
            return clip = destroySounds[Random.Range(0, destroySounds.Length)];
        }
    }

    private void PlayVFX()
    {
        GameObject vFX = Instantiate(ChooseVFXToPlay(), transform.position + particleOffset, transform.rotation);
        Destroy(vFX, destroyVFXTime);
    }

    private GameObject ChooseVFXToPlay()
    {
        GameObject whatVFX;
        if (isOnlyDamage)
        {
            return whatVFX = BlockDamageVFX;
        }
        else
        {
            return whatVFX = BlockDestructionVFX;
        }
    }
}
