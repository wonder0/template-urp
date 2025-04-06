using UnityEngine;
using UnityEngine.Audio;



[CreateAssetMenu(menuName = "Template/Audio Settings")]
public class AudioSettings : ScriptableObject
{
    [Range(0.01f, 1f)] public float defaultMusicVolume = 0.75f;
    [Range(0.01f, 1f)] public float defaultSFXVolume = 0.75f;

    public AudioMixerGroup musicGroup;
    public AudioMixerGroup sfxGroup;
}

