using UnityEngine;

public class CanvasHider : MonoBehaviour
{
    public GameObject canvasToHide;    // —сылка на Canvas, который нужно скрыть
    public Camera mainCamera;          // —сылка на основную камеру (Main Camera)
    public Camera pauseCamera;         // —сылка на камеру паузы (Pause Camera)

    // ћетод, который нужно прив€зать к кнопке
    public void SwitchToMainCamera()
    {
        // —крываем указанный Canvas, если он назначен
        if (canvasToHide != null)
        {
            canvasToHide.SetActive(false);
        }

        // јктивируем Main Camera, если она назначена
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);
        }

        // ќтключаем Pause Camera, если она назначена
        if (pauseCamera != null)
        {
            pauseCamera.gameObject.SetActive(false);
        }
    }
}
