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
    [SerializeField] TextMeshProUGUI comboText;

    //status
    int currentScore = 0;
    int maxCombo;


    //cached references
    Ball ball;

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
        ball = FindObjectOfType<Ball>();

        ShowCurrentScore();
    }

    private void Update()
    {
        ShowCurrentCombo();
    }

    public void AddToScore()
    {
        int randomScore = Random.Range(Mathf.RoundToInt(percentageOfMinimumScore * pointsPerBlockDestroyed), pointsPerBlockDestroyed+1);
        int scoreComboed = randomScore * ball.ComboNumber();
        //Debug.Log(scoreComboed);
        currentScore += scoreComboed;
        ShowCurrentScore();
        Debug.Log(MaxComboNumber());
    }
    public void LoseScore()
    {
        int randomScore = Random.Range(Mathf.RoundToInt(percentageOfMinimumScore * pointsPerDeath), pointsPerDeath+1);
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

    private void ShowCurrentCombo()
    {
        comboText.text = "Combo x" + ball.ComboNumber();
    }

    public int MaxComboNumber()
    {
        if (maxCombo < ball.ComboNumber())
        {
            maxCombo = ball.ComboNumber();
        }
        return maxCombo;
    }

    public void EraseScore()
    {
        Destroy(gameObject);
    }

    public void SearchNewBall()
    {
        ball = FindObjectOfType<Ball>();
    }
}
