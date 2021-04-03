using System;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject spawnOnStompedPrefab;

    new Collider2D collider;
    new Rigidbody2D rigidbody2D;
    Vector2 direction = Vector2.left;
    SpriteRenderer sprite;

   
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + direction * speed * Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        if (ReachedEdge() || ReachedWall())
            SwitchedDirections();
    }

    

    private bool ReachedEdge()
    {
        float x = GetForwardX();

        float y = collider.bounds.min.y;

        Vector2 origin = new Vector2(x, y);
        Debug.DrawRay(origin, Vector2.down * 0.1f);

        var hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);

        if (hit.collider == null)
            return true;

        return false;
    }

    private bool ReachedWall()
    {
        float x = GetForwardX();

        float y = transform.position.y;

        Vector2 origin = new Vector2(x, y);
        Debug.DrawRay(origin, direction * 0.1f);

        var hit = Physics2D.Raycast(origin, direction, 0.1f);

        if (hit.collider == null 
            || hit.collider.isTrigger 
            || hit.collider.GetComponent<PlayerMovementController>() != null)
            return false;
        else
            return true;
    }

    private float GetForwardX()
    {
        return direction.x == -1 ?
                    collider.bounds.min.x - 0.1f :
                    collider.bounds.max.x + 0.1f;
    }

    

    private void SwitchedDirections()
    {
        direction *= -1;
        sprite.flipX = !sprite.flipX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.HasBeenHitByPlayer())
        {
            if (collision.WasTop())
                HandleWalkerStomped(collision.collider.GetComponent<PlayerMovementController>());
            else
                GameManager.Instance.KillPlayer();
        }
    }

    private void HandleWalkerStomped(PlayerMovementController playerMovementController)
    {
        if(spawnOnStompedPrefab != null)
        {
            Instantiate(spawnOnStompedPrefab, transform.position, transform.rotation);
        }

        playerMovementController.Bounce();

        Destroy(gameObject);

    }

}
