using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    int currentSceneIndex;


    private void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (Debug.isDebugBuild)
        {
            ManageDebugInputs();
        }
    }

    private void ManageDebugInputs()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadPreviousScene();
        }

    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void LoadPreviousScene()
    {
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
