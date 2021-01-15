using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config params
    [SerializeField][Range(0f,10f)] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;


    //status
    int currentScore = 0;

    private void Start()
    {
        ShowCurrentScore();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed; //it's "currentScore = currentScore + pointsPerBlockDestroyed;" refactored
        ShowCurrentScore();
    }

    private void ShowCurrentScore()
    {
        scoreText.text = currentScore.ToString();
    }
}
