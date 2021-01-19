using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1f;
    [SerializeField] AudioClip buttonPressSound;
    public void PlayButtonSound()
    {
        AudioSource.PlayClipAtPoint(buttonPressSound, Camera.main.transform.position);
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPreviousScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadCredits()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadStartScene()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadEndScene()
    {
        StartCoroutine(LoadLevel(SceneManager.sceneCountInBuildSettings - 1));
    }

    public void EraseScore()
    {
        FindObjectOfType<ScoreSystem>().EraseScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
