using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
