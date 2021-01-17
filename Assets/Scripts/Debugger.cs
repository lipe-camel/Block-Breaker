using UnityEngine;

public class Debugger : MonoBehaviour
{
    //state
    bool isAutoplayActive = false;

    //cached component references
    SceneLoader sceneLoader;
    LoseCollider loseCollider;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        loseCollider = FindObjectOfType<LoseCollider>();
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
            loseCollider.ToggleLosing();
        }
    }

    public void ToggleAutoplay()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isAutoplayActive = !isAutoplayActive;
        }
    }

    public bool IsAutoplayActive()
    {
        return isAutoplayActive;
    }
}
