using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvasToHide;       
    public Camera mainCamera;             
    public Camera pauseCamera;            

    
    public void SwitchToMainCamera()
    {
        
        if (canvasToHide != null)
        {
            canvasToHide.SetActive(false);  
        }

        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);  
        }

        if (pauseCamera != null)
        {
            pauseCamera.gameObject.SetActive(false);  
        }
    }
}
