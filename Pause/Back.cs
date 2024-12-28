using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject targetCanvas; 

    
    public void GoBack()
    {
        
        if (targetCanvas != null)
        {
            
            targetCanvas.SetActive(true);

            
            foreach (Canvas canvas in FindObjectsOfType<Canvas>())
            {
                if (canvas.gameObject != targetCanvas)
                {
                    canvas.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogWarning("Target Canvas íå íàçíà÷åí!");
        }
    }
}
