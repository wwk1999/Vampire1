using System;
using Mysql;
using Tool;
using UnityEngine;
using UnityEngine.UI;

public enum EquipType
{
    None,
    Equip,
    SourceStone
}
public class BagGrid : MonoBehaviour
{
    [NonSerialized]public TableBase tableBase;
    [NonSerialized]public EquipType EquipType;
    public Button gridButton;
    [NonSerialized]public Sprite equipAttributeImage;
    public GameObject E;

    private void Awake()
    {
        
        // 移除旧的监听器，防止重复添加
        gridButton.onClick.RemoveAllListeners();
        
        // 添加新的点击监听器
        gridButton.onClick.AddListener(() =>
        {
            
            // 检查是否已存在MaskLayer
            if (BagController.S.MaskLayer != null)
            {
                Debug.LogWarning("BagGrid.OnClick: MaskLayer已存在，可能有未关闭的装备属性面板");
                return;
            }
            
            //生成蒙层
            BagController.S.CreateMaskLayer();
            
            // 检查MaskLayer是否成功创建
            if (BagController.S.MaskLayer == null)
            {
                Debug.LogError("BagGrid.OnClick: 创建MaskLayer失败");
                return;
            }
            
            //显示装备属性面板
            try
            {
                BagController.S.ShowEquipAttributePanel(tableBase, EquipType,gameObject);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"BagGrid.OnClick: 显示装备属性面板异常: {e.Message}\n{e.StackTrace}");
                // 出错时确保蒙层被销毁
                BagController.S.DestroyMaskLayer();
            }
        });
    }

    private void OnDestroy()
    {
        // 确保监听器被移除
        if (gridButton != null)
        {
            gridButton.onClick.RemoveAllListeners();
        }
    }
}
