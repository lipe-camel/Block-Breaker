using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    //config params
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] int pointsPerDeath = 10;
    [SerializeField][Range(0,1)] float percentageOfMinimumScore;
    [SerializeField] int maxTotalPoints = 999999999;
    [SerializeField] TextMeshProUGUI scoreText;

    //status
    int currentScore = 0;

    private void Awake() //singleton pattern
    {
        int gameStatusCount = FindObjectsOfType<ScoreSystem>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            EraseScore();
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
        int randomScore = Random.Range(Mathf.RoundToInt(percentageOfMinimumScore * pointsPerBlockDestroyed), pointsPerBlockDestroyed);
        currentScore += randomScore;
        ShowCurrentScore();
    }
    public void LoseScore()
    {
        int randomScore = Random.Range(Mathf.RoundToInt(percentageOfMinimumScore * pointsPerDeath), pointsPerDeath);
        currentScore -= randomScore;
        ShowCurrentScore();
    }

    private void ShowCurrentScore()
    {
        if (currentScore <= 0)
        {
            currentScore = 0;
        }
        else if (currentScore >= maxTotalPoints)
        {
            currentScore = maxTotalPoints;
        }
        scoreText.text = currentScore.ToString();
    }

    public void EraseScore()
    {
        Destroy(gameObject);
    }
}
