using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadLuckSwitchUI : MonoBehaviour
{
    private void OnEnable()
    {
        DOVirtual.DelayedCall(1, () => gameObject.SetActive(false));
    }
}
