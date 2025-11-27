using System;
using System.Collections;
using System.Collections.Generic;
using Mysql;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FightBGController : XSingleton<FightBGController>
{
    public Joystick joystick;//虚拟移动杆
    public Button normalAttackButton;//普通攻击按钮
    public Button FightStopButton;//战斗暂停按钮
    public Button dashButton;
    public Button rageButton;
    public Button shieldButton;
    public Button iceArrowButton;
    public Button iceExButton;
    public Button iceBallButton;
    [NonSerialized] public Image IceExYellowCd;
    [NonSerialized] public Image IceBallYellowCd;
    [NonSerialized] public Image IceArrowYellowCd;
    
    
    [NonSerialized]public Button SaveButton;
    [NonSerialized]public Button WeaponButton;
    [NonSerialized]public GameObject CircleAttack;
    [NonSerialized]public TreeManBoss TreeManBoss;
    [NonSerialized] public GameObject DiLie;
    [NonSerialized]public Queue<TreeManFire> TreeManFireQueue = new Queue<TreeManFire>();
    [NonSerialized]public Queue<CircleAttack> CircleAttackQueue = new Queue<CircleAttack>();
    [NonSerialized]public Queue<SqrtAttack> SqrtAttackQueue = new Queue<SqrtAttack>();
    [NonSerialized]public Queue<SpiderWeb> SpiderWebQueue = new Queue<SpiderWeb>();
    [NonSerialized]public Queue<PlayerHit> PlayerHitQueue = new Queue<PlayerHit>();
    [NonSerialized]public Queue<ParticleSystem> BatSkillParticleQueue = new Queue<ParticleSystem>();
    [NonSerialized] public Queue<GameObject> PrimaryNormalAttackExQueue = new Queue<GameObject>();//初始武器普通攻击爆炸队列





    [NonSerialized] public bool HaveCircleAttack = false;
    [NonSerialized] public Slider BossEnergySlider;
    
    
    /// <summary>
    /// 计算物体在指定时间下的落地点位置
    /// </summary>
    /// <param name="initialPosition">物体的初始位置</param>
    /// <param name="linearVelocity">物体的线性速度 (单位: 世界坐标速度，Vector3)</param>
    /// <param name="time">运动的时间 (秒)</param>
    /// <param name="gravityCoefficient">重力加速度系数 (单位: m/s^2，通常地球环境为9.8f)</param>
    /// <returns>物体的落地点位置 (Vector3)</returns>
    public Vector3 CalculateLandingPosition(Vector3 initialPosition, Vector3 linearVelocity, float time, float gravityCoefficient)
    {
        // 计算水平位置变化 (X、Z轴)
        Vector3 horizontalDisplacement = linearVelocity * time;

        // 计算重力的影响 (Y轴变化)
        float verticalDisplacement = linearVelocity.y * time - 0.5f * gravityCoefficient * time * time;

        // 合并位移计算最终位置
        Vector3 landingPosition = initialPosition + new Vector3(horizontalDisplacement.x, verticalDisplacement, horizontalDisplacement.z);

        return landingPosition;
    }

    
    public void PlayGroundFissure(Vector3 pos)
    {
        DiLie.transform.position = pos;
        DiLie.SetActive(true);
        DiLie.transform.Find("DiLie").GetComponent<ParticleSystem>().Play();
        DiLie.transform.Find("GroundFissure/qitiao").GetComponent<ParticleSystem>().Play();
        DiLie.transform.Find("GroundFissure/baozha").GetComponent<ParticleSystem>().Play();
    }

    public void PlaySuccessAnim()
    {
        var success= Instantiate(Resources.Load<GameObject>("Prefabs/Success/Success"),transform);
        SkeletonGraphic skeletonGraphic= success.transform.Find("Canvas/Content").GetComponent<SkeletonGraphic>();
        skeletonGraphic.AnimationState.SetAnimation(0, "bui_9_1", false);
        StartCoroutine(DelayPlaySuccessAnim(skeletonGraphic));
        if (LevelInfoConfig.CurrentGameLevel + 1 > LevelInfoConfig.MaxGameLevel)
        {
            LevelInfoConfig.MaxGameLevel= LevelInfoConfig.CurrentGameLevel + 1;
            StoreController.S.SaveStoreData();
        }

        StartCoroutine(DelayDisableDiLie(success));
    }
    IEnumerator DelayPlaySuccessAnim(SkeletonGraphic skeletonGraphic)
    {
        yield return new WaitForSeconds(1.67f);
        skeletonGraphic.AnimationState.SetAnimation(0, "bui_9_2", false);
    }
    
    IEnumerator DelayDisableDiLie(GameObject obj)
    {
        yield return new WaitForSeconds(5f);
        Destroy(obj);
    }
    
}