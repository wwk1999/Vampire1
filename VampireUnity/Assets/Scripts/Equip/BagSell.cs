using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BagSell : MonoBehaviour
{
    [NonSerialized]public Button SellButton;
    
    [NonSerialized]public Button PullButton;
    [NonSerialized]public GameObject SellParent;
    [NonSerialized]public Button WhiteSellButton;
    [NonSerialized]public Button GreenSellButton;
    [NonSerialized]public Button BlueSellButton;
    [NonSerialized]public Image WhiteSellSure;
    [NonSerialized]public Image GreenSellSure;
    [NonSerialized]public Image BlueSellSure;

    [NonSerialized] public bool IsSellWhite=false;
    [NonSerialized] public bool IsSellGreen=false;
    [NonSerialized] public bool IsSellBlue=false;


    private void Awake()
    {
        SellButton= transform.Find("SellButton").GetComponent<Button>();
        PullButton = transform.Find("PullButton").GetComponent<Button>();
        SellParent = transform.Find("SellParent").gameObject;
        WhiteSellButton = transform.Find("SellParent/SellWhite").GetComponent<Button>();
        GreenSellButton = transform.Find("SellParent/SellGreen").GetComponent<Button>();
        BlueSellButton = transform.Find("SellParent/SellBlue").GetComponent<Button>();
        WhiteSellSure = transform.Find("SellParent/SellWhite/SellSure").GetComponent<Image>();
        GreenSellSure = transform.Find("SellParent/SellGreen/SellSure").GetComponent<Image>();
        BlueSellSure = transform.Find("SellParent/SellBlue/SellSure").GetComponent<Image>();
        
        PullButton.onClick.AddListener(() =>
        {
            SellParent.SetActive(!SellParent.activeSelf);
        });
        
        WhiteSellButton.onClick.AddListener(() =>
        {
            WhiteSellSure.gameObject.SetActive(!WhiteSellSure.gameObject.activeSelf);
            IsSellWhite=!IsSellWhite;
        });
        
        GreenSellButton.onClick.AddListener(() =>
        {
            GreenSellSure.gameObject.SetActive(!GreenSellSure.gameObject.activeSelf);
            IsSellGreen=!IsSellGreen;
        });
        
        BlueSellButton.onClick.AddListener(() =>
        {
            BlueSellSure.gameObject.SetActive(!BlueSellSure.gameObject.activeSelf);
            IsSellBlue=!IsSellBlue;
        });
        //一键分解点击事件
        SellButton.onClick.AddListener(() =>
        {
            // 如果没有选择任何装备类型，直接返回
            if (!IsSellWhite && !IsSellGreen && !IsSellBlue)
            {
                Debug.LogWarning("请先选择要分解的装备类型");
                return;
            }
            
            int[] qualitys = new int[10];
            int index = 0;
            if (IsSellWhite) qualitys[index++] = 1;
            if (IsSellGreen) qualitys[index++] = 2;
            if (IsSellBlue) qualitys[index++] = 3;
            // 使用新方法一次性处理所有装备
            if (BagController.S.bag.GetComponent<BagPanel>().currentBagType == 1)
            {
                BagController.S.SellAllSelectedEquips(IsSellWhite, IsSellGreen, IsSellBlue);
            }
            else if(BagController.S.bag.GetComponent<BagPanel>().currentBagType == 2)
            {
                BagController.S.SellAllSelectedSourceStones(IsSellWhite, IsSellGreen, IsSellBlue);
            }
            BagController.S.ShowEquip();
        });
    }
}
