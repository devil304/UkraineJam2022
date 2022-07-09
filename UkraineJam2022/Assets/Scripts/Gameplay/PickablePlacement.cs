using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickablePlacement : MonoBehaviour
{
    [SerializeField] private PicablePlace [] _picablePlace;
    [SerializeField] private GameObject _moneyPrefab;
    [SerializeField] private Pickable _goatskin;
    
    private void OnEnable()
    {
        PlaceGoatskin();
        GameplayManager.OnBadLackChange += PlaceGoatskin;
        TimeManager.OnTimeProgressMoney += PlaceMoney;
    }

    private void OnDisable()
    {
        GameplayManager.OnBadLackChange -= PlaceGoatskin;
        TimeManager.OnTimeProgressMoney -= PlaceMoney;
    }

    public void PlaceGoatskin()
    {
        var randomPoint = GetRandomPoint();
        if (randomPoint == null)
        {
            //TODO dodaæ dzia³aj¹ce  zapobieganie spawnenia na pieniadzach 
            _goatskin.transform.position = new Vector3(0,0,0);
        }
        else
        {
            randomPoint.resereved = true;
            _goatskin.transform.position = randomPoint.transform.position;
            _goatskin.piclablePlace = randomPoint;
        }
        _goatskin.gameObject.SetActive(true);
    }

    public void PlaceMoney()
    {
        var randomPoint = GetRandomPoint();
        if (!randomPoint) return;
        randomPoint.resereved = true;
        var money = Instantiate(_moneyPrefab);
        var pickable = _moneyPrefab.GetComponent<Pickable>();
        pickable.piclablePlace = randomPoint;
        money.transform.position = randomPoint.transform.position;
        money.gameObject.SetActive(true);
    }

    private PicablePlace GetRandomPoint()
    {
        var randomIndex = UnityEngine.Random.Range(0, _picablePlace.Length);
        var picablePlace = _picablePlace[randomIndex];
        if (picablePlace.resereved == true) return null;
        return picablePlace;
    } 
}
