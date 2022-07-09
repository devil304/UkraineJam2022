using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideExitButton : MonoBehaviour
{
#if UNITY_WEBGL
    private void Awake()
    {
        gameObject.SetActive(false);
    }
#endif
}
