using UnityEngine;

public class ButtonSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;  

    
    public void PlaySound()
    {
        if (audioSource != null && !audioSource.isPlaying) 
        {
            audioSource.Play();
        }
        else if (audioSource == null)
        {
            Debug.LogWarning("AudioSource íå íàçíà÷åí!");
        }
    }
}
