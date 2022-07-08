using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public static GameplayManager I;

    float _time = 0;
    bool _paused;

    void Awake()
    {
        I=this;
    }

    void OnDestroy()
    {
        I=null;
    }

    // Update is called once per frame
    void Update()
    {
       if(!_paused)
        _time+=Time.deltaTime;
    }

    public void Pause(){
        _paused=true;
    }

    public void UnPause(){
        _paused=false;
    }
}
