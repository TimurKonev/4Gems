using UnityEngine;

[RequireComponent(typeof(CharacterGrounded))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float jumpForce = 300;
    [SerializeField] float wallJumpForce = 300;
    [SerializeField] float bounceForce = 100;

    int jumpsRemaining = 1;
    bool jumpRequest;
    public static Vector3 movement;

    new Rigidbody2D rigidbody2D;

    CharacterGrounded characterGrounding;        
    public float Speed { get; private set; }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounded>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump") && (characterGrounding.IsGrounded || jumpsRemaining > 0))
        {
            jumpRequest = true;
            jumpsRemaining--;
        }

        if (characterGrounding.IsGrounded)
            jumpsRemaining = 1;
    }

    void FixedUpdate()
    {
        if(jumpRequest)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
            jumpRequest = false;

            if (characterGrounding.GroundedDirection != Vector2.down)
            {
                rigidbody2D.AddForce(characterGrounding.GroundedDirection * -1f * wallJumpForce);
            }
        }
        float horizontal = Input.GetAxis("Horizontal");
        Speed = horizontal;


        movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    internal void Bounce()
    {
        rigidbody2D.AddForce(Vector2.up * bounceForce);

    }
}
