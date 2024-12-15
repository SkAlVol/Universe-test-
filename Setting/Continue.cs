using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvasToHide;       // Ссылка на Canvas, который нужно скрыть
    public Camera mainCamera;             // Ссылка на основную камеру (Main Camera)
    public Camera pauseCamera;            // Ссылка на камеру паузы (Pause Camera)

    // Метод, который нужно привязать к кнопке
    public void SwitchToMainCamera()
    {
        // Проверяем, есть ли Canvas, Pause Camera и Main Camera
        if (canvasToHide != null)
        {
            canvasToHide.SetActive(false);  // Скрываем Canvas
        }

        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);  // Включаем Main Camera
        }

        if (pauseCamera != null)
        {
            pauseCamera.gameObject.SetActive(false);  // Отключаем Pause Camera
        }
    }
}
