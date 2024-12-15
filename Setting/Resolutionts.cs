using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScreenSettings : MonoBehaviour
{
    public Dropdown resolutionDropdown; // Ссылка на Dropdown для разрешения
    private Resolution[] resolutions; // Список доступных разрешений

    void Start()
    {
        // Выводим текущее разрешение экрана в консоль
        Debug.Log($"Current Resolution: {Screen.currentResolution.width} x {Screen.currentResolution.height}, Refresh Rate: {Screen.currentResolution.refreshRate} Hz");

        resolutions = Screen.resolutions;
        PopulateResolutionDropdown();
    }

    // Заполняем Dropdown для разрешения
    private void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        // Список для уникальных опций разрешений
        var resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width} x {resolutions[i].height}";

            // Избегаем дублирования разрешений
            if (!resolutionOptions.Contains(option))
            {
                resolutionOptions.Add(option);

                // Сохраняем текущий индекс разрешения
                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = resolutionOptions.Count - 1;
                }
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Добавляем обработчик для применения разрешения при изменении значения в Dropdown
        resolutionDropdown.onValueChanged.AddListener(delegate { ApplyResolution(); });
    }

    // Метод для применения выбранного разрешения
    public void ApplyResolution()
    {
        int resolutionIndex = resolutionDropdown.value;

        // Применяем разрешение с текущей частотой обновления
        foreach (Resolution res in resolutions)
        {
            string selectedOption = $"{res.width} x {res.height}";
            string dropdownOption = resolutionDropdown.options[resolutionIndex].text;

            if (selectedOption == dropdownOption)
            {
                Screen.SetResolution(res.width, res.height, Screen.fullScreenMode, res.refreshRate);
                Debug.Log($"Resolution set to: {res.width} x {res.height}, Refresh Rate: {res.refreshRate} Hz");
                break;
            }
        }
    }
}
