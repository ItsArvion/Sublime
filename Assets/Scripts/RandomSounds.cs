using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioSource _AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        AudioClip clip = clips[UnityEngine.Random.Range(0, clips.Length)];

        _AudioSource.PlayOneShot(clip);
    }
}
