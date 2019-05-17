using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroom : MonoBehaviour
{

    public AudioClip powerUpClip;

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                //Play foley
                Debug.Log("1UP");
                AudioSource.PlayClipAtPoint(powerUpClip, Camera.main.transform.position, 1f);
                player.lives++;
                ScoreManager.instance.ChangeLives(player.lives);
                Destroy(this.gameObject);
            }
        }
    }
}
