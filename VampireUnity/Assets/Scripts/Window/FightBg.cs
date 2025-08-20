using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
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

    private void Start()
    {
        //技能按钮点击特效
        SkillController.S.IceArrowUIFX = iceArrowUIFX;
        SkillController.S.IceBallUIFX = iceBallUIFX;
        SkillController.S.IceExUIFX = iceExUIFX;
    }
}
