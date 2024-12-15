using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour
{
    public Slider brightnessSlider; // ������ �� UI Slider

    // ����������� � ������������ �������� �������
    public float minAmbientIntensity = 0.2f;
    public float maxAmbientIntensity = 1.0f;

    void Start()
    {
        // ����������, ��� ���� �������
        if (brightnessSlider != null)
        {
            brightnessSlider.onValueChanged.AddListener(AdjustBrightness); // ��������� ���������� �������
            brightnessSlider.value = Mathf.InverseLerp(minAmbientIntensity, maxAmbientIntensity, RenderSettings.ambientIntensity); // ������������� ��������
        }
    }

    public void AdjustBrightness(float value)
    {
        // �������� ������������� ambient light � �������� minAmbientIntensity � maxAmbientIntensity
        RenderSettings.ambientIntensity = Mathf.Lerp(minAmbientIntensity, maxAmbientIntensity, value);
    }
}
