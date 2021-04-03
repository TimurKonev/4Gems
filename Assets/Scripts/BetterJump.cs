using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;

    Rigidbody2D rigidBody;

     void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if(rigidBody.velocity.y < 0)
        {
            rigidBody.gravityScale = fallMultiplier;
        }
        else if(rigidBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidBody.gravityScale = lowJumpMultiplier; 
        }
        else
        {
            rigidBody.gravityScale = 1f;
        }
    }
}
