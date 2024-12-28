using UnityEngine;
using UnityEngine.EventSystems; 

public class PauseManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera pauseCamera;
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Start()
    {
        
        mainCamera.enabled = true;
        pauseCamera.enabled = false;
        pauseMenuUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        
        mainCamera.enabled = true;
        pauseCamera.enabled = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Îòêëþ÷àåì êóðñîð è áëîêèðóåì åãî
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        
        mainCamera.enabled = false;
        pauseCamera.enabled = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        
        Invoke(nameof(ShowCursor), 0.1f); 
    }

    private void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EventSystem.current.SetSelectedGameObject(null); 
    }
}
