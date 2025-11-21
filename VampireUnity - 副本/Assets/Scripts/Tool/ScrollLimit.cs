using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollLimit : MonoBehaviour
{
    public RectTransform content;
    public RectTransform viewport;
    public RectTransform lastItem;

    private ScrollRect scrollRect;
    private float minX; // 允许的最左边位置（负值）

    void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    void Start()
    {
        CalculateLimit();
    }

    void LateUpdate()
    {
        // 限制拖动范围
        Vector2 pos = content.anchoredPosition;
        pos.x = Mathf.Clamp(pos.x, minX, 0);
        content.anchoredPosition = pos;
    }

    void CalculateLimit()
    {
        // 先禁用限制，让用户可以自由滚动
        // 将minX设置为一个非常大的负值
        minX = -10000f;
        
        // 可以添加调试日志来帮助排查问题
        Debug.Log("ScrollLimit: 已禁用限制，现在可以自由滚动");
        
        // 如果需要重新启用限制，请取消下面代码的注释并调整计算方法
        /*
        // 获取内容的总宽度
        float contentWidth = 0;
        
        // 寻找内容中最右边的元素
        for (int i = 0; i < content.childCount; i++)
        {
            RectTransform child = content.GetChild(i) as RectTransform;
            if (child != null)
            {
                float rightEdge = child.anchoredPosition.x + child.rect.width / 2;
                contentWidth = Mathf.Max(contentWidth, rightEdge);
            }
        }
        
        // 计算viewport的宽度
        float viewportWidth = viewport.rect.width;
        
        // 确保可以看到所有内容
        minX = Mathf.Min(0, viewportWidth - contentWidth - 100);
        
        Debug.Log($"Content宽度: {contentWidth}, Viewport宽度: {viewportWidth}, 计算的最小X: {minX}");
        */
    }
}