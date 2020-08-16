using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject deathAnimationPrefab;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var otherCollider = other.collider;
        var isAggroEnemy = otherCollider.name == "AggroEnemyBody";
       
        if (otherCollider.name != "Enemy" && !isAggroEnemy) return;
        
        deathAnimationPrefab.transform.position = transform.position;
        Instantiate(deathAnimationPrefab);
        transform.position = new Vector3(-9999, -9999);
        StartCoroutine(Respawn(isAggroEnemy, otherCollider.gameObject));
    }
    
    IEnumerator Respawn(bool isAggroEnemy, GameObject aggroEnemy)
    {
        yield return new WaitForSeconds(2);
        if (isAggroEnemy) aggroEnemy.GetComponent<EnemyPositionReset>().ResetEnemyPosition();
        transform.position = Vector3.zero;
    }
}
