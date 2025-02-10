using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] songs;
    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
       PlayMenuTheme();
       
    }
    void PlayMenuTheme(){
        audioSource.clip = songs[0];
        audioSource.Play();
    }

    public void PlayFightTheme(){
        audioSource.clip = songs[1];
        audioSource.PlayDelayed(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
