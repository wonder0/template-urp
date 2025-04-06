using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ModalView : MonoBehaviour
{
    [Header("References")]
    public CanvasGroup backdrop;
    public RectTransform panel;

    [Header("Animation")]
    public float fadeDuration = 0.2f;
    public float scaleDuration = 0.25f;
    public Ease openEase = Ease.OutBack;
    public Ease closeEase = Ease.InBack;

    [Header("Settings")]
    public bool destroyOnClose = false;

    [Header("Optional Buttons")]
    public Button openButton;
    public Button closeButton;
    public Button confirmButton;
    public Button cancelButton;

    [Header("Events")]
    public UnityEngine.Events.UnityEvent onConfirm;
    public UnityEngine.Events.UnityEvent onCancel;


    private Vector3 panelStartScale = Vector3.one * 0.8f;

    private void Awake()
    {
        backdrop.alpha = 0;
        panel.localScale = panelStartScale;
        // gameObject.SetActive(false); // start hidden
    }

    private void Start()
    {
        if (openButton != null) openButton.onClick.AddListener(Show);
        if (closeButton != null) closeButton.onClick.AddListener(Hide);
        if (confirmButton != null) confirmButton.onClick.AddListener(OnConfirm);
        if (cancelButton != null) cancelButton.onClick.AddListener(OnCancel);
        Hide();
    }


    public void Show()
    {
        gameObject.SetActive(true);

        backdrop.DOFade(1.0f, fadeDuration).SetEase(Ease.OutSine);
        panel.localScale = panelStartScale;
        panel.DOScale(1f, scaleDuration).SetEase(openEase);
    }

    public void Hide()
    {
        backdrop.DOFade(0f, fadeDuration).SetEase(Ease.InSine);
        panel.DOScale(panelStartScale, scaleDuration).SetEase(closeEase)
            .OnComplete(() =>
            {
                if (destroyOnClose)
                    Destroy(gameObject);
                else
                    gameObject.SetActive(false);
            });
    }

    // Hook to button
    public void OnClosePressed()
    {
        // UIAudioManager.Instance?.PlayClick(); // optional
        Hide();
    }

    public void OnConfirm()
    {
        onConfirm?.Invoke(); // Optional UnityEvent
        Hide();
    }

    public void OnCancel()
    {
        onCancel?.Invoke(); // Optional UnityEvent
        Hide();
    }

}
