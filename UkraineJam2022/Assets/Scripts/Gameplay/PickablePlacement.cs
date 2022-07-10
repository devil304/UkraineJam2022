using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickablePlacement : MonoBehaviour
{
    [SerializeField] private PicablePlace[] _picablePlaceMoney;
    [SerializeField] private PicablePlace[] _picablePlaceGoatskin;
    [SerializeField] private PicablePlace[] _picablePlaceGoat;
    [SerializeField] private Pickable _goatskin;
    [SerializeField] private Pickable _goast;

    private void OnEnable()
    {
        PlaceGoatskin();
        GameplayManager.OnBadLackChange += PlaceGoatskin;
        TimeManager.OnTimeProgressMoney += PlaceMoney;
        TimeManager.OnGoastProgress += PlaceGoast;
    }

    private void PlaceGoast()
    {
        if (_goast.isActiveAndEnabled) return;
        var randomIndex = UnityEngine.Random.Range(0, _picablePlaceGoat.Length);
        var randomPoint = _picablePlaceGoat[randomIndex];
        randomPoint.resereved = true;
        _goast.transform.position = randomPoint.transform.position;
        _goast.piclablePlace = randomPoint;
        _goast.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        GameplayManager.OnBadLackChange -= PlaceGoatskin;
        TimeManager.OnTimeProgressMoney -= PlaceMoney;
        TimeManager.OnGoastProgress -= PlaceGoast;
    }

    public void PlaceGoatskin()
    {
        var randomIndex = UnityEngine.Random.Range(0, _picablePlaceGoatskin.Length);
        var randomPoint = _picablePlaceGoatskin[randomIndex];

        randomPoint.resereved = true;
        _goatskin.transform.position = randomPoint.transform.position;

        _goatskin.piclablePlace = randomPoint;
        _goatskin.gameObject.SetActive(true);
    }

    public void PlaceMoney()
    {
        var randomIndex = UnityEngine.Random.Range(0, _picablePlaceMoney.Length);
        var picablePlace = _picablePlaceMoney[randomIndex];
        if (picablePlace.resereved == true) return;
        picablePlace.resereved = true;
        var money = MoneyPool.I.Get();
        var pickable = money.GetComponent<Pickable>();
        pickable.piclablePlace = picablePlace;
        money.position = picablePlace.transform.position;
        money.gameObject.SetActive(true);
    }
}
