using UnityEngine.SceneManagement;

public static class NavigationManager
{
    public static void NavigateTo(string destination)
    {
        SceneManager.LoadScene(destination);
    }
}