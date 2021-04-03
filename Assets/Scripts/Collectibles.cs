using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectibles : MonoBehaviour
{
    [SerializeField] public UnityEvent _onGemCollected;

    public event Action OnPickedUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovementController>();
        if (player == null)
            return;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        OnPickedUp?.Invoke();
        _onGemCollected?.Invoke();
    }
}
