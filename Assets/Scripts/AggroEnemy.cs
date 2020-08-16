using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AggroEnemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public static bool IsPlayerDriving;
    public float speed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            var direction = (other.transform.position - transform.position).normalized;
            _rigidbody2D.MovePosition(transform.position + (Time.deltaTime * speed * direction));
        }
        else if (other.CompareTag("Car") && IsPlayerDriving)
        {
            var direction = (other.transform.position - transform.position).normalized;
            _rigidbody2D.MovePosition(transform.position - (Time.deltaTime * speed * direction));
        }
    }
}