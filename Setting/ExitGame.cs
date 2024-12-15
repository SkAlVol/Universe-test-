using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // ���� ����� ����� ��������� � ������ � Unity
    public void QuitGame()
    {
        // ����� �� ����
        Application.Quit();

        // ��������� ��� ������� (�������� ������ � ��������� Unity)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
