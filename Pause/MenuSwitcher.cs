using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject pauseMenuCanvas;      
    public GameObject settingsMenuCanvas;   
    private bool isSettingsOpen = false;    

    void Start()
    {
        
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
        }

        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(false);
        }

        
        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingsOpen)
            {
                CloseSettings();  // Çàêðûâàåì ìåíþ íàñòðîåê, âîçâðàùàåìñÿ ê ïàóçå
            }
            else if (pauseMenuCanvas.activeSelf) // Åñëè àêòèâíî ìåíþ ïàóçû
            {
                OpenSettings();   // Îòêðûâàåì ìåíþ íàñòðîåê
            }
        }
    }

    public void OpenSettings()
    {
        
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }

        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(true);
        }

        isSettingsOpen = true; // Óñòàíàâëèâàåì ôëàã äëÿ îòñëåæèâàíèÿ ñîñòîÿíèÿ ìåíþ íàñòðîåê
    }

    public void CloseSettings()
    {
        
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
        }

        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(false);
        }

        isSettingsOpen = false; 
    }
}
