using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicIntro : MonoBehaviour
{

    private AudioSource musicIntro;
    // Start is called before the first frame update
    void Start()
    {
        musicIntro = GetComponent<AudioSource>();
        musicIntro.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
