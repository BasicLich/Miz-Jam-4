using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AggroEnemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            _rigidbody2D.MovePosition(transform.position + (Time.deltaTime * speed * direction));
        }
    }
}