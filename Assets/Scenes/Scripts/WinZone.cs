using UnityEngine;

public class WinZone : MonoBehaviour
{
    public AudioSource musicSource; // first audio source
    public AudioSource sfxSource;   // second audio source
    public AudioClip victorySound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.Win();
            musicSource.Stop(); // 🛑 stop music
            sfxSource.PlayOneShot(victorySound); // 🔊 play win sound
        }
    }
}