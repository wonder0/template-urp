using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LoadingScreenUI : MonoBehaviour
{
    public GameObject container;
    public Slider progressBar;
    public TextMeshProUGUI progressText;

    public void Show() => container.SetActive(true);
    public void Hide() => container.SetActive(false);

    public void SetProgress(float progress)
    {
        progressBar.value = progress;
        progressText.text = Mathf.RoundToInt(progress * 100f) + "%";
    }
}
