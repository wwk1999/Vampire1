using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInteractionHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originalScale;
    public Image image;
    private Vector3 imageoriginalScale;
    private Transform targetTransform; // 如果需要放大整个按钮部分
    public int upOffset;
    public int rightOffset;
    private RectTransform rectTransform;

    [NonSerialized] private float scaleFactor = 1.1f; // 按下时放大的比例

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        targetTransform = transform; // 默认操作当前按钮
        if (image != null)
        {
            imageoriginalScale=image.transform.localScale;
        }
        originalScale = targetTransform.localScale; // 存储起始大小
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioController.S.UIPlayNormalClick();
        targetTransform.localScale = originalScale * scaleFactor; // 放大
        rectTransform.anchoredPosition =
            new Vector2(rectTransform.anchoredPosition.x+rightOffset, rectTransform.anchoredPosition.y + upOffset);
        if (image != null)
        {
            image.transform.localScale = imageoriginalScale*scaleFactor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetTransform.localScale = originalScale; // 恢复大小
        rectTransform.anchoredPosition =
            new Vector2(rectTransform.anchoredPosition.x-rightOffset, rectTransform.anchoredPosition.y - upOffset);
        if (image != null)
        {
            image.transform.localScale = imageoriginalScale;
        }
    }
}