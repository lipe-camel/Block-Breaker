using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] AudioClip buttonPressSound;
    public void PlayButtonSound()
    {
        AudioSource.PlayClipAtPoint(buttonPressSound, Camera.main.transform.position);
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void EraseScore()
    {
        FindObjectOfType<ScoreSystem>().EraseScore();
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("End Screen");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
