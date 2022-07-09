using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goatskin : Pickable
{
    private void OnEnable()
    {
        GameplayManager.OnBadLackChange += SetRandomPostion;
    }

    private void OnDisable()
    {
        GameplayManager.OnBadLackChange -= SetRandomPostion;
    }
}
