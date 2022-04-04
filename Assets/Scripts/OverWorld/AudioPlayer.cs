using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public AudioClip clip;
    public float volume = .5f;
    public void Play()
    {
        AudioManager.Instance.PlaySound(clip, volume);
    }
}
