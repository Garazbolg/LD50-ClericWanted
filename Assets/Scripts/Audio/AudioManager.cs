using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource asource;

    private void Awake()
    {
        Instance = this;
        asource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float volume = .5f)
    {
        if(clip && volume >0)
            asource.PlayOneShot(clip, volume);
    }
}
