using UnityEngine;

public class ShootReceiver : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject; 
    private int _enemyHealth = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Bullet(Clone)") return;
        Destroy(other.gameObject);
        _enemyHealth -= 30;
        if (_enemyHealth <= 0)
        {
            Destroy(_gameObject);
        }
    }
}
