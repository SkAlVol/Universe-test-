using UnityEngine;
using UnityEngine.EventSystems; // Не забудьте добавить, чтобы использовать EventSystem

public class PauseManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera pauseCamera;
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Start()
    {
        // Изначально активируем mainCamera, отключаем pauseCamera и скрываем курсор
        mainCamera.enabled = true;
        pauseCamera.enabled = false;
        pauseMenuUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // Блокирует курсор в центре экрана
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        // Возвращаемся к mainCamera, скрываем меню и курсор
        mainCamera.enabled = true;
        pauseCamera.enabled = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Отключаем курсор и блокируем его
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        // Переключаемся на pauseCamera, показываем меню и включаем курсор
        mainCamera.enabled = false;
        pauseCamera.enabled = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Делаем курсор свободным через задержку
        Invoke(nameof(ShowCursor), 0.1f); // Вызываем ShowCursor с небольшой задержкой
    }

    private void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EventSystem.current.SetSelectedGameObject(null); // Снимаем выделение, чтобы курсор можно было использовать
    }
}
