using UnityEngine;

public class AudioUIController : MonoBehaviour
{
    public static AudioUIController Instance;
    public AudioClip buttonSound;

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
    public void OnMusicVolumeChanged(float value)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.SetMusicVolume(value);
    }

    public void OnSFXVolumeChanged(float value)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.SetSFXVolume(value);
    }

    public void PlayClick()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySFX(buttonSound);
    }

    public void PlayHover()
    {

    }

}
