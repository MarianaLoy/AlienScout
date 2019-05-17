using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutCoin : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip nutCoinClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(nutCoinClip, Camera.main.transform.position, 1f);
            ScoreManager.instance.ChangeNutCoinsScore(coinValue);

        }
    }
}
