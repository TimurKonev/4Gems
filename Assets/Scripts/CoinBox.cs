using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour, ITakeShellHits
{
    [SerializeField] SpriteRenderer enabledSprite;
    [SerializeField] SpriteRenderer disabledSprite;
    [SerializeField] int totalCoins = 1;
    
    Animator animator;
    int remainingCoins;
    void Awake()
    {
        animator = GetComponent<Animator>();
        remainingCoins = totalCoins;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (remainingCoins > 0 && HasBeenHitByPlayer(collision) != null && HasBeenHitFromBelow(collision))
        {
            TakeCoin();
        }
    }

    private void TakeCoin()
    {
        animator.SetTrigger("FlipCoin");
        GameManager.Instance.AddCoin();
        remainingCoins--;


        if (remainingCoins <= 0)
        {
            enabledSprite.enabled = false;
            disabledSprite.enabled = true;
        }
    }

    static PlayerMovementController HasBeenHitByPlayer(Collision2D collision)
    {
        return collision.collider.GetComponent<PlayerMovementController>();
    }

    static bool HasBeenHitFromBelow(Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.5;
    }

    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        if(remainingCoins > 0)
           TakeCoin();

    }
}
