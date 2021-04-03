using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    [SerializeField] List<Collectibles> _collectibles;
    [SerializeField] UnityEvent _onCollectionComplete;

    int _countCollected;

    void Start()
    {
        foreach (var collectible in _collectibles)
        {
            collectible.OnPickedUp += ItemPickedUp;
        }
        int countRemaining = _collectibles.Count - _countCollected;
    }

    private void ItemPickedUp()
    {
        _countCollected++;
        int countRemaining = _collectibles.Count - _countCollected;

        if (countRemaining > 0)
            return;

        _onCollectionComplete.Invoke();
    }

}
