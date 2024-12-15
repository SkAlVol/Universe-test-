using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightnessSlider;

    void Start()
    {
        // Инициализируем ползунки текущими значениями
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);

        // Привязываем методы к событиям ползунков
        volumeSlider.onValueChanged.AddListener(SetVolume);
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    public void SetVolume(float value)
    {
        // Применяем громкость (например, к глобальному звуку)
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("Volume", value); // Сохраняем значение
    }

    public void SetBrightness(float value)
    {
        // Применяем яркость (например, к освещению)
        RenderSettings.ambientLight = Color.white * value;
        PlayerPrefs.SetFloat("Brightness", value); // Сохраняем значение
    }

    void OnDestroy()
    {
        // Снимаем слушатели для предотвращения утечек памяти
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
        brightnessSlider.onValueChanged.RemoveListener(SetBrightness);
    }
}
