using UnityEngine;

public class CanvasHider : MonoBehaviour
{
    public GameObject canvasToHide;    // ������ �� Canvas, ������� ����� ������
    public Camera mainCamera;          // ������ �� �������� ������ (Main Camera)
    public Camera pauseCamera;         // ������ �� ������ ����� (Pause Camera)

    // �����, ������� ����� ��������� � ������
    public void SwitchToMainCamera()
    {
        // �������� ��������� Canvas, ���� �� ��������
        if (canvasToHide != null)
        {
            canvasToHide.SetActive(false);
        }

        // ���������� Main Camera, ���� ��� ���������
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(true);
        }

        // ��������� Pause Camera, ���� ��� ���������
        if (pauseCamera != null)
        {
            pauseCamera.gameObject.SetActive(false);
        }
    }
}
