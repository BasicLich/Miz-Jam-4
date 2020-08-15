using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BulletController : MonoBehaviour
{
    private const float Speed = 7;

    private const float FuseLength = 0.8f;
    private float _destructTime = 0.0f;
    
    private Rigidbody2D _rigidbody2D;

    public Vector2 direction;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _destructTime = Time.time + FuseLength;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = direction * Speed;
        
        if(_destructTime < Time.time)
            Destroy(gameObject);
    }
}
