using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [FormerlySerializedAs("Speed")] [SerializeField] private float speed;
    
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.down;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyUpperCollider"))
        {
            _rigidbody2D.velocity = speed * Vector2.down;
        }
        else if (other.CompareTag("EnemyDownCollider"))
        {
            _rigidbody2D.velocity = speed * Vector2.up;
        }
    }
}