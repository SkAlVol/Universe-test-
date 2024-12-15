using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Этот метод нужно привязать к кнопке в Unity
    public void QuitGame()
    {
        // Выход из игры
        Application.Quit();

        // Сообщение для отладки (работает только в редакторе Unity)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
