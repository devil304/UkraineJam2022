using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    //TODO animacja
    [HideInInspector]
    public PicablePlace piclablePlace;
    public virtual void Pickup()
    {
        gameObject.SetActive(false);
        piclablePlace.resereved = false;
        //TODO pool
    }
}
