using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    Collider2D thisCollider2D;

    private void Start()
    {
        thisCollider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Debug.isDebugBuild)
        {
            ManageDebugKeys();
        }
    }

    private void ManageDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            thisCollider2D.isTrigger = !thisCollider2D.isTrigger;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Lose Screen");
    }


}
