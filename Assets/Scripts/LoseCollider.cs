using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    //cached component references
    Collider2D thisCollider2D;
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        thisCollider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneLoader.RestartScene();
    }

    public void ToggleIsTrigger() //this is used fo debugging
    {
        thisCollider2D.isTrigger = !thisCollider2D.isTrigger;
    }
}
