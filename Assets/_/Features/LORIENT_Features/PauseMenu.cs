using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool _isPaused = false;

    [SerializeField] private GameObject _mainMenuUI;
    public void Resume()
    {
        _mainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void Pause()
    {
        _mainMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnMenuInput(InputAction.CallbackContext context)
    {
        if (context.performed && _isPaused)
        {
            Resume();
        }
        else if (context.performed && !_isPaused)
        {
            Pause();
        }
    }
}
