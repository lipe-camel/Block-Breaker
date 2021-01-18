using UnityEngine;

public class Level : MonoBehaviour
{
    //state
    int breakableBlocks;
    [SerializeField] float timeUntillNextLevel = 1f;
    [SerializeField] AudioClip victorySound;

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void CountBreakedBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            WonTheLevel();
        }
    }

    private void WonTheLevel()
    {
        AudioSource.PlayClipAtPoint(victorySound, Camera.main.transform.position);
        FindObjectOfType<Ball>().GetComponent<Rigidbody2D>().gravityScale = 1;
        FindObjectOfType<LoseCollider>().gameObject.SetActive(false);
        Invoke("LoadNextScene", timeUntillNextLevel);
    }

    private void LoadNextScene()
    {
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }
}
