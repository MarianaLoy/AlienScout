using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip goldCoinClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(goldCoinClip, Camera.main.transform.position, 1f);
            ScoreManager.instance.ChangeScore(coinValue);
            

        }
    }
}
