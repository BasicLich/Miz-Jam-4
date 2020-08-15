using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float _nextAllowedShootTime = 0.0f;
    private Vector3 shootPosition;

    public int gunCode = 1;
    
    private float pistolCooldownTime = 0.4f;
    private float machineCooldownTime = 0.1f;
    private float shotgunCooldownTime = 0.7f;
    
    private void Update()
    {
        if(_nextAllowedShootTime == 0.0f || _nextAllowedShootTime < Time.time)
        {

            shootPosition = transform.position + Vector3.up / 10;
            if (Input.GetKey(KeyCode.L))
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
    }
    
    private void ShootMachinegun(Vector2 direction)
    {
        bulletPrefab.transform.position = shootPosition;
        var bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<BulletController>().direction = direction;
        _nextAllowedShootTime = Time.time + machineCooldownTime;
    }
}
