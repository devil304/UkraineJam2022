using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPool : MonoBehaviour
{
    public static MoneyPool I;

    [SerializeField] private List<Transform> _pool = new List<Transform>();
    [SerializeField] private GameObject _moneyPrefab;

    private void Awake()
    {
        I = this;

        foreach (var child in transform)
        {
            var childTransform = (Transform)child;
            _pool.Add(childTransform);
            childTransform.gameObject.SetActive(false);
        }
    }

    public Transform Get()
    {
        if (_pool.Count <= 0)
        {
            var inst = Instantiate(_moneyPrefab);
            return inst.transform;
        }
        var transform = _pool[0];
        _pool.RemoveAt(0);
        return transform;
    }

    public void Return(Transform money)
    {
        gameObject.SetActive(false);
        _pool.Add(money);
    }
}
