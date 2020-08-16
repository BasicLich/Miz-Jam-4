using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CarDrivingController : MonoBehaviour
{
    public bool IsTank;
    public bool IsPlayerDriving;
    
    [SerializeField] private Sprite up;
    [SerializeField] private Sprite down;
    [SerializeField] private Sprite left;
    [SerializeField] private Sprite right;
    [SerializeField] private float speed;
    [SerializeField] private GameObject _explosionPrefab;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    
    private GameObject _player;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name != "Player") return;
        if (Input.GetKey(KeyCode.Space))
        {
            IsPlayerDriving = true;
            AggroEnemy.IsPlayerDriving = IsPlayerDriving;
            _player = other.gameObject;
            _player.GetComponent<PlayerInputController>().transform.position = new Vector3(-9999, -9999);
            StartCoroutine(LeaveCar());
        }
    }

    private void Update()
    {
        if (!IsPlayerDriving) return;

        var xAcceleration = Input.GetAxis("Horizontal");
        var yAcceleration = Input.GetAxis("Vertical");
        
        if (Input.GetKey(KeyCode.W))
        {
            _spriteRenderer.sprite = up;
            _rigidbody2D.velocity = speed * yAcceleration * Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _spriteRenderer.sprite = down;
            _rigidbody2D.velocity = speed * -yAcceleration * Vector2.down;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.sprite = right;
            _rigidbody2D.velocity = speed * xAcceleration * Vector2.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.sprite = left;
            _rigidbody2D.velocity = speed * -xAcceleration * Vector2.left;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
    
    IEnumerator LeaveCar()
    {
        float autoDestroyTime;
        autoDestroyTime = IsTank ? 2f : 5f; 
        
        yield return new WaitForSeconds(autoDestroyTime);
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1f);
        IsPlayerDriving = false;
        AggroEnemy.IsPlayerDriving = IsPlayerDriving;
        _player.transform.position = transform.position;
        StartCoroutine(AutoBreakCar());
    }

    IEnumerator AutoBreakCar()
    {
        yield return new WaitForSeconds(1f);
        _explosionPrefab.transform.position = transform.position;
        Instantiate(_explosionPrefab);
        Destroy(gameObject);
    }
}
