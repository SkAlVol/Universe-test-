using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject targetCanvas; // ������� Canvas, ������� ����� ������������

    // ����� ��� ������������ �� ������� Canvas
    public void GoBack()
    {
        // ���������, ��� Canvas �������� � Inspector
        if (targetCanvas != null)
        {
            // ���������� ������� Canvas
            targetCanvas.SetActive(true);

            // ������������ ��������� Canvas'�
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
            Debug.LogWarning("Target Canvas �� ��������!");
        }
    }
}
