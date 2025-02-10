using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip[] soundEffectClips;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitSound(){
        audioSource.pitch = Random.Range(1.3f,1.4f);
        audioSource.PlayOneShot(soundEffectClips[0]);
    }

}
