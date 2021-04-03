using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LavaButton : MonoBehaviour
{
    [SerializeField] Sprite _pressedSprite;
    [SerializeField] UnityEvent _onPressed;

     SpriteRenderer _spriteRenderer;
     Sprite _releasedSprite;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _releasedSprite = _spriteRenderer.sprite;
        
        BecomeReleased();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovementController>();
        if (player == null)
            return;

        BecomePressed();
    }

    private void BecomePressed()
    {
        _spriteRenderer.sprite = _pressedSprite;
        _onPressed?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovementController>();
        if (player == null)
            return;

        BecomeReleased();
    }

    private void BecomeReleased()
    {
        _spriteRenderer.sprite = _releasedSprite;
    }
}
