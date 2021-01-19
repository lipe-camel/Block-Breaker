using UnityEngine;

public class Debugger : MonoBehaviour
{
    //cached component references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void Update()
    {
        if (Debug.isDebugBuild)
        {
            ManageDebugInputs();
        }
    }

    private void ManageDebugInputs()
    {
        TraverseLevels();
        ToggleLoseColider();
        ToggleAutoplay();
        ResetBall();
    }

    private void TraverseLevels()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            sceneLoader.LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            sceneLoader.LoadPreviousScene();
        }
    }

    private void ToggleLoseColider()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FindObjectOfType<LoseCollider>().ToggleIsTrigger();
        }
    }

    private void ToggleAutoplay()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            FindObjectOfType<Paddle>().ToggleAutoplay();
        }
    }

    private void ResetBall()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<Ball>().ManageDeath();
        }
    }
}
