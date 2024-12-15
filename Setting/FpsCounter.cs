using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText;  // ������ �� UI Text ��� ����������� FPS

    private void Update()
    {
        // ������������ FPS
        float currentFPS = 1.0f / Time.unscaledDeltaTime;

        // ��������� ��������� ���������
        if (fpsText != null)
        {
            fpsText.text = "FPS: " + Mathf.RoundToInt(currentFPS).ToString();
        }
    }
}
