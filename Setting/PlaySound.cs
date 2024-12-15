using UnityEngine;

public class ButtonSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;  // Ссылка на AudioSource

    // Метод для воспроизведения звука
    public void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying) // Проверяем, что звук не воспроизводится
        {
            audioSource.Play();
        }
        else if (audioSource == null)
        {
            Debug.LogWarning("AudioSource не назначен!");
        }
    }
}
