using System.Collections;
using System.Collections.Generic;
using Demo;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelWindow1 : MonoBehaviour
{
    public GameObject loopScrollRect;
    private InitOnStart initOnStart;
    public GameObject levelInfoRight;
    public GameObject levelInfoLeft;
    public GameObject monsterLeft1;
    public GameObject monsterLeft2;
    public GameObject monsterLeft3;
    public GameObject monsterLeft4;
    public GameObject monsterLeft5;
    public GameObject monsterRight1;
    public GameObject monsterRight2;
    public GameObject monsterRight3;
    public GameObject monsterRight4;
    public GameObject monsterRight5;
    public Button exitButton;
    public Button breakButton;
    public Button cancelLeftButton;
    public Button cancelRightButton;
    public Button gameLevelFightLeftButton;//左挑战按钮
    public Button gameLevelFightRightButton;//右挑战按钮


    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;
    public Button level6Button;
    public Button level7Button;
    public Button level8Button;
    public Button level9Button;
    void Start()
    {
        initOnStart = loopScrollRect.GetComponent<InitOnStart>();
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            WindowController.S.Message.SetActive(false);
            WindowController.S.RoleWindow.SetActive(true);
        });
        breakButton.onClick.AddListener(() =>
        {
            loopScrollRect.SetActive(false);
            WindowController.S.Message.SetActive(false);
            levelInfoRight.gameObject.SetActive(false);
            levelInfoLeft.gameObject.SetActive(false);
        });
        cancelLeftButton.onClick.AddListener(() =>
        {
            loopScrollRect.SetActive(false);
            WindowController.S.Message.SetActive(false);
            levelInfoRight.gameObject.SetActive(false);
            levelInfoLeft.gameObject.SetActive(false);
        });
        cancelRightButton.onClick.AddListener(() =>
        {
            loopScrollRect.SetActive(false);
            WindowController.S.Message.SetActive(false);
            levelInfoRight.gameObject.SetActive(false);
            levelInfoLeft.gameObject.SetActive(false);
        });
        gameLevelFightLeftButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            WindowController.S.Message.SetActive(false);
            WindowController.S.SceneLoadingWindow.SetActive(true);
        });
        gameLevelFightRightButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            WindowController.S.Message.SetActive(false);
            WindowController.S.SceneLoadingWindow.SetActive(true);
        });
        
        
        
        level1Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡1");
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 1;
           loopScrollRect.SetActive(true);
           Debug.Log(LevelInfoConfig.LevelInfoItem1.DiaoLuoIconList.Count);
           initOnStart.ReFill(LevelInfoConfig.LevelInfoItem1.DiaoLuoIconList.Count);
           loopScrollRect.transform.localPosition = LevelInfoConfig.LevelInfoItem1.LoopScrollPos;
            LevelInfoConfig.CurrentGameLevelType = LevelInfoConfig.LevelInfoItem1.LevelType;
            if (LevelInfoConfig.LevelInfoItem1.LevelInfoDir)
            {
                levelInfoRight.SetActive(true);
                levelInfoRight.transform.localPosition= LevelInfoConfig.LevelInfoItem1.LevelInfoPos;
                levelInfoLeft.SetActive(false);
                switch (LevelInfoConfig.LevelInfoItem1.LevelType)
                {
                    case LevelType.Normal:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(false);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(true);
                        break;
                }
            }
            else
            {
                levelInfoRight.SetActive(false);
                levelInfoLeft.transform.localPosition= LevelInfoConfig.LevelInfoItem1.LevelInfoPos;
                levelInfoLeft.SetActive(true);
                switch (LevelInfoConfig.LevelInfoItem1.LevelType)
                {
                    case LevelType.Normal:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(false);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(true);
                        break;
                }
            }
        });
        level2Button.onClick.AddListener(() =>
        {
            Debug.Log("点击关卡2");
            WindowController.S.Message.SetActive(false);
            LevelInfoConfig.CurrentGameLevel = 2;
            loopScrollRect.SetActive(true);
            loopScrollRect.transform.localPosition = LevelInfoConfig.LevelInfoItem2.LoopScrollPos;
           initOnStart.ReFill(LevelInfoConfig.LevelInfoItem2.DiaoLuoIconList.Count);
            LevelInfoConfig.CurrentGameLevelType = LevelInfoConfig.LevelInfoItem2.LevelType;
            if (LevelInfoConfig.LevelInfoItem2.LevelInfoDir)
            {
                levelInfoRight.SetActive(true);
                levelInfoRight.transform.localPosition= LevelInfoConfig.LevelInfoItem2.LevelInfoPos;
                levelInfoLeft.SetActive(false);
                switch (LevelInfoConfig.LevelInfoItem2.LevelType)
                {
                    case LevelType.Normal:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(false);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(true);
                        break;
                }
            }
            else
            {
                levelInfoRight.SetActive(false);
                levelInfoLeft.transform.localPosition= LevelInfoConfig.LevelInfoItem2.LevelInfoPos;
                levelInfoLeft.SetActive(true);
                switch (LevelInfoConfig.LevelInfoItem2.LevelType)
                {
                    case LevelType.Normal:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(false);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(true);
                        break;
                }
            }
        });
        level3Button.onClick.AddListener(() =>
        {
           Debug.Log("点击关卡3");
           WindowController.S.Message.SetActive(false);
           LevelInfoConfig.CurrentGameLevel = 3;
           loopScrollRect.SetActive(true);
           loopScrollRect.transform.localPosition = LevelInfoConfig.LevelInfoItem3.LoopScrollPos;
           initOnStart.ReFill(LevelInfoConfig.LevelInfoItem3.DiaoLuoIconList.Count);
            LevelInfoConfig.CurrentGameLevelType = LevelInfoConfig.LevelInfoItem3.LevelType;
            if (LevelInfoConfig.LevelInfoItem3.LevelInfoDir)
            {
                levelInfoRight.SetActive(true);
                levelInfoRight.transform.localPosition= LevelInfoConfig.LevelInfoItem3.LevelInfoPos;
                levelInfoLeft.SetActive(false);
                switch (LevelInfoConfig.LevelInfoItem3.LevelType)
                {
                    case LevelType.Normal:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(false);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(true);
                        break;
                }
            }
            else
            {
                levelInfoRight.SetActive(false);
                levelInfoLeft.transform.localPosition= LevelInfoConfig.LevelInfoItem3.LevelInfoPos;
                levelInfoLeft.SetActive(true);
                switch (LevelInfoConfig.LevelInfoItem3.LevelType)
                {
                    case LevelType.Normal:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(false);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(true);
                        break;
                }
            }
        });
        level4Button.onClick.AddListener(() =>
        {
            Debug.Log("点击关卡4");
            loopScrollRect.SetActive(true);
            LevelInfoConfig.CurrentGameLevel = 4;
            LevelInfoConfig.CurrentGameLevelType = LevelInfoConfig.LevelInfoItem4.LevelType;
            if (LevelInfoConfig.LevelInfoItem4.LevelInfoDir)
            {
                levelInfoRight.SetActive(true);
                levelInfoRight.transform.localPosition= LevelInfoConfig.LevelInfoItem4.LevelInfoPos;
                levelInfoLeft.SetActive(false);
                switch (LevelInfoConfig.LevelInfoItem4.LevelType)
                {
                    case LevelType.Normal:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(false);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(true);
                        break;
                }
            }
            else
            {
                levelInfoRight.SetActive(false);
                levelInfoLeft.transform.localPosition= LevelInfoConfig.LevelInfoItem4.LevelInfoPos;
                levelInfoLeft.SetActive(true);
                switch (LevelInfoConfig.LevelInfoItem4.LevelType)
                {
                    case LevelType.Normal:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(false);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(true);
                        break;
                }
            }
        });
        
        level5Button.onClick.AddListener(() =>
        {
            Debug.Log("点击关卡5");
            loopScrollRect.SetActive(true);
            LevelInfoConfig.CurrentGameLevel = 5;
            LevelInfoConfig.CurrentGameLevelType = LevelInfoConfig.LevelInfoItem5.LevelType;
            if (LevelInfoConfig.LevelInfoItem5.LevelInfoDir)
            {
                levelInfoRight.SetActive(true);
                levelInfoRight.transform.localPosition= LevelInfoConfig.LevelInfoItem5.LevelInfoPos;
                levelInfoLeft.SetActive(false);
                switch (LevelInfoConfig.LevelInfoItem5.LevelType)
                {
                    case LevelType.Normal:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(false);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(true);
                        break;
                }
            }
            else
            {
                levelInfoRight.SetActive(false);
                levelInfoLeft.transform.localPosition= LevelInfoConfig.LevelInfoItem5.LevelInfoPos;
                levelInfoLeft.SetActive(true);
                switch (LevelInfoConfig.LevelInfoItem5.LevelType)
                {
                    case LevelType.Normal:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(false);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(true);
                        break;
                }
            }
        });
        
        level6Button.onClick.AddListener(() =>
        {
            Debug.Log("点击关卡6");
            loopScrollRect.SetActive(true);
            LevelInfoConfig.CurrentGameLevel = 6;
            LevelInfoConfig.CurrentGameLevelType = LevelInfoConfig.LevelInfoItem6.LevelType;
            if (LevelInfoConfig.LevelInfoItem6.LevelInfoDir)
            {
                levelInfoRight.SetActive(true);
                levelInfoRight.transform.localPosition= LevelInfoConfig.LevelInfoItem6.LevelInfoPos;
                levelInfoLeft.SetActive(false);
                switch (LevelInfoConfig.LevelInfoItem6.LevelType)
                {
                    case LevelType.Normal:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(false);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(true);
                        break;
                }
            }
            else
            {
                levelInfoRight.SetActive(false);
                levelInfoLeft.transform.localPosition= LevelInfoConfig.LevelInfoItem6.LevelInfoPos;
                levelInfoLeft.SetActive(true);
                switch (LevelInfoConfig.LevelInfoItem6.LevelType)
                {
                    case LevelType.Normal:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(false);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(true);
                        break;
                }
            }
        });
        
        
        
        
        level7Button.onClick.AddListener(() =>
        {
            Debug.Log("点击关卡7");
            loopScrollRect.SetActive(true);
            LevelInfoConfig.CurrentGameLevel = 7;
            LevelInfoConfig.CurrentGameLevelType = LevelInfoConfig.LevelInfoItem7.LevelType;
            if (LevelInfoConfig.LevelInfoItem7.LevelInfoDir)
            {
                levelInfoRight.SetActive(true);
                levelInfoRight.transform.localPosition= LevelInfoConfig.LevelInfoItem7.LevelInfoPos;
                levelInfoLeft.SetActive(false);
                switch (LevelInfoConfig.LevelInfoItem7.LevelType)
                {
                    case LevelType.Normal:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(false);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(true);
                        break;
                }
            }
            else
            {
                levelInfoRight.SetActive(false);
                levelInfoLeft.transform.localPosition= LevelInfoConfig.LevelInfoItem7.LevelInfoPos;
                levelInfoLeft.SetActive(true);
                switch (LevelInfoConfig.LevelInfoItem7.LevelType)
                {
                    case LevelType.Normal:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(false);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(true);
                        break;
                }
            }
        });
        
        level8Button.onClick.AddListener(() =>
        {
            Debug.Log("点击关卡8");
            loopScrollRect.SetActive(true);
            LevelInfoConfig.CurrentGameLevel = 8;
            LevelInfoConfig.CurrentGameLevelType = LevelInfoConfig.LevelInfoItem8.LevelType;
            if (LevelInfoConfig.LevelInfoItem8.LevelInfoDir)
            {
                levelInfoRight.SetActive(true);
                levelInfoRight.transform.localPosition= LevelInfoConfig.LevelInfoItem8.LevelInfoPos;
                levelInfoLeft.SetActive(false);
                switch (LevelInfoConfig.LevelInfoItem8.LevelType)
                {
                    case LevelType.Normal:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(false);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(true);
                        break;
                }
            }
            else
            {
                levelInfoRight.SetActive(false);
                levelInfoLeft.transform.localPosition= LevelInfoConfig.LevelInfoItem8.LevelInfoPos;
                levelInfoLeft.SetActive(true);
                switch (LevelInfoConfig.LevelInfoItem8.LevelType)
                {
                    case LevelType.Normal:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(false);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(true);
                        break;
                }
            }
        });
        
        level9Button.onClick.AddListener(() =>
        {
            Debug.Log("点击关卡9");
            loopScrollRect.SetActive(true);
            LevelInfoConfig.CurrentGameLevel = 9;
            LevelInfoConfig.CurrentGameLevelType = LevelInfoConfig.LevelInfoItem9.LevelType;
            if (LevelInfoConfig.LevelInfoItem9.LevelInfoDir)
            {
                levelInfoRight.SetActive(true);
                levelInfoRight.transform.localPosition= LevelInfoConfig.LevelInfoItem9.LevelInfoPos;
                levelInfoLeft.SetActive(false);
                switch (LevelInfoConfig.LevelInfoItem9.LevelType)
                {
                    case LevelType.Normal:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(false);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterRight1.SetActive(true);
                        monsterRight2.SetActive(true);
                        monsterRight3.SetActive(true);
                        monsterRight4.SetActive(true);
                        monsterRight5.SetActive(true);
                        break;
                }
            }
            else
            {
                levelInfoRight.SetActive(false);
                levelInfoLeft.transform.localPosition= LevelInfoConfig.LevelInfoItem9.LevelInfoPos;
                levelInfoLeft.SetActive(true);
                switch (LevelInfoConfig.LevelInfoItem9.LevelType)
                {
                    case LevelType.Normal:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(false);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Elite:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(false);
                        break;
                    case LevelType.Boss:
                        monsterLeft1.SetActive(true);
                        monsterLeft2.SetActive(true);
                        monsterLeft3.SetActive(true);
                        monsterLeft4.SetActive(true);
                        monsterLeft5.SetActive(true);
                        break;
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
