using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    Animator animator;
    IMove mover;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<IMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float speed = mover.Speed;
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (speed != 0)
            spriteRenderer.flipX = speed > 0;
    }
}
