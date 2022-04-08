using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelay : MonoBehaviour 

    
{
    AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        Invoke("playAudio", 2.0f);
    }
    void playAudio()
    {
       myAudio.Play();
    }    
    // Update is called once per frame
    void Update()
    {
        
    }
}
