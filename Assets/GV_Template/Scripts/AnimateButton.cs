using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class AnimatedButton : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    [Header("Scale Settings")]
    public float normalScale = 1f;
    public float hoverScale = 1.1f;
    public float pressedScale = 0.9f;
    public float animationDuration = 0.1f;

    [Header("Sounds")]
    public bool playClickSound = true;
    public bool playHoverSound = true;

    private RectTransform rectTransform;
    private Button button;
    private bool isPointerOver = false;



    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        button = GetComponent<Button>();

        // Reset to default
        rectTransform.localScale = Vector3.one * normalScale;

        button.onClick.AddListener(() =>
        {
            if (playClickSound)
                AudioUIController.Instance?.PlayClick();
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;

        if (playHoverSound)
            AudioUIController.Instance?.PlayHover();

        AnimateToScale(hoverScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        AnimateToScale(normalScale);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AnimateToScale(pressedScale);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AnimateToScale(isPointerOver ? hoverScale : normalScale);
    }

    private void AnimateToScale(float targetScale)
    {
        rectTransform.DOKill();
        rectTransform.DOScale(Vector3.one * targetScale, animationDuration).SetEase(Ease.OutQuad);
    }
}
