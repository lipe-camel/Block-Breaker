using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //config params
    [SerializeField][Range(0f,10f)] float gameSpeed = 1f;
    [Header("Score")]
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;

    //status
    int currentScore = 0;

    private void Awake() //singleton pattern
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
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
        currentScore += pointsPerBlockDestroyed; //it's "currentScore = currentScore + pointsPerBlockDestroyed;" refactored
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

    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
