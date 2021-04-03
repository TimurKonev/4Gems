using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] UnityEvent onRight;
    [SerializeField] UnityEvent onLeft;
    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;



    SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovementController>();
        if (player == null)
            return;

        bool wasOnRight = collision.transform.position.x > transform.position.x;
        bool walkingRight = PlayerMovementController.movement.x > 0;
        bool walkingLeft = PlayerMovementController.movement.x < 0;

        if (wasOnRight && walkingRight)
        {
            spriteRenderer.sprite = rightSprite;
            onRight.Invoke();
        }
        else if(!wasOnRight && walkingLeft)
        {
            spriteRenderer.sprite = leftSprite;
            onLeft.Invoke();
        }

    }
}
