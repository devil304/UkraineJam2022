using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPicable : Pickable
{
    public override void Pickup()
    {
        gameObject.SetActive(false);
        piclablePlace.resereved = false;
        base.Pickup();
        MoneyPool.I.Return(transform);
    }
}
