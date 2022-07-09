using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonOnEnable : MonoBehaviour
{

    Selectable _mySel;

    void Awake()
    {
        _mySel = GetComponent<Button>();
    }
    
    void OnEnable()
    {
        _mySel.Select();
    }
}
