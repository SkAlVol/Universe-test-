using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject pauseMenuCanvas;      // Canvas для меню паузы
    public GameObject settingsMenuCanvas;   // Canvas для меню настроек
    private bool isSettingsOpen = false;    // Флаг для отслеживания состояния меню настроек

    void Start()
    {
        // Убеждаемся, что Canvas паузы включен, а Canvas настроек отключен при старте
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
        }

        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(false);
        }

        // Проверка на наличие EventSystem, если его нет - создаем его
        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    void Update()
    {
        // Проверка на нажатие клавиши Escape для переключения между меню паузы и настройками
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingsOpen)
            {
                CloseSettings();  // Закрываем меню настроек, возвращаемся к паузе
            }
            else if (pauseMenuCanvas.activeSelf) // Если активно меню паузы
            {
                OpenSettings();   // Открываем меню настроек
            }
        }
    }

    public void OpenSettings()
    {
        // Отключаем Canvas паузы и включаем Canvas настроек
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }

        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(true);
        }

        isSettingsOpen = true; // Устанавливаем флаг для отслеживания состояния меню настроек
    }

    public void CloseSettings()
    {
        // Включаем Canvas паузы и отключаем Canvas настроек
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
        }

        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(false);
        }

        isSettingsOpen = false; // Сбрасываем флаг, так как настройки закрыты
    }
}
