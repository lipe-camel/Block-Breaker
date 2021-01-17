using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] float gameSpeed = 1f;

    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
