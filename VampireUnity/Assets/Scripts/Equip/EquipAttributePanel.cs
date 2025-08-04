using System;
using Mysql;
using UnityEngine;
using UnityEngine.UI;

public class EquipAttributePanel : MonoBehaviour
{
    public Button exitButton;
    public Button installButton;
    public Button sellButton;
    [NonSerialized]public int CurrentequipId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"EquipAttributePanel.Start: 初始化装备属性面板，装备ID: {CurrentequipId}");
        
        // 退出按钮
        if (exitButton != null)
        {
            // 移除旧的监听器
            exitButton.onClick.RemoveAllListeners();
            
            exitButton.onClick.AddListener(() =>
            {
                Debug.Log("EquipAttributePanel: 点击了退出按钮");
                
                try
                {
                    // 先销毁蒙层，再销毁自身
                    if (BagController.S != null)
                    {
                        BagController.S.DestroyMaskLayer();
                    }
                    else
                    {
                        Debug.LogError("EquipAttributePanel: BagController.S为null");
                    }
                    
                    Destroy(gameObject);
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"EquipAttributePanel: 退出按钮异常: {e.Message}\n{e.StackTrace}");
                }
            });
        }
        else
        {
            Debug.LogError("EquipAttributePanel: exitButton为null");
        }
        
        // 装备按钮
        if (installButton != null)
        {
            // 移除旧的监听器
            installButton.onClick.RemoveAllListeners();
            
            installButton.onClick.AddListener(() =>
            {
                Debug.Log($"EquipAttributePanel: 点击了装备按钮，装备ID: {CurrentequipId}");
                
                try
                {
                    //获取equipid的第一个数字
                    int equiptype = CurrentequipId / 10000000;
                    switch (equiptype)
                    {
                        case 4:
                            //将这个装备的属性传到Bagtroller
                            BagController.S.PlayerClothAttribute = BagController.S.EquipidTable[CurrentequipId];
                            BagController.S.InstallCloth(CurrentequipId);
                            break;
                        case 5:
                            //将这个装备的属性传到Bagtroller
                            BagController.S.PlayerShoeAttribute = BagController.S.EquipidTable[CurrentequipId];
                            BagController.S.InstallShoe(CurrentequipId);
                            break;
                        case 6:
                            //将这个装备的属性传到Bagtroller
                            BagController.S.PlayerRingAttribute = BagController.S.EquipidTable[CurrentequipId];
                            BagController.S.InstallRing(CurrentequipId);
                            break;
                        case 7:
                            BagController.S.PlayerNecklaceAttribute = BagController.S.EquipidTable[CurrentequipId];
                            BagController.S.InstallNecklace(CurrentequipId);
                            break;
                        case 8:
                            BagController.S.PlayerHelmetAttribute = BagController.S.EquipidTable[CurrentequipId];
                            BagController.S.InstallHelmet(CurrentequipId);
                            break;
                        case 9:
                            BagController.S.PlayerCloakAttribute = BagController.S.EquipidTable[CurrentequipId];
                            BagController.S.InstallCloak(CurrentequipId);
                            break;
                    }
                    BagController.S.ComputeEquipAttribute();
                    //BagController.S.ComputeTotalAttribute();//更新人物和装备属性
                    BagController.S.DestroyMaskLayer();
                    Destroy(gameObject);
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"EquipAttributePanel: 装备按钮异常: {e.Message}\n{e.StackTrace}");
                    // 确保出错时仍然销毁面板和蒙层
                    BagController.S.DestroyMaskLayer();
                    Destroy(gameObject);
                }
            });
        }
        
        // 出售按钮
        if (sellButton != null)
        {
            // 暂不实现
        }
    }

    private void OnDestroy()
    {
        Debug.Log("EquipAttributePanel.OnDestroy: 装备属性面板被销毁");
        
        // 确保在销毁时MaskLayer也被清理
        if (BagController.S != null && BagController.S.MaskLayer != null)
        {
            Debug.Log("EquipAttributePanel.OnDestroy: 检测到MaskLayer未销毁，尝试销毁");
            BagController.S.DestroyMaskLayer();
        }
    }
}
