using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource sfxSource;
    public AudioSource musicSource;
    public string[] musicClips;
    private int currentMusicIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PlayMusic(currentMusicIndex);
    }

    public void PlaySFX(string clipName)
    {
        if (sfxSource == null)
        {
            Debug.LogError("PlaySFX: sfxSource is not assigned.");
            return;
        }

        if (string.IsNullOrEmpty(clipName))
        {
            Debug.LogWarning("PlaySFX: Clip name is null or empty.");
            return;
        }

        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + clipName);
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"PlaySFX: Clip '{clipName}' not found in Resources/Sounds.");
        }
    }
    public void StopSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.Stop();
        }
        else
        {
            Debug.LogWarning("StopSFX: sfxSource is not assigned.");
        }
    }

    public void PlayMusic(int index)
    {
        if (index < 0 || index >= musicClips.Length)
        {
            Debug.LogWarning("PlayMusic: Індекс поза межами діапазону.");
            return;
        }

        string clipName = musicClips[index];
        if (string.IsNullOrEmpty(clipName))
        {
            Debug.LogWarning("PlayMusic: Clip name is null or empty.");
            return;
        }

        AudioClip clip = Resources.Load<AudioClip>("Music/" + clipName);
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning($"PlayMusic: Clip '{clipName}' not found in Resources/Music.");
        }
    }
    public void PlayNextMusic()
    {
        currentMusicIndex = (currentMusicIndex + 1) % musicClips.Length;
        PlayMusic(currentMusicIndex);
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
}
