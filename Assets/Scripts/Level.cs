using UnityEngine;

public class Level : MonoBehaviour
{
    //config params
    [SerializeField] float timeUntillNextLevel = 1f;
    [SerializeField] float gravityAfterWinning = 1f;
    [SerializeField] AudioClip victorySound;
    [SerializeField] GameObject victoryParticle;

    //state
    int breakableBlocks;

    //cached references
    Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        FindObjectOfType<ScoreSystem>().ANewLevelHasStarted();
    }

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
        Instantiate(victoryParticle, ball.transform.position , transform.rotation);

        ball.GetComponent<Rigidbody2D>().gravityScale = gravityAfterWinning;
        FindObjectOfType<LoseCollider>().gameObject.SetActive(false);
        Invoke("LoadNextScene", timeUntillNextLevel);
    }

    private void LoadNextScene()
    {
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }
}
