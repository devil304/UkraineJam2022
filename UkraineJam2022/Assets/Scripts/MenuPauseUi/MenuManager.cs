using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private AudioSource _audioSource;

    public void StartGame()
    {
        _audioSource.Stop();
        _videoPlayer.gameObject.SetActive(true);
        DOVirtual.DelayedCall((float)_videoPlayer.length,() => SceneManager.LoadScene(1) );
    }

    public void EndGame()
    {
        Application.Quit();
    }

}
