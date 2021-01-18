using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    //config params
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] int pointsPerDeath = 10;
    [SerializeField] int percentageOfMinimumScore;
    [SerializeField] TextMeshProUGUI scoreText;

    //status
    int currentScore = 0;

    private void Awake() //singleton pattern
    {
        int gameStatusCount = FindObjectsOfType<ScoreSystem>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ShowCurrentScore();
    }


    public void AddToScore()
    {
        int randomScore = Random.Range(percentageOfMinimumScore % pointsPerBlockDestroyed, pointsPerBlockDestroyed);
        currentScore += randomScore;
        ShowCurrentScore();
    }

    private void ShowCurrentScore()
    {
        scoreText.text = currentScore.ToString();
    }

    public void EraseScore()
    {
        Destroy(gameObject);
    }

    public void LoseScore()
    {
        int randomScore = Random.Range(percentageOfMinimumScore % pointsPerDeath, pointsPerDeath);
        currentScore -= randomScore;
        ShowCurrentScore();
    }
}
