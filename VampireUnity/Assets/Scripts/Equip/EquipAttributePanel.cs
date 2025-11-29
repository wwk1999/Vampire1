using System;
using Mysql;
using UnityEngine;
using UnityEngine.UI;

public class EquipAttributePanel : MonoBehaviour
{
    public Button exitButton;
    public Button installButton;
    public Button sellButton;
    public Button uninstallButton;

    [NonSerialized]public TableBase tableBase;
    [NonSerialized]public BagGrid grid;


    [NonSerialized] public GameObject BagGrid;//背包格子
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void UninstallE()
    {
        EquipTable equip=(EquipTable)tableBase;
        switch (equip.equip_type_id)
        {
            case 2:
                BagController.S.PlayerClothGrid.E.gameObject.SetActive(false);
                BagController.S.PlayerClothGrid = null;
                PlayerEquipConfig.ClothId = 0;
                break;
            case 6:
                BagController.S.PlayerShoeGrid.E.gameObject.SetActive(false);
                BagController.S.PlayerShoeGrid = null;
                PlayerEquipConfig.ShoeId = 0;

                break;
            case 5:
                BagController.S.PlayerRingGrid.E.gameObject.SetActive(false);
                BagController.S.PlayerRingGrid = null;
                PlayerEquipConfig.RingId = 0;

                break;
            case 4:
                BagController.S.PlayerNecklaceGrid.E.gameObject.SetActive(false);
                BagController.S.PlayerNecklaceGrid = null;
                PlayerEquipConfig.NecklaceId = 0;
                break;
            case 3:
                BagController.S.PlayerHelmetGrid.E.gameObject.SetActive(false);
                BagController.S.PlayerHelmetGrid = null;
                PlayerEquipConfig.HelmetId = 0;

                break;
            case 1:
                BagController.S.PlayerCloakGrid.E.gameObject.SetActive(false);
                BagController.S.PlayerCloakGrid = null;
                PlayerEquipConfig.CloakId = 0;

                break;
        }
    }
    
    void Start()
    {
        
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
        
        
        if (uninstallButton != null)
        {
            // 移除旧的监听器
            uninstallButton.onClick.RemoveAllListeners();
            
            uninstallButton.onClick.AddListener(() =>
            {
                Debug.Log("EquipAttributePanel: 点击了卸下按钮");
                
                try
                {
                    UninstallE();
                    BagController.S.RefreshPlayerEquip();    
                    StoreController.S.SaveStoreData();
                    
                    
                    
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
                try
                {
                    EquipTable equip = (EquipTable)tableBase;
                    PlayerData.S.SaveWearEquip(equip.equip_type_id, equip.equipid);
                    StoreController.S.SaveStoreData();
                    int equiptype = equip.equip_type_id;
                    switch (equiptype)
                    {
                        case 2:
                            //将这个装备的属性传到Bagtroller
                            if (BagController.S.PlayerClothGrid != null)
                            {
                                BagController.S.PlayerClothGrid.E.gameObject.SetActive(false);
                            }
                            BagController.S.PlayerClothGrid = grid;
                            break;
                        case 6:
                            //将这个装备的属性传到Bagtroller
                            if (BagController.S.PlayerShoeGrid != null)
                            {
                                BagController.S.PlayerShoeGrid.E.gameObject.SetActive(false);
                            }
                            BagController.S.PlayerShoeGrid = grid;
                            break;
                        case 5:
                            //将这个装备的属性传到Bagtroller
                            if (BagController.S.PlayerRingGrid != null)
                            {
                                BagController.S.PlayerRingGrid.E.gameObject.SetActive(false);
                            }
                            BagController.S.PlayerRingGrid = grid;
                            break;
                        case 4:
                            if (BagController.S.PlayerNecklaceGrid != null)
                            {
                                BagController.S.PlayerNecklaceGrid.E.gameObject.SetActive(false);
                            } 
                            BagController.S.PlayerNecklaceGrid = grid;
                            break;
                        case 3:
                            if (BagController.S.PlayerHelmetGrid != null)
                            {
                                BagController.S.PlayerHelmetGrid.E.gameObject.SetActive(false);
                            }
                            BagController.S.PlayerHelmetGrid = grid;
                            break;
                        case 1:
                            if (BagController.S.PlayerCloakGrid != null)
                            {
                                BagController.S.PlayerCloakGrid.E.gameObject.SetActive(false);
                            } 
                            BagController.S.PlayerCloakGrid = grid;
                            break;
                    }
                    BagController.S.SetE();
                    BagController.S.RefreshPlayerEquip();
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
        sellButton.onClick.AddListener(() =>
        {
            
            
            BagGrid.transform.Find("EquipGridBG").GetComponent<Image>().color =new Color(1, 1, 1, 0);
            BagGrid.transform.Find("BagGridImage").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            BagGrid.transform.Find("Count").GetComponent<Text>().text = null;
            EquipTable equip = (EquipTable)tableBase;
            BagController.S.EquipIdList.Remove(equip.equipid);
            switch (equip.Quality)
            {
                case 1:
                    BagController.S.WhiteEquipidTable.Remove(equip);
                    break;
                case 2:
                    BagController.S.GreenEquipidTable.Remove(equip);
                    break;
                case 3:
                    BagController.S.BlueEquipidTable.Remove(equip);
                    break;
                case 4:
                    BagController.S.PurpleEquipidTable.Remove(equip);
                    break;
                case 5:
                    BagController.S.OrangeEquipidTable.Remove(equip);
                    break;
            }
            BagController.S.EquipIdList.Remove(equip.equipid);
            StoreController.S.SaveStoreData();
            Destroy(gameObject);
        });
       
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
