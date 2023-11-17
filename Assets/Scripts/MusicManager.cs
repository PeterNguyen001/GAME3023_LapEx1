using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource component to play music
    public AudioClip[] musicClips; // Array of music clips, one for each scene

    private static MusicManager instance;

    void Awake()
    {
        // Singleton pattern to keep the music playing across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        // Ensure that the music loops
        if (audioSource != null)
        {
            audioSource.loop = true;
        }

        
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.buildIndex);
    }

    void PlayMusicForScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < musicClips.Length && musicClips[sceneIndex] != null)
        {
            if (audioSource.clip != musicClips[sceneIndex])
            {
                audioSource.clip = musicClips[sceneIndex];
                audioSource.Play();
            }
        }
    }
}
