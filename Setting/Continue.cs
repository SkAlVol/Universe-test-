using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvasToHide;       // ������ �� Canvas, ������� ����� ������
    public Camera mainCamera;             // ������ �� �������� ������ (Main Camera)
    public Camera pauseCamera;            // ������ �� ������ ����� (Pause Camera)

    // �����, ������� ����� ��������� � ������
    public void SwitchToMainCamera()
    {
        // ���������, ���� �� Canvas, Pause Camera � Main Camera
        if (canvasToHide != null)
        {
            canvasToHide.SetActive(false);  // �������� Canvas
        }

        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);  // �������� Main Camera
        }

        if (pauseCamera != null)
        {
            pauseCamera.gameObject.SetActive(false);  // ��������� Pause Camera
        }
    }
}
