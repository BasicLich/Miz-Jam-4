using UnityEngine;

public class PickupController : MonoBehaviour
{
    public int itemCode;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Player") return;
        Destroy(gameObject);
        other.GetComponent<Shooting>().gunCode = itemCode;
    }
}
