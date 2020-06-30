using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundsound : MonoBehaviour
{   

    public AudioClip backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
