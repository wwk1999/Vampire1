using System;
using System.Collections;
using System.Collections.Generic;
using Mysql;
using UnityEngine;
using UnityEngine.UI;

public class AddUserSourceStoneData
{
    public int id;
    public int userid;
    public int sourcestoneid;
    public int sourcestonecount;
}
public class RoleWindow1 : MonoBehaviour
{
    public Text yuanLinText;
    public Text yuanNengText;
    public Button weaponButton; // 武器按钮
    public Button monsterBookButton; // 怪物图鉴按钮
    public Button bagButton; // 背包按钮
    public Button skillButton;
    public Button taskButton;
    public Button settingButton;
    public Button shopButton;
    public Button startButton;
    public Button yuanlinButton;
    public Button bloodEnergyButton;
    public Text levelText; // 等级文本
    public Slider expSlider; // 经验条
    public Button friendButton; // 好友按钮
    public Button rankButton;

    public void UpdateRoleWindow()
    {
        yuanLinText.text = GlobalPlayerAttribute.BloodEnergy.ToString();// 元灵数量text
        levelText.text= GlobalPlayerAttribute.Level.ToString();
        expSlider.maxValue=GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level];
        expSlider.value=GlobalPlayerAttribute.Exp ;
    }

    private void OnEnable()
    {
        UpdateRoleWindow();
    }

    public void GetSourceStoneConfigSuccess(object[] args)
    {
        if (args[0] == null) return;
        WeaponSourceConfig.SourceStoneConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SourceStoneConfigItem>>(args[0].ToString());
        Debug.Log("获取服务端源石配置成功！");
    }
    public void GetLevelRankSuccess(object[] args)
    {
        if (args[0] == null) return;
        RankConfig.LevelRankData = Newtonsoft.Json.JsonConvert.DeserializeObject<LevelRankData>(args[0].ToString());

        Debug.Log("获取服务端等级排行榜成功！");
    }
    public void GetUserLevelRankSuccess(object[] args)
    {
        if (args[0] == null) return;
        RankConfig.UserLevelRankData = Newtonsoft.Json.JsonConvert.DeserializeObject<UserLevelRankData>(args[0].ToString());
        Debug.Log("获取服务端用户个人等级排行榜成功！");
    }
    
    public void GetUserMonsterCountRankSuccess(object[] args)
    {
        if (args[0] == null) return;
        RankConfig.UserMonsterCountRankData = Newtonsoft.Json.JsonConvert.DeserializeObject<UserMonsterCountRankData>(args[0].ToString());
        Debug.Log("获取服务端用户个人怪物数量排行榜成功！");
    }
    
    public void GetMonsterCountRankSuccess(object[] args)
    {
        if (args[0] == null) return;
        RankConfig.MonsterCountRankData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MonsterCountRankDataItem>>(args[0].ToString());
        Debug.Log("获取服务端怪物数量排行榜成功！");
    }
    public void GetUserSourceStoneSuccess(object[] args)
    {
        if (args[0] == null) return;
        WeaponSourceConfig.UserSourceStone = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SourceStoneData>>(args[0].ToString());
        foreach (var item in WeaponSourceConfig.UserSourceStone)
        {
            SourceStoneTable sourceStoneTable = new SourceStoneTable();
            sourceStoneTable.SourceStoneId = item.sourcestoneid;
            sourceStoneTable.SourceStoneName = WeaponSourceConfig.GetSourceStoneConfigById(item.sourcestoneid).sourcestonename;
            sourceStoneTable.SourceStoneDesc = item.sourcestone.sourcestoneeffect;
            sourceStoneTable.Count = item.sourcestonecount;
            sourceStoneTable.Quality = WeaponSourceConfig.GetSourceStoneConfigById(item.sourcestoneid).quality;
            sourceStoneTable.SourceStoneType = WeaponSourceConfig.GetSourceStoneConfigById(item.sourcestoneid).sourcestonetype;
            BagController.S.SourceStoneTable.Add(sourceStoneTable);
            switch (sourceStoneTable.Quality)
            {
                case 1:
                    BagController.S.WhiteWeaponSourceStoneTable.Add(sourceStoneTable);
                    break;
                case 2:
                    BagController.S.GreenWeaponSourceStoneTable.Add(sourceStoneTable);
                    break;
                case 3:
                    BagController.S.BlueWeaponSourceStoneTable.Add(sourceStoneTable);
                    break;
                case 4:
                    BagController.S.PurpleWeaponSourceStoneTable.Add(sourceStoneTable);
                    break;
                case 5:
                    BagController.S.OrangeWeaponSourceStoneTable.Add(sourceStoneTable);
                    break;
            }
        }
        Debug.Log("获取服务器用户源石成功！");
    }
    
   
    
   
    
    
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("GetSourceStoneConfigSuccess",GetSourceStoneConfigSuccess);
        ObserverModuleManager.S.RegisterEvent("GetLevelRankSuccess",GetLevelRankSuccess);
        ObserverModuleManager.S.RegisterEvent("GetUserLevelRankSuccess",GetUserLevelRankSuccess);
        ObserverModuleManager.S.RegisterEvent("GetUserMonsterCountRankSuccess",GetUserMonsterCountRankSuccess);
        ObserverModuleManager.S.RegisterEvent("GetMonsterCountRankSuccess",GetMonsterCountRankSuccess);
        ObserverModuleManager.S.RegisterEvent("GetUserSourceStoneSuccess",GetUserSourceStoneSuccess);
        // yuanLinText.text = GlobalPlayerAttribute.BloodEnergy.ToString();// 元灵数量text
        // //GlobalPlayerAttribute.ExpDic = ExperienceController.S.GetExperienceFromMysql();
        // expSlider.maxValue=GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level];
        // expSlider.value = GlobalPlayerAttribute.Exp;
        // levelText.text = GlobalPlayerAttribute.Level.ToString();
        Debug.Log("点击进入角色界面");
        InitEquip();
        BagController.S.IsInit = true;
        
        
        
        
        rankButton.onClick.AddListener(() =>
        {
            WindowController.S.RankWindow.SetActive(true);
        });
        
        friendButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入好友列表界面");
            WindowController.S.FriendList.SetActive(true);
        });
        
        monsterBookButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入怪物图鉴界面");
            WindowController.S.MonsterBookWindow.SetActive(true);
        });
        bagButton.onClick.AddListener(() =>
        {
            Debug.Log("开始执行ShowBag方法");
        
            // 检查背包对象是否为空
            if (BagController.S.bag == null)
            {
                Debug.LogError("ShowBag出错: bag对象为null，尝试重新初始化背包");
                BagController.S.InitBag();
            
                // 再次检查背包对象
                if (BagController.S.bag == null)
                {
                    Debug.LogError("ShowBag出错: 重新初始化背包后bag仍为null，无法显示背包");
                    return;
                }
            }
        
            // 检查装备列表是否为空
            if (BagController.S.EquipIdList == null)
            {
                Debug.LogWarning("ShowBag警告: EquipIdList为null，初始化为空列表");
                BagController.S.EquipIdList = new Dictionary<int, EquipTable>();
            }
        
            Debug.Log($"暂停游戏，当前EquipIdList中有 {BagController.S.EquipIdList.Count} 件装备");
        
            // 暂停游戏
            BagController.S.bag.gameObject.SetActive(true);
        
            
            Debug.Log("调用ShowEquip方法显示装备");
            BagController.S.ShowEquip();
            BagController.S.InitPlayerEquip();
            BagController.S.SetE();
        
            Debug.Log("ShowBag方法执行完成");
        });
        weaponButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入武器界面");
            WindowController.S.WeaponWindow.SetActive(true);
            gameObject.SetActive(false);
        });
        startButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入关卡界面");
            WindowController.S.GameLevelWindow.SetActive(true);
            gameObject.SetActive(false);
        });
        taskButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入任务界面");
            WindowController.S.TaskWindow.SetActive(true);
            gameObject.SetActive(false);
        });
        skillButton.onClick.AddListener(() =>
        {
            Debug.Log("点击进入技能界面");
            WindowController.S.SkillWindow.SetActive(true);
            gameObject.SetActive(false);
        });
        
    }
    
    public void InitEquip()
    {
        if (BagController.S.IsInit)
            return;
        BagController.S.InitEquipidSpriteConfig();
        EquipController.S.GetAllEquipFromMysql();
    }
}
