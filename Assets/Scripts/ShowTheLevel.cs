using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowTheLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] int numberToSubtract = 1;

    private void Start()
    {
        ShowCurrentLevel();
    }
    private void ShowCurrentLevel()
    {
        int currentlevel = SceneManager.GetActiveScene().buildIndex - numberToSubtract;
        levelText.text = "Level " + currentlevel.ToString();
    }
}
