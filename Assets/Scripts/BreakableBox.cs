using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour, ITakeShellHits
{
    new ParticleSystem particleSystem;
    new Collider2D collider;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        Destroy(gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.HasBeenHitByPlayer() != null 
            && collision.HasBeenHitFromBelow())
        {
            TakeHit();
        }
    }

    void TakeHit()
    {
        collider.enabled = false;
        spriteRenderer.enabled = false;
        particleSystem.Play();
        audioSource.Play();
        
    }
}
