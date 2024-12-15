using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour
{
    public Slider brightnessSlider; // Ссылка на UI Slider

    // Минимальные и максимальные значения яркости
    public float minAmbientIntensity = 0.2f;
    public float maxAmbientIntensity = 1.0f;

    void Start()
    {
        // Убеждаемся, что есть слайдер
        if (brightnessSlider != null)
        {
            brightnessSlider.onValueChanged.AddListener(AdjustBrightness); // Добавляем обработчик события
            brightnessSlider.value = Mathf.InverseLerp(minAmbientIntensity, maxAmbientIntensity, RenderSettings.ambientIntensity); // Инициализация слайдера
        }
    }

    public void AdjustBrightness(float value)
    {
        // Изменяем интенсивность ambient light в пределах minAmbientIntensity и maxAmbientIntensity
        RenderSettings.ambientIntensity = Mathf.Lerp(minAmbientIntensity, maxAmbientIntensity, value);
    }
}
