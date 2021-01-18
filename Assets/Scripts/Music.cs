using UnityEngine;

public class Music : MonoBehaviour
{
    private void Awake() //singleton pattern
    {
        int gameStatusCount = FindObjectsOfType<Music>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
