using System.Collections;
using UnityEngine;

public class NavigationTrigger : MonoBehaviour
{
    public string nextSceneName;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" || other.CompareTag("Car"))
        {
            NavigationManager.NavigateTo(nextSceneName);
        }
    }
}
