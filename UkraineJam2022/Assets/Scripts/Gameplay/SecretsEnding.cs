using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretsEnding : MonoBehaviour
{
    public static SecretsEnding I;
    public bool SecretsEndingEnable = false;
    public bool SecretsEndingGoatskinProgress = false;
    public bool SecretEnding = false;

    [SerializeField] private EndPanel _endPanel;

    public void Awake()
    {
        I = this;
    }

    internal void HappyEnd()
    {
        SecretEnding = true;
        _endPanel.ShowEndPanel();
    }
}
