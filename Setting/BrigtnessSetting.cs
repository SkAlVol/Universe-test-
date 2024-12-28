using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour
{
    public Slider brightnessSlider; 

    
    public float minAmbientIntensity = 0.2f;
    public float maxAmbientIntensity = 1.0f;

    void Start()
    {
        
        if (brightnessSlider != null)
        {
            brightnessSlider.onValueChanged.AddListener(AdjustBrightness); // Äîáàâëÿåì îáðàáîò÷èê ñîáûòèÿ
            brightnessSlider.value = Mathf.InverseLerp(minAmbientIntensity, maxAmbientIntensity, RenderSettings.ambientIntensity); 
        }
    }

    public void AdjustBrightness(float value)
    {
        
        RenderSettings.ambientIntensity = Mathf.Lerp(minAmbientIntensity, maxAmbientIntensity, value);
    }
}
