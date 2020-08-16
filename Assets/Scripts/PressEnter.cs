using UnityEngine;

public class PressEnter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
            NavigationManager.NavigateTo("Tutorial");    
    }
}
