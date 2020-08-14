using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Enemy")
        {
            StartCoroutine(Respawn());
        }
    }
    
    IEnumerator Respawn()
    {
        transform.position = new Vector3(999, 999);
        yield return new WaitForSeconds(3);
        transform.position = Vector3.zero;
    }
}
