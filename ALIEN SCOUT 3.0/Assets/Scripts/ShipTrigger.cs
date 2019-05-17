using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTrigger : MonoBehaviour
{
    public AudioClip shipClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(shipClip, Camera.main.transform.position, 1f);
        }
    }
}
