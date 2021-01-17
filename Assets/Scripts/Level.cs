using UnityEngine;

public class Level : MonoBehaviour
{
    //state
    int breakableBlocks;

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void CountBreakedBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}
