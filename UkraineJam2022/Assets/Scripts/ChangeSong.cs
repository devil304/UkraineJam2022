using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSong : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip1;
    [SerializeField] private AudioClip _clip2;
    private bool isClip1Playing = true;
    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            if (isClip1Playing)
            {
                _audioSource.clip = _clip2;
                isClip1Playing = false;
            }
            else
            {
                _audioSource.clip = _clip1;
                isClip1Playing = true;
            }
            _audioSource.Play();
        }
    }
}
