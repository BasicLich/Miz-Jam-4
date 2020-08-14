using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerInputController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody2D.velocity = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody2D.velocity = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.velocity = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.velocity = Vector2.right;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
