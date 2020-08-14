using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerInputController : MonoBehaviour
{
    private const float Speed = 2;
    
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var xAcceleration = Input.GetAxis("Horizontal");
        var yAcceleration = Input.GetAxis("Vertical");

        if (yAcceleration > 0)
        {
            _rigidbody2D.velocity = Speed * yAcceleration * Vector2.up;
        }
        else if (yAcceleration < 0)
        {
            _rigidbody2D.velocity = Speed * -yAcceleration * Vector2.down;
        }
        else if (xAcceleration > 0)
        {
            _rigidbody2D.velocity = Speed * -xAcceleration * Vector2.left;
        }
        else if (xAcceleration < 0)
        {
            _rigidbody2D.velocity = Speed * xAcceleration * Vector2.right;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
