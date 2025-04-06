using UnityEngine;


public interface IAudioService
{
    void PlayMusic(AudioClip clip);
    void PlaySFX(AudioClip clip);
    void SetMusicVolume(float volume);
    void SetSFXVolume(float volume);
}

