using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    private AudioSource lavaSound;
    public AudioClip glupclip;

    public void Start()
    {
        lavaSound = GetComponent<AudioSource>();
    }

    public void Update()
    {
        lavaSound.Play();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(glupclip, Camera.main.transform.position, 1f);
            SceneManager.LoadScene(2);
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            AudioSource.PlayClipAtPoint(glupclip, Camera.main.transform.position, 1f);
            Destroy(other.gameObject);
        }
    }
}
