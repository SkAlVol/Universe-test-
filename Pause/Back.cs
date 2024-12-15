using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject targetCanvas; // Целевой Canvas, который нужно активировать

    // Метод для переключения на целевой Canvas
    public void GoBack()
    {
        // Проверяем, что Canvas назначен в Inspector
        if (targetCanvas != null)
        {
            // Активируем целевой Canvas
            targetCanvas.SetActive(true);

            // Деактивируем остальные Canvas'ы
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
            Debug.LogWarning("Target Canvas не назначен!");
        }
    }
}
