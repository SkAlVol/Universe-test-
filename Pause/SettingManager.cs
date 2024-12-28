using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightnessSlider;

    void Start()
    {
        
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);

        
        volumeSlider.onValueChanged.AddListener(SetVolume);
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    public void SetVolume(float value)
    {
        
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("Volume", value); 
    }

    public void SetBrightness(float value)
    {
       
        RenderSettings.ambientLight = Color.white * value;
        PlayerPrefs.SetFloat("Brightness", value);
    }

    void OnDestroy()
    {
        
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
        brightnessSlider.onValueChanged.RemoveListener(SetBrightness);
    }
}
