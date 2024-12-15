using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText;  // Ссылка на UI Text для отображения FPS

    private void Update()
    {
        // Рассчитываем FPS
        float currentFPS = 1.0f / Time.unscaledDeltaTime;

        // Обновляем текстовый компонент
        if (fpsText != null)
        {
            fpsText.text = "FPS: " + Mathf.RoundToInt(currentFPS).ToString();
        }
    }
}
