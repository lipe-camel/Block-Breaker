using UnityEngine;

public class Block : MonoBehaviour
{

    //config params
    [SerializeField] AudioClip[] destroySounds;

    //cached component references
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();              //this is needed so it can be linked to other game object (this is what I need to implement in other game projects)

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
        Destroy(gameObject);
    }
}
