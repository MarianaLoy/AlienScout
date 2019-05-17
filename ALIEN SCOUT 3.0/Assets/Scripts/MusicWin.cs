using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicWin : MonoBehaviour
{
    private AudioSource musicWin;
    // Start is called before the first frame update
    void Start()
    {
        musicWin = GetComponent<AudioSource>();
        musicWin.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
