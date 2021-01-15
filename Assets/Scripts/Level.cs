using UnityEngine;

public class Level : MonoBehaviour
{
    //state
    [SerializeField] int breakableBlocks; //serialize for debugging

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void CountBreakedBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}
