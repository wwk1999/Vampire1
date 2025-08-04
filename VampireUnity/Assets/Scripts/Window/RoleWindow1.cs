using System;
using System.Collections;
using System.Collections.Generic;
using Mysql;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        PlayerInfoController.S.GetPlayerInfo(UserController.S.selfuserId);// 获取玩家信息
        yuanLinText.text = GlobalPlayerAttribute.BloodEnergy.ToString();// 元灵数量text
        GlobalPlayerAttribute.ExpDic = ExperienceController.S.GetExperienceFromMysql();
        expSlider.maxValue=GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level];
        expSlider.value = GlobalPlayerAttribute.Exp;
        levelText.text = GlobalPlayerAttribute.Level.ToString();
        Debug.Log("点击进入角色界面");
        InitEquip();
        BagController.S.IsInit = true;
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
                BagController.S.EquipIdList = new List<TableBase>();
            }
        
            Debug.Log($"暂停游戏，当前EquipIdList中有 {BagController.S.EquipIdList.Count} 件装备");
        
            // 暂停游戏
            BagController.S.bag.gameObject.SetActive(true);
        
            try
            {
                Debug.Log("调用ShowEquip方法显示装备");
                BagController.S.ShowEquip();
            }
            catch (System.Exception e)
            {
                Debug.LogError($"ShowBag出错: 调用ShowEquip方法时发生异常: {e.Message}\n{e.StackTrace}");
            }
        
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
        BagController.S.InitSourceStoneSpriteConfig();// 初始化源石的图片配置
        EquipController.S.GetAllEquipFromMysql();
        //BagController.S.EquipIdList= EquipController.S.equipList;
        foreach (var equip in EquipController.S.equipList)//mysql的装备赋值到 BagController.S.EquipIdList
        {
            BagController.S.EquipIdList.Add(equip);
        }
        foreach (var equip in BagController.S.EquipIdList)
        {
            EquipTable equipTable= equip as EquipTable;
            BagController.S.EquipidTable.Add(equip.Equipid, equipTable);
            BagController.S.EquipidSprite.Add(equip.Equipid, BagController.S.EquipidSpriteConfig[equipTable.EquipName]);
            if (equip.Quality == 1) // 白色装备
            {
                BagController.S.WhiteEquipidTable.Add(equip.Equipid, equipTable);
            }
            else if (equip.Quality == 2) // 绿色装备
            {
                BagController.S.GreenEquipidTable.Add(equip.Equipid, equipTable);
            }
            else if (equip.Quality == 3) // 蓝色装备
            {
                BagController.S.BlueEquipidTable.Add(equip.Equipid, equipTable);
            }
            else if (equip.Quality == 4) // 紫色装备
            {
                BagController.S.PurpleEquipidTable.Add(equip.Equipid, equipTable);
            } 
            else if (equip.Quality == 5) // 金色装备
            {
                BagController.S.OrangeEquipidTable.Add(equip.Equipid, equipTable);
            }
        }
    }
}
