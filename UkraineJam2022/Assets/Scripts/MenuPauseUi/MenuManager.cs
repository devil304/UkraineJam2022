using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private AudioSource _audioSource;
    Tween _video;

    public void StartGame()
    {
        _audioSource.Stop();
        _videoPlayer.gameObject.SetActive(true);
        _video = DOVirtual.DelayedCall((float)_videoPlayer.length,() => SceneManager.LoadScene(1) );
    }

    void Update()
    {
        if((Keyboard.current.spaceKey.isPressed || Gamepad.current.startButton.isPressed || Gamepad.current.selectButton.isPressed) && _video.active){
            _videoPlayer.Pause();
            _video.Kill();
            SceneManager.LoadScene(1);
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }

}
