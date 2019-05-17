using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public AudioClip clickClip;

    public void RestartGame()
    {
        AudioSource.PlayClipAtPoint(clickClip, Camera.main.transform.position, 1f);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        AudioSource.PlayClipAtPoint(clickClip, Camera.main.transform.position, 1f);
        Debug.Log("Quit");
        Application.Quit();
    }
}
