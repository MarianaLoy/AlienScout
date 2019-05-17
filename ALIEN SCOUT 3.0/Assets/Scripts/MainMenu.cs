using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public AudioClip clickClip;

    public void PlayGame()
    {
        AudioSource.PlayClipAtPoint(clickClip, Camera.main.transform.position, 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        AudioSource.PlayClipAtPoint(clickClip, Camera.main.transform.position, 1f);
        Debug.Log("Quit");
        Application.Quit();
    }
}
