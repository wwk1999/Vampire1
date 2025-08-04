using System;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : MonoBehaviour
{
    public Button detailedAttributesButton;// 详细属性按钮
    public GameObject detailedAttributesPanel;// 详细属性面板
    public GameObject mask;// mask层
    public Button detailedAttributesExitButton;
    
    //属性面板text
    public Text damageText;// 攻击力文本
    public Text critText;// 暴击率文本
    public Text critDamageText;// 暴击伤害文本
    public Text attackSpeedText;// 攻击速度文本
    public Text goodFortuneText;// 幸运值文本
    public Text bloodsuckText;// 吸血文本
    public Text moveSpeedText;// 移动速度文本
    public Text defenseText;// 防御力文本
    public Text hpText;// 生命值文本
    
    public Button playerButton;
    public Button attributeButton;
    
    //属性面板的各个属性的文本
    public Text playerDamageAttributeText;
    public Text playerHPAttributeText;
    public Text playerDefenseAttributeText;
    public Text playerCRITAttributeText;
    public Text playerCRITDamageAttributeText;
    public Text playerMoveSpeedAttributeText;
    public Text playerAttackSpeedAttributeText;
    public Text playerGoodfortuneAttributeText;
    public Text playerBloodSuckAttributeText;
    
    public Button leftPageButton;
    public Button rightPageButton;
    public Text pageText;


    public Button sortButton;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        
        detailedAttributesButton.onClick.AddListener(() =>
        {
            mask.SetActive(true);
            playerDamageAttributeText.text=GlobalPlayerAttribute.TotalDamage.ToString();
            playerHPAttributeText.text=GlobalPlayerAttribute.TotalMaxHp.ToString();
            playerDefenseAttributeText.text=GlobalPlayerAttribute.TotalDenfense.ToString();
            playerCRITAttributeText.text=GlobalPlayerAttribute.TotalCRIT.ToString();
            playerCRITDamageAttributeText.text=GlobalPlayerAttribute.TotalCRITDamage.ToString();
            playerMoveSpeedAttributeText.text=GlobalPlayerAttribute.TotalMoveSpeed.ToString();
            playerAttackSpeedAttributeText.text=GlobalPlayerAttribute.TotalAttackSpeed.ToString();
            playerGoodfortuneAttributeText.text=GlobalPlayerAttribute.TotalGoodFortune.ToString();
            playerBloodSuckAttributeText.text=GlobalPlayerAttribute.TotalBloodSuck.ToString();
            
            detailedAttributesPanel.SetActive(true);
        });
        detailedAttributesExitButton.onClick.AddListener(() =>
        {
            mask.SetActive(false);
            detailedAttributesPanel.SetActive(false);
        });
        
        pageText = transform.Find("BagPanel/EquipPanel/PageNumText").GetComponent<Text>();
        leftPageButton.onClick.AddListener(() =>
        {
            BagController.S.PageNum= Mathf.Max(1, BagController.S.PageNum - 1);
            BagController.S.ShowEquip();
            pageText.text = BagController.S.PageNum.ToString();
        });
        rightPageButton.onClick.AddListener(() =>
        {
            BagController.S.PageNum= Mathf.Min(5, BagController.S.PageNum + 1);
            BagController.S.ShowEquip();
            pageText.text = BagController.S.PageNum.ToString();
        });
        sortButton.onClick.AddListener(() =>
        {
            BagController.S.EquipSort();
        });
        playerButton.onClick.AddListener(() =>
        {
            BagController.S.ShowPlayerPanel();
        });
        attributeButton.onClick.AddListener(() =>
        {
            //BagController.S.ComputeTotalAttribute();
            BagController.S.ShowAttributePanel();
            playerDamageAttributeText.text=GlobalPlayerAttribute.TotalDamage.ToString();
            playerHPAttributeText.text=GlobalPlayerAttribute.TotalMaxHp.ToString();
            playerDefenseAttributeText.text=GlobalPlayerAttribute.TotalDenfense.ToString();
            playerCRITAttributeText.text=GlobalPlayerAttribute.TotalCRIT.ToString();
            playerCRITDamageAttributeText.text=GlobalPlayerAttribute.TotalCRITDamage.ToString();
            playerMoveSpeedAttributeText.text=GlobalPlayerAttribute.TotalMoveSpeed.ToString();
            playerAttackSpeedAttributeText.text=GlobalPlayerAttribute.TotalAttackSpeed.ToString();
            playerGoodfortuneAttributeText.text=GlobalPlayerAttribute.TotalGoodFortune.ToString();
            playerBloodSuckAttributeText.text=GlobalPlayerAttribute.TotalBloodSuck.ToString();
        });
    }
    
}
