using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPicable : Pickable
{
    public override void Pickup()
    {
        base.Pickup();
        gameObject.SetActive(false);
        piclablePlace.resereved = false;
        MoneyPool.I.Return(transform);
    }
}
