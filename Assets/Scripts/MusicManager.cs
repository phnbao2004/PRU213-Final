using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip music; // kéo nhạc vào đây

    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton: chỉ cho phép 1 cái tồn tại
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // không bị xoá khi đổi scene

            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = music;
            audioSource.loop = true;
            audioSource.playOnAwake = true;
            audioSource.volume = 0.5f;

            audioSource.Play();
        }
        else
        {
            Destroy(gameObject); // tránh bị duplicate
        }
    }
}