using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public GameObject thePlayer;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") && player.isJumping)
        {
            player.isJumping = false;
        }

        if (other.gameObject.CompareTag("Platform") && player.isJumping)
        {
            player.isJumping = false;
            thePlayer.transform.parent = other.gameObject.transform;
        }


    }
   

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            thePlayer.transform.parent = null;
        }

    }
}
