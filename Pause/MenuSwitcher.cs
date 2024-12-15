using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject pauseMenuCanvas;      // Canvas ��� ���� �����
    public GameObject settingsMenuCanvas;   // Canvas ��� ���� ��������
    private bool isSettingsOpen = false;    // ���� ��� ������������ ��������� ���� ��������

    void Start()
    {
        // ����������, ��� Canvas ����� �������, � Canvas �������� �������� ��� ������
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
        }

        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(false);
        }

        // �������� �� ������� EventSystem, ���� ��� ��� - ������� ���
        if (FindObjectOfType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    void Update()
    {
        // �������� �� ������� ������� Escape ��� ������������ ����� ���� ����� � �����������
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingsOpen)
            {
                CloseSettings();  // ��������� ���� ��������, ������������ � �����
            }
            else if (pauseMenuCanvas.activeSelf) // ���� ������� ���� �����
            {
                OpenSettings();   // ��������� ���� ��������
            }
        }
    }

    public void OpenSettings()
    {
        // ��������� Canvas ����� � �������� Canvas ��������
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }

        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(true);
        }

        isSettingsOpen = true; // ������������� ���� ��� ������������ ��������� ���� ��������
    }

    public void CloseSettings()
    {
        // �������� Canvas ����� � ��������� Canvas ��������
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
        }

        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(false);
        }

        isSettingsOpen = false; // ���������� ����, ��� ��� ��������� �������
    }
}
