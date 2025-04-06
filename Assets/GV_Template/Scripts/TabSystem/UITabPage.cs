using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class UITabPage : MonoBehaviour
{
    public float transitionDuration = 0.25f;
    public Ease transitionEase = Ease.OutSine;
    private CanvasGroup canvasGroup;
    private RectTransform rect;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rect = GetComponent<RectTransform>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        rect.localScale = new Vector3(0.95f, 0.95f, 1f);

        canvasGroup.DOFade(1f, transitionDuration).SetEase(transitionEase);
        rect.DOScale(Vector3.one, transitionDuration).SetEase(transitionEase);

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        canvasGroup.DOFade(0f, transitionDuration).SetEase(Ease.InSine);
        rect.DOScale(new Vector3(0.95f, 0.95f, 1f), transitionDuration).SetEase(Ease.InSine);

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        DOVirtual.DelayedCall(transitionDuration, () => gameObject.SetActive(false));
    }
}
