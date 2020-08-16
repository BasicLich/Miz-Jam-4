using UnityEngine;

public class EnemyPositionReset : MonoBehaviour
{
    public GameObject enemyObject;
    
    private Vector3 _originalPosition;
    
    private void Start()
    {
        _originalPosition = enemyObject.transform.position;
    }

    public void ResetEnemyPosition()
    {
        enemyObject.transform.position = _originalPosition;
    }
}
