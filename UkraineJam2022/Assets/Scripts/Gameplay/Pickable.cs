using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;

    //TODO animacja
    [HideInInspector]
    public PicablePlace piclablePlace;
    public virtual void Pickup()
    {
        _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
        _audioSource.Play();
        DOVirtual.DelayedCall(0.1f, () => 
        {
            gameObject.SetActive(false);
            piclablePlace.resereved = false;
        });
       
    }
}
