using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false; 
    public GameObject mainCamera;  
    private Vector3 fixedRotation; 

    void Start()
    {
        
        if (mainCamera != null)
        {
            fixedRotation = mainCamera.transform.eulerAngles;
        }
    }

    
    public void TogglePause()
    {
        isPaused = !isPaused; 

        if (isPaused)
        {
            Time.timeScale = 0; 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Фиксируем вращение камеры
            if (mainCamera != null)
            {
                mainCamera.transform.rotation = Quaternion.Euler(fixedRotation);
            }
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            
        }
    }
}
