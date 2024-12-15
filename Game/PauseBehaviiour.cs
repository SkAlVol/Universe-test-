using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false; // для отслеживания состояния паузы
    public GameObject mainCamera;  // указание на Main Camera для фиксации её вращения
    private Vector3 fixedRotation; // для сохранения начального поворота камеры

    void Start()
    {
        // Сохраняем начальный поворот камеры при запуске
        if (mainCamera != null)
        {
            fixedRotation = mainCamera.transform.eulerAngles;
        }
    }

    // Функция для постановки на паузу и снятия с неё
    public void TogglePause()
    {
        isPaused = !isPaused; // Меняем состояние паузы

        if (isPaused)
        {
            Time.timeScale = 0;  // Останавливаем время
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Фиксируем вращение камеры
            if (mainCamera != null)
            {
                mainCamera.transform.rotation = Quaternion.Euler(fixedRotation);
            }
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Камера снова может вращаться
        }
    }
}
