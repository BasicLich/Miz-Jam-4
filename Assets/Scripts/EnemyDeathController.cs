using UnityEngine;

public class EnemyDeathController : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject deathAnimationPrefab;
    [SerializeField] private GameObject hitMarkerPrefab;
    [SerializeField] private AudioSource _audioSource;
    
    private int _enemyHealth = 100;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bullet(Clone)")
        {
            _audioSource.Play();
            Destroy(other.gameObject);
            _enemyHealth -= 30;
            
            if (_enemyHealth <= 0)
            {
                DestroyEnemy();
            }
            else
            {
                hitMarkerPrefab.transform.position = transform.position;
                Instantiate(hitMarkerPrefab);
            }
        }

        if (other.CompareTag("Car"))
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        deathAnimationPrefab.transform.position = transform.position;
        Instantiate(deathAnimationPrefab);
        Destroy(_gameObject);
    }
}
