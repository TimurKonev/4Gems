using UnityEngine;

public static class Collision2DExtension 
{
    public static PlayerMovementController HasBeenHitByPlayer(this Collision2D collision)
    {
        return collision.collider.GetComponent<PlayerMovementController>();
    }

    public static bool HasBeenHitFromBelow(this Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.5;
    }

    public static bool WasTop(this Collision2D collision)
    {
        return collision.contacts[0].normal.y < -0.5;
    }
    
    public static bool WasSide(this Collision2D collision)
    {
        return collision.contacts[0].normal.x < -0.5 ||
               collision.contacts[0].normal.x > 0.5;


    }
}