using System.Collections;
using UnityEngine;

public class AutoDestroyExplosion : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
