using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool _isPaused = false;

    public static bool _isGameMenuActive = false;

    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _endGameMenuUI;

    public void Resume()
    {
        if (_isGameMenuActive) return;
        Cursor.visible = false;
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void EndGameMenu()
    {
        Cursor.visible = true;
        _endGameMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
        _isGameMenuActive = true;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public static void QuitGame()
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
