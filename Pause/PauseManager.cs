using UnityEngine;
using UnityEngine.EventSystems; // �� �������� ��������, ����� ������������ EventSystem

public class PauseManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera pauseCamera;
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Start()
    {
        // ���������� ���������� mainCamera, ��������� pauseCamera � �������� ������
        mainCamera.enabled = true;
        pauseCamera.enabled = false;
        pauseMenuUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // ��������� ������ � ������ ������
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
        // ������������ � mainCamera, �������� ���� � ������
        mainCamera.enabled = true;
        pauseCamera.enabled = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // ��������� ������ � ��������� ���
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        // ������������� �� pauseCamera, ���������� ���� � �������� ������
        mainCamera.enabled = false;
        pauseCamera.enabled = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // ������ ������ ��������� ����� ��������
        Invoke(nameof(ShowCursor), 0.1f); // �������� ShowCursor � ��������� ���������
    }

    private void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EventSystem.current.SetSelectedGameObject(null); // ������� ���������, ����� ������ ����� ���� ������������
    }
}
