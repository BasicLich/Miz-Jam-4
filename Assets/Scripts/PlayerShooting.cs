using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float _nextAllowedShootTime = 0.0f;
    private float cooldownTime = 0.5f;
    
    private void Update()
    {
        if(_nextAllowedShootTime == 0.0f || _nextAllowedShootTime < Time.time)
        {

            if (Input.GetKey(KeyCode.L))
            {
                bulletPrefab.transform.position = transform.position;
                var bullet = Instantiate(bulletPrefab);
                bullet.GetComponent<BulletController>().direction = Vector2.right;
                _nextAllowedShootTime = Time.time + cooldownTime;
            } 
            else if (Input.GetKey(KeyCode.J))
            {
                bulletPrefab.transform.position = transform.position;
                var bullet = Instantiate(bulletPrefab);
                bullet.GetComponent<BulletController>().direction = Vector2.left;
                _nextAllowedShootTime = Time.time + cooldownTime;
            }
            else if (Input.GetKey(KeyCode.I))
            {
                bulletPrefab.transform.position = transform.position;
                var bullet = Instantiate(bulletPrefab);
                bullet.GetComponent<BulletController>().direction = Vector2.up;
                _nextAllowedShootTime = Time.time + cooldownTime;
            }
            else if (Input.GetKey(KeyCode.K))
            {
                bulletPrefab.transform.position = transform.position;
                var bullet = Instantiate(bulletPrefab);
                bullet.GetComponent<BulletController>().direction = Vector2.down;
                _nextAllowedShootTime = Time.time + cooldownTime;
            }
        }
    }
}
