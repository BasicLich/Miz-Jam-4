using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float _nextAllowedShootTime = 0.0f;
    private Vector3 shootPosition;

    public int gunCode = 1;
    
    private float pistolCooldownTime = 0.4f;
    private float machineCooldownTime = 0.1f;
    private float shotgunCooldownTime = 0.7f;

    private Component _tankScript;
    private bool _isTank;
    private Rigidbody2D _rigidBody2D;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        _isTank = gameObject.name == "Tank";
        if (_isTank)
        {
            _tankScript = gameObject.GetComponent<CarDrivingController>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        if (transform.position.x < -8000f)
            return;
        
        if(_nextAllowedShootTime == 0.0f || _nextAllowedShootTime < Time.time)
        {
            shootPosition = transform.position + Vector3.up / 10;

            if (_isTank)
            {
                if (((CarDrivingController) _tankScript).IsPlayerDriving)
                {
                    if (_rigidBody2D.velocity == Vector2.zero) return;
                    ShootMachinegun(_rigidBody2D.velocity);
                }
            } 
            else if (Input.GetKey(KeyCode.L))
            {
                switch (gunCode)
                {
                    case 1:
                        ShootPistol(Vector2.right);
                        break;
                    case 2:
                        ShootShotgun(Vector2.right);
                        break;
                    case 3:
                        ShootMachinegun(Vector2.right);
                        break;
                }
            } 
            else if (Input.GetKey(KeyCode.J))
            {
                switch (gunCode)
                {
                    case 1:
                        ShootPistol(Vector2.left);
                        break;
                    case 2:
                        ShootShotgun(Vector2.left);
                        break;
                    case 3:
                        ShootMachinegun(Vector2.left);
                        break;
                }
            }
            else if (Input.GetKey(KeyCode.I))
            {
                switch (gunCode)
                {
                    case 1:
                        ShootPistol(Vector2.up);
                        break;
                    case 2:
                        ShootShotgun(Vector2.up);
                        break;
                    case 3:
                        ShootMachinegun(Vector2.up);
                        break;
                }
            }
            else if (Input.GetKey(KeyCode.K))
            {
                switch (gunCode)
                {
                    case 1:
                        ShootPistol(Vector2.down);
                        break;
                    case 2:
                        ShootShotgun(Vector2.down);
                        break;
                    case 3:
                        ShootMachinegun(Vector2.down);
                        break;
                }
            }
        }
    }

    private void ShootPistol(Vector2 direction)
    {
        bulletPrefab.transform.position = shootPosition;
        var bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<BulletController>().direction = direction;
        _nextAllowedShootTime = Time.time + pistolCooldownTime;
        
        _audioSource.Play();
    }
    
    private void ShootShotgun(Vector2 direction)
    {
        bulletPrefab.transform.position = shootPosition;
        var bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<BulletController>().direction = direction;
        
        bulletPrefab.transform.position = shootPosition + new Vector3(0.1f, 0.1f);
        bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<BulletController>().direction = direction;
        
        bulletPrefab.transform.position = shootPosition + new Vector3(-0.1f, -0.1f);
        bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<BulletController>().direction = direction;
        
        _nextAllowedShootTime = Time.time + shotgunCooldownTime;
        
        _audioSource.Play();
    }
    
    private void ShootMachinegun(Vector2 direction)
    {
        bulletPrefab.transform.position = shootPosition;
        var bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<BulletController>().direction = direction;
        _nextAllowedShootTime = Time.time + machineCooldownTime;
        
        _audioSource.Play();
    }
}
