using UnityEngine;
using TMPro;

public class Statistics : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI maxcombo;
    [SerializeField] TextMeshProUGUI deathCount;

    ScoreSystem scoreSystem;
    void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();

        score.text = scoreSystem.CurrentScore().ToString();
        maxcombo.text = scoreSystem.MaxComboNumber().ToString();
        deathCount.text = scoreSystem.DeathCount().ToString();
        scoreSystem.EraseScore();
    }
}
