using UnityEngine;

public class Debugger : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.L))
        {
            sceneLoader.LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            sceneLoader.LoadPreviousScene();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            loseCollider.ToggleLosing();
        }
    }



}
