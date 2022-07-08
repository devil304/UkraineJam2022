using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicOptions : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public void SetSFXVolume(float sfxVolume)
    {
        audioMixer.SetFloat("SFXVolume", sfxVolume);
    }

    public void SetMusicVolume(float music)
    {
        audioMixer.SetFloat("MusicVolume", music);
    }
}
