using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get { return instance; }
    }

    public AudioClip bgmClip; // Assign your WAV file here through the Inspector
    private AudioSource audioSource;
    [Range(0f, 1f)]
    public float defaultVolume = 0.5f; // Set your desired default volume here

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // Ensure there's only one AudioManager
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject); // Prevent this object from being destroyed when loading a new scene
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = bgmClip;
        audioSource.volume = defaultVolume; // Set the default volume
        audioSource.Play();
    }

    // Method to set the BGM volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // Method to get the current BGM volume
    public float GetVolume()
    {
        return audioSource.volume;
    }
}