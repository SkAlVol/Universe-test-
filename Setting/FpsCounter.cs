using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText;  

    private void Update()
    {
        
        float currentFPS = 1.0f / Time.unscaledDeltaTime;

        
        if (fpsText != null)
        {
            fpsText.text = "FPS: " + Mathf.RoundToInt(currentFPS).ToString();
        }
    }
}
