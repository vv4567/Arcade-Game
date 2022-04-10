using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelay : MonoBehaviour 

    
{
    AudioSource myAudio;
    public float delay; 
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        Invoke("playAudio", delay);
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
