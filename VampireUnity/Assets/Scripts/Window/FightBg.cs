using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FightBg : MonoBehaviour
{
    public Button saveButton;
    public Button weaponButton;
    public Joystick joystick;
    public Button normalAttackButton;
    public Button fightStopButton;
    public Button dashButton;
    public Button rageButton;
    public Button shieldButton;
    public Button iceArrowButton;
    public Button iceExButton;
    public Button iceBallButton;
    public Image iceExYellowCd;
    public Image iceBallYellowCd;
    public Image iceArrowYellowCd;
    public Slider bossEnergySlider;
    public Text fightTimeText;
    
    public UIParticle iceArrowUIFX;
    public UIParticle iceBallUIFX;
    public UIParticle iceExUIFX;

    public GameObject toastContent;

    private void Start()
    {
        //技能按钮点击特效
        ObserverModuleManager.S.RegisterEvent(ConstKeys.ShowToast, ShowTaost);
        SkillController.S.IceArrowUIFX = iceArrowUIFX;
        SkillController.S.IceBallUIFX = iceBallUIFX;
        SkillController.S.IceExUIFX = iceExUIFX;
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent(ConstKeys.ShowToast, ShowTaost);
    }

    public void ShowTaost(object[] obj)
    {
        var toast = Instantiate(Resources.Load("Prefabs/Tool/ToastInfo"), toastContent.transform);
        EquipTable equipTable = obj[0] as EquipTable;
        toast.GetComponent<ToastInfo>().SetToast(equipTable);
    }
}
