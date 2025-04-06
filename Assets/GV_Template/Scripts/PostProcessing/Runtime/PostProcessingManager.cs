using UnityEngine;
using UnityEngine.Rendering;


public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager Instance { get; private set; }

    [Header("Target Volume")]
    public Volume targetVolume;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ApplyPreset(PostProcessingPreset preset)
    {
        if (preset != null && preset.volumeProfile != null)
        {
            targetVolume.profile = preset.volumeProfile;
        }
    }
}
