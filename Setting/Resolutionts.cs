using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScreenSettings : MonoBehaviour
{
    public Dropdown resolutionDropdown; 
    private Resolution[] resolutions; 

    void Start()
    {
        
        Debug.Log($"Current Resolution: {Screen.currentResolution.width} x {Screen.currentResolution.height}, Refresh Rate: {Screen.currentResolution.refreshRate} Hz");

        resolutions = Screen.resolutions;
        PopulateResolutionDropdown();
    }

    
    private void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        
        var resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width} x {resolutions[i].height}";

            
            if (!resolutionOptions.Contains(option))
            {
                resolutionOptions.Add(option);

                
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

        
        resolutionDropdown.onValueChanged.AddListener(delegate { ApplyResolution(); });
    }

    
    public void ApplyResolution()
    {
        int resolutionIndex = resolutionDropdown.value;

       
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
