using UnityEngine;

public class Level : MonoBehaviour
{
    //state
    [SerializeField] int breakableBlocks; //serialize for debugging

    //cached component references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void Update()
    {
        if(breakableBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void CountBreakedBlocks()
    {
        breakableBlocks--;
    }
}
