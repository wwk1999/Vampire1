using System;
using System.Collections;
using System.Collections.Generic;
using Demo;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameLevelWindow1 : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //public GameObject loopScrollRect;
    private InitOnStart initOnStart;
    public Button exitButton;
    public Button breakButton;

    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;
    public Button level6Button;
    public Button level7Button;
    public Button level8Button;
    public Button level9Button;
    public Button level10Button;
    public Button level11Button;
    public Button level12Button;
    public Button level13Button;
    public Button level14Button;
    public Button level15Button;
    public Button level16Button;
    public Button level17Button;
    public Button level18Button;
    public Button level19Button;
    public Button level20Button;
    
    
    public GameObject level1Info;
    public GameObject level2Info;
    public GameObject level3Info;
    public GameObject level4Info;
    public GameObject level5Info;
    public GameObject level6Info;
    public GameObject level7Info;
    public GameObject level8Info;
    public GameObject level9Info;
    public GameObject level10Info;
    public GameObject level11Info;
    public GameObject level12Info;
    public GameObject level13Info;
    public GameObject level14Info;
    public GameObject level15Info;
    public GameObject level16Info;
    public GameObject level17Info;
    public GameObject level18Info;
    public GameObject level19Info;
    public GameObject level20Info;
    
    
    public GameObject level1TanHao;
    public GameObject level2TanHao;
    public GameObject level3TanHao;
    public GameObject level4TanHao;
    public GameObject level5TanHao;
    public GameObject level6TanHao;
    public GameObject level7TanHao;
    public GameObject level8TanHao;
    public GameObject level9TanHao;
    public GameObject level10TanHao;
    public GameObject level11TanHao;
    public GameObject level12TanHao;
    public GameObject level13TanHao;
    public GameObject level14TanHao;
    public GameObject level15TanHao;
    public GameObject level16TanHao;
    public GameObject level17TanHao;
    public GameObject level18TanHao;
    public GameObject level19TanHao;
    public GameObject level20TanHao;
    
    
    public Animation level1Content;
    public Animation level2Content;
    public Animation level3Content;
    public Animation level4Content;
    public Animation level5Content;
    public Animation level6Content;
    public Animation level7Content;
    public Animation level8Content;
    public Animation level9Content;
    public Animation level10Content;
    public Animation level11Content;
    public Animation level12Content;
    public Animation level13Content;
    public Animation level14Content;
    public Animation level15Content;
    public Animation level16Content;
    public Animation level17Content;
    public Animation level18Content;
    public Animation level19Content;
    public Animation level20Content;

    
    public RectTransform rectTransform; // 当前UI的RectTransform
    private Vector2 lastMousePosition;   // 上次鼠标位置
    
    // 地图尺寸常量
    private const float MAP_WIDTH = 3840f;
    private const float MAP_HEIGHT = 2160f;
    
    // 边界限制变量
    private float maxXBound;
    private float minXBound;
    private float maxYBound;
    private float minYBound;
    
    // 回弹边界变量
    private float snapMaxX;
    private float snapMinX;
    private float snapMaxY;
    private float snapMinY;


    public void SetTanHao()
    {
        level1TanHao.SetActive(LevelInfoConfig.MaxGameLevel==1);
        level2TanHao.SetActive(LevelInfoConfig.MaxGameLevel==2);
        level3TanHao.SetActive(LevelInfoConfig.MaxGameLevel==3);
        level4TanHao.SetActive(LevelInfoConfig.MaxGameLevel==4);
        level5TanHao.SetActive(LevelInfoConfig.MaxGameLevel==5);
        level6TanHao.SetActive(LevelInfoConfig.MaxGameLevel==6);
        level7TanHao.SetActive(LevelInfoConfig.MaxGameLevel==7);
        level8TanHao.SetActive(LevelInfoConfig.MaxGameLevel==8);
        level9TanHao.SetActive(LevelInfoConfig.MaxGameLevel==9);
        level10TanHao.SetActive(LevelInfoConfig.MaxGameLevel==10);
        level11TanHao.SetActive(LevelInfoConfig.MaxGameLevel==11);
        level12TanHao.SetActive(LevelInfoConfig.MaxGameLevel==12);
        level13TanHao.SetActive(LevelInfoConfig.MaxGameLevel==13);
        level14TanHao.SetActive(LevelInfoConfig.MaxGameLevel==14);
        level15TanHao.SetActive(LevelInfoConfig.MaxGameLevel==15);
        level16TanHao.SetActive(LevelInfoConfig.MaxGameLevel==16);
        //level17TanHao.SetActive(LevelInfoConfig.MaxGameLevel==17);
        //level18TanHao.SetActive(LevelInfoConfig.MaxGameLevel==18);
        //level19TanHao.SetActive(LevelInfoConfig.MaxGameLevel==19);
        //level20TanHao.SetActive(LevelInfoConfig.MaxGameLevel==20);
    }

    public void ShowGameLevelButton()
    {
        level1Button.gameObject.SetActive(true);
        level2Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=2);
        level3Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=3);
        level4Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=4);
        level5Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=5);
        level6Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=6);
        level7Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=7);
        level8Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=8);
        level9Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=9);
        level10Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=10);
        level11Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=11);
        level12Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=12);
        level13Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=13);
        level14Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=14);
        level15Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=15);
        level16Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=16);
        //level17Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=17);
        //level18Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=18);
        //level19Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=19);
        //level20Button.gameObject.SetActive(LevelInfoConfig.MaxGameLevel>=20);
    }

    public void PlayGameLevelAnim()
    {
        switch (LevelInfoConfig.MaxGameLevel)
        {
            case 1:
                level1Content.Play("GameLevel");
                break;
            case 2:
                level2Content.Play("GameLevel");
                break;
            case 3:
                level3Content.Play("GameLevel");
                break;
            case 4:
                level4Content.Play("GameLevel");
                break;
            case 5:
                level5Content.Play("GameLevel");
                break;
            case 6:
                level6Content.Play("GameLevel");
                break;
            case 7:
                level7Content.Play("GameLevel");
                break;
            case 8:
                level8Content.Play("GameLevel");
                break;
            case 9:
                level9Content.Play("GameLevel");
                break;
            case 10:
                level10Content.Play("GameLevel");
                break;
            case 11:
                level11Content.Play("GameLevel");
                break;
            case 12:
                level12Content.Play("GameLevel");
                break;
            case 13:
                level13Content.Play("GameLevel");
                break;
            case 14:
                level14Content.Play("GameLevel");
                break;
            case 15:
                level15Content.Play("GameLevel");
                break;
            case 16:
                level16Content.Play("GameLevel");
                break;
            case 17:
                level17Content.Play("GameLevel");
                break;
            case 18:
                level18Content.Play("GameLevel");
                break;
            case 19:
                level19Content.Play("GameLevel");
                break;
            case 20:
                level20Content.Play("GameLevel");
                break;
        }
    }
    
    // 开始拖动时
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("开始拖动");
        lastMousePosition = eventData.position; // 记录开始拖拽位置
    }

    // 拖动中
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position; // 当前鼠标位置
        Vector2 delta = currentMousePosition - lastMousePosition;  // 鼠标移动的差值

        // 改变地图位置
        rectTransform.anchoredPosition += delta;
        
        // 应用边界限制（带阻尼效果）
        Vector3 currentPos = rectTransform.transform.localPosition;
        Vector3 clampedPos = currentPos;
        
        // 水平边界限制
        if (currentPos.x > maxXBound) 
        {
            float overshoot = currentPos.x - maxXBound;
            float damping = Mathf.Clamp01(1f - overshoot / 100f); // 阻尼系数
            clampedPos.x = maxXBound + overshoot * damping * 0.3f;
        }
        else if (currentPos.x < minXBound) 
        {
            float overshoot = minXBound - currentPos.x;
            float damping = Mathf.Clamp01(1f - overshoot / 100f); // 阻尼系数
            clampedPos.x = minXBound - overshoot * damping * 0.3f;
        }
        
        // 垂直边界限制
        if (currentPos.y > maxYBound) 
        {
            float overshoot = currentPos.y - maxYBound;
            float damping = Mathf.Clamp01(1f - overshoot / 100f); // 阻尼系数
            clampedPos.y = maxYBound + overshoot * damping * 0.3f;
        }
        else if (currentPos.y < minYBound) 
        {
            float overshoot = minYBound - currentPos.y;
            float damping = Mathf.Clamp01(1f - overshoot / 100f); // 阻尼系数
            clampedPos.y = minYBound - overshoot * damping * 0.3f;
        }
        
        rectTransform.transform.localPosition = clampedPos;

        // 记录最新的鼠标位置
        lastMousePosition = currentMousePosition;
    }
    
    // 结束拖动时（不必须要实现，可以为空）
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 targetPosition = rectTransform.transform.localPosition;
        Debug.Log("结束拖动");
        
        // 应用回弹边界
        if (rectTransform.transform.localPosition.x > snapMaxX)
        {
            targetPosition.x = snapMaxX;
        }
        if (rectTransform.transform.localPosition.x < snapMinX)
        {
            targetPosition.x = snapMinX;
        }
        if (rectTransform.transform.localPosition.y > snapMaxY)
        {
            targetPosition.y = snapMaxY;
        }
        if (rectTransform.transform.localPosition.y < snapMinY)
        {
            targetPosition.y = snapMinY;
        }
        StartCoroutine(SnapToPosition(targetPosition));
    }
    
    private IEnumerator SnapToPosition(Vector3 targetPosition)
    {
        float duration = 0.3f; // 回弹持续时间
        Vector3 startPosition = rectTransform.transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            
            // 使用缓动函数使动画更自然
            float easeOut = 1f - Mathf.Pow(1f - t, 3f); // 缓出效果
            rectTransform.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, easeOut);
            yield return null;
        }
        
        rectTransform.transform.localPosition = targetPosition; // 确保最终位置准确
    }
    
    // 计算边界限制
    private void CalculateBounds()
    {
        // 获取当前屏幕分辨率
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        
        // 获取Canvas的缩放模式
        Canvas canvas = GetComponentInParent<Canvas>();
        CanvasScaler scaler = canvas?.GetComponent<CanvasScaler>();
        
        // 计算实际的可视区域尺寸
        float viewportWidth = screenWidth;
        float viewportHeight = screenHeight;
        
        if (scaler != null)
        {
            // 根据Canvas Scaler的缩放模式调整
            switch (scaler.uiScaleMode)
            {
                case CanvasScaler.ScaleMode.ScaleWithScreenSize:
                    // 使用参考分辨率
                    viewportWidth = scaler.referenceResolution.x;
                    viewportHeight = scaler.referenceResolution.y;
                    break;
                case CanvasScaler.ScaleMode.ConstantPixelSize:
                    // 像素大小不变，直接使用屏幕分辨率
                    break;
                case CanvasScaler.ScaleMode.ConstantPhysicalSize:
                    // 物理大小不变，需要考虑DPI
                    viewportWidth = screenWidth / Screen.dpi * 96f; // 96 DPI作为参考
                    viewportHeight = screenHeight / Screen.dpi * 96f;
                    break;
            }
        }
        
        // 计算地图在屏幕上的显示尺寸
        float mapDisplayWidth = MAP_WIDTH;
        float mapDisplayHeight = MAP_HEIGHT;
        
        // 计算边界限制（地图边缘不能超出屏幕）
        maxXBound = (mapDisplayWidth - viewportWidth) / 2f;
        minXBound = -(mapDisplayWidth - viewportWidth) / 2f;
        maxYBound = (mapDisplayHeight - viewportHeight) / 2f;
        minYBound = -(mapDisplayHeight - viewportHeight) / 2f;
        
        // 计算回弹边界（稍微宽松一些，提供更好的用户体验）
        float snapMargin = Mathf.Min(160f, Mathf.Min(viewportWidth, viewportHeight) * 0.1f); // 动态计算回弹边距
        snapMaxX = maxXBound - snapMargin;
        snapMinX = minXBound + snapMargin;
        snapMaxY = maxYBound - snapMargin;
        snapMinY = minYBound + snapMargin;
        
        // 确保边界值合理
        if (maxXBound < 0) maxXBound = 0;
        if (minXBound > 0) minXBound = 0;
        if (maxYBound < 0) maxYBound = 0;
        if (minYBound > 0) minYBound = 0;
        if (snapMaxX < 0) snapMaxX = 0;
        if (snapMinX > 0) snapMinX = 0;
        if (snapMaxY < 0) snapMaxY = 0;
        if (snapMinY > 0) snapMinY = 0;
        
        Debug.Log($"屏幕分辨率: {screenWidth}x{screenHeight}, 视口: {viewportWidth:F0}x{viewportHeight:F0}, 边界: X({minXBound:F0}, {maxXBound:F0}), Y({minYBound:F0}, {maxYBound:F0}), 回弹边距: {snapMargin:F0}");
    }
    
    // 当窗口大小改变时重新计算边界
    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            CalculateBounds();
        }
    }
    
    // 当屏幕方向改变时重新计算边界
    void OnRectTransformDimensionsChange()
    {
        // 延迟一帧执行，确保屏幕尺寸已经更新
        StartCoroutine(DelayedCalculateBounds());
    }
    
    private IEnumerator DelayedCalculateBounds()
    {
        yield return null; // 等待一帧
        CalculateBounds();
    }
    
    // 添加一个公共方法，供外部调用重新计算边界
    public void RefreshBounds()
    {
        CalculateBounds();
    }
    
    // 初始化地图位置到中心
    private void InitializeMapPosition()
    {
        if (rectTransform != null)
        {
            // 将地图居中显示
            Vector3 centerPosition = Vector3.zero;
            
            // 如果地图比屏幕大，则居中显示
            if (MAP_WIDTH > Screen.width || MAP_HEIGHT > Screen.height)
            {
                centerPosition = Vector3.zero; // 默认居中
            }
            
            rectTransform.transform.localPosition = centerPosition;
        }
    }

    public void HideLevelInfo()
    {
        level1Info.SetActive(false);
        level2Info.SetActive(false);
        level3Info.SetActive(false);
        level4Info.SetActive(false);
        level5Info.SetActive(false);
        level6Info.SetActive(false);
        level7Info.SetActive(false);
        level8Info.SetActive(false);
        level9Info.SetActive(false);
        level10Info.SetActive(false);
        level11Info.SetActive(false);
        level12Info.SetActive(false);
        level13Info.SetActive(false);
        level14Info.SetActive(false);
        level15Info.SetActive(false);
        level16Info.SetActive(false);
        level17Info.SetActive(false);
        level18Info.SetActive(false);
        level19Info.SetActive(false);
        level20Info.SetActive(false);
    }

    private void OnEnable()
    {
        SetTanHao();
        ShowGameLevelButton();
        PlayGameLevelAnim();
    }

    void Start()
    {
        // 计算边界限制
        CalculateBounds();
        
        // 初始化地图位置到中心
        InitializeMapPosition();
        
        //initOnStart = loopScrollRect.GetComponent<InitOnStart>();
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            WindowController.S.Message.SetActive(false);
            WindowController.S.RoleWindow.SetActive(true);
        });
        breakButton.onClick.AddListener(() =>
        {
            //loopScrollRect.SetActive(false);
            WindowController.S.Message.SetActive(false);
            HideLevelInfo();
        });
        
        
        level1Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡1");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 1;
           HideLevelInfo();
          level1Info.SetActive(true);
        });
        level2Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡2");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 2;
           HideLevelInfo();
           level2Info.SetActive(true);
        });
        level3Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡3");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Elite;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 3;
           HideLevelInfo();
           level3Info.SetActive(true);
        });
        level4Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡4");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 4;
           HideLevelInfo();
           level4Info.SetActive(true);
        });
        level5Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡5");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 5;
           HideLevelInfo();
           level5Info.SetActive(true);
        });
        level6Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡6");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 6;
           HideLevelInfo();
           level6Info.SetActive(true);
        });
        level7Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡7");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Elite;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 7;
           HideLevelInfo();
           level7Info.SetActive(true);
        });
        level8Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡8");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 8;
           HideLevelInfo();
           level8Info.SetActive(true);
        });
        level9Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡9");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 9;
           HideLevelInfo();
           level9Info.SetActive(true);
        });
        level10Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡10");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 10;
           HideLevelInfo();
           level10Info.SetActive(true);
        });
        level11Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡11");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Elite;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 11;
           HideLevelInfo();
           level11Info.SetActive(true);
        });
        level12Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡12");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 12;
           HideLevelInfo();
           level12Info.SetActive(true);
        });
        level13Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡13");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 13;
           HideLevelInfo();
           level13Info.SetActive(true);
        });
        level14Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡14");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 14;
           HideLevelInfo();
           level14Info.SetActive(true);
        });
        level15Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡15");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Elite;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 15;
           HideLevelInfo();
           level15Info.SetActive(true);
        });
        level16Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡16");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 16;
           HideLevelInfo();
           level16Info.SetActive(true);
        });
        level17Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡17");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 17;
           HideLevelInfo();
           level17Info.SetActive(true);
        });
        level18Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡18");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Normal;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 18;
           HideLevelInfo();
           level18Info.SetActive(true);
        });
        level19Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡19");
           LevelInfoConfig.CurrentGameLevelType = LevelType.Elite;
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 19;
           HideLevelInfo();
           level19Info.SetActive(true);
        });
        level20Button.onClick.AddListener(() =>
        {
            Debug.Log("点击关卡20");
            LevelInfoConfig.CurrentGameLevelType = LevelType.Boss;
            WindowController.S.Message.SetActive(false);
            LevelInfoConfig.CurrentGameLevel = 20;
            HideLevelInfo();
            level20Info.SetActive(true);
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
