using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TabSystemButton : MonoBehaviour
{
    private TabSystemGroup group;
    private int index;
    private Button button;
    private RectTransform rect;

    public float hoverScale = 1.1f;
    public float scaleDuration = 0.25f;

    private void Awake()
    {
        button = GetComponent<Button>();
        rect = GetComponent<RectTransform>();
    }

    public void Init(TabSystemGroup group, int index)
    {
        this.group = group;
        this.index = index;
        button.onClick.AddListener(() => group.SelectTab(index));
    }

    public void SetSelected(bool selected)
    {
        rect.DOScale(selected ? hoverScale : 1f, scaleDuration).SetEase(Ease.OutSine);
    }

}
