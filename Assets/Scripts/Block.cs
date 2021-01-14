using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip[] destroySound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip clip = destroySound[Random.Range(0, destroySound.Length)];

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Destroy(gameObject);
    }

}
