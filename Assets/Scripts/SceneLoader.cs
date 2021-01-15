using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //state
    int currentSceneIndex;

    

    private void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().EraseScore();
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
