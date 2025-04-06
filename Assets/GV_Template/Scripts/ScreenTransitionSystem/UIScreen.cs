using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class UIScreen : MonoBehaviour
{

    public enum TransitionType
    {
        Fade,
        Zoom,
        SlideLeft,
        SlideRight,
        SlideUp,
        SlideDown,
        None
    }

    [Header("Transition Settings")]
    public float transitionDuration = 0.3f;
    public Ease transitionEase = Ease.OutSine;
    public bool animateScale = true;
    public Vector3 hiddenScale = new Vector3(0.9f, 0.9f, 1f);

    [Header("Transition Style")]
    public TransitionType transitionType = TransitionType.Fade;


    private CanvasGroup canvasGroup;
    private RectTransform rect;

    Vector2 offScreenPos = Vector2.zero;
    Vector2 onScreenPos = Vector2.zero;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {

        RectTransform rect = GetComponent<RectTransform>();
        switch (transitionType)
        {
            case TransitionType.SlideLeft:
                offScreenPos = new Vector2(Screen.width, 0);
                break;
            case TransitionType.SlideRight:
                offScreenPos = new Vector2(-Screen.width, 0);
                break;
            case TransitionType.SlideUp:
                offScreenPos = new Vector2(0, -Screen.height);
                break;
            case TransitionType.SlideDown:
                offScreenPos = new Vector2(0, Screen.height);
                break;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        switch (transitionType)
        {
            case TransitionType.Fade:
                rect.localScale = Vector3.one;
                canvasGroup.DOFade(1f, transitionDuration).SetEase(transitionEase);
                break;

            case TransitionType.Zoom:
                rect.localScale = hiddenScale;
                rect.DOScale(Vector3.one, transitionDuration).SetEase(transitionEase);
                canvasGroup.DOFade(1f, transitionDuration).SetEase(transitionEase);
                break;

            case TransitionType.SlideLeft:
            case TransitionType.SlideRight:
            case TransitionType.SlideUp:
            case TransitionType.SlideDown:
                rect.anchoredPosition = offScreenPos;
                rect.DOAnchorPos(onScreenPos, transitionDuration).SetEase(transitionEase);
                canvasGroup.DOFade(1f, transitionDuration).SetEase(transitionEase);
                break;

            case TransitionType.None:
            default:
                canvasGroup.alpha = 1;
                break;
        }

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        switch (transitionType)
        {
            case TransitionType.Fade:
                canvasGroup.DOFade(0f, transitionDuration).SetEase(Ease.InSine);
                break;

            case TransitionType.Zoom:
                rect.DOScale(hiddenScale, transitionDuration).SetEase(Ease.InSine);
                canvasGroup.DOFade(0f, transitionDuration).SetEase(Ease.InSine);
                break;

            case TransitionType.SlideLeft:
            case TransitionType.SlideRight:
            case TransitionType.SlideUp:
            case TransitionType.SlideDown:
                rect.DOAnchorPos(offScreenPos, transitionDuration).SetEase(Ease.InSine);
                canvasGroup.DOFade(0f, transitionDuration).SetEase(Ease.InSine);
                break;

            case TransitionType.None:
            default:
                break;
        }

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        DOVirtual.DelayedCall(transitionDuration, () => gameObject.SetActive(false));
    }
}
