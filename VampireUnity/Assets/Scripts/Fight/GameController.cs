using System;
using System.Collections.Generic;
using System.Diagnostics;
using Equip;
using Mysql;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class GameController : XSingleton<GameController>
{
    //怪物数量排行榜相关
    [NonSerialized] public int NormalCount = 0;
    [NonSerialized] public int EliteCount = 0;
    [NonSerialized] public int BossCount = 0;
    
    
    
    
    private float distanceUpdateTimer = 0f;
    [NonSerialized]public Player gamePlayer;
    [NonSerialized]public GameObject MonsterBirthPoint1;
    [NonSerialized]public GameObject MonsterBirthPoint2;
    [NonSerialized]public GameObject MonsterBirthPoint3;
    [NonSerialized]public GameObject PlayerBirthPoint1;
    [NonSerialized]public GameObject PlayerBirthPoint2;
    //怪物相关
    public SnotMonster snotMonster;
    public BatMonster batMonster;
    public SpiderMonster spiderMonster;
    public EliteBeeMonster elitebeeMonster;
    //第一关怪
    [NonSerialized] public Queue<SnotMonster> SnotMonsterQueue = new Queue<SnotMonster>();
    [NonSerialized] public Queue<EliteBeeMonster> EliteBeeMonsterQueue = new Queue<EliteBeeMonster>();
    [NonSerialized] public Queue<BatMonster> BatMonsterQueue = new Queue<BatMonster>();
    [NonSerialized] public Queue<SpiderMonster> SpiderMonsterQueue = new Queue<SpiderMonster>();
    //[NonSerialized]public Queue<BatAttackTrigger> BatAttackTriggerQueue = new Queue<BatAttackTrigger>();
    [NonSerialized]public Queue<BeeMonsterSkillTrigger> BeeMonsterSkillTriggerQueue = new Queue<BeeMonsterSkillTrigger>();
    
    //第二关怪
    [NonSerialized] public Queue<ChongZiMonster> ChongZiMonsterQueue = new Queue<ChongZiMonster>();
    [NonSerialized] public Queue<DunDiMonster> DunDiMonsterQueue = new Queue<DunDiMonster>();
    [NonSerialized] public Queue<XiaoHuoMonster> XiaoHuoMonsterQueue = new Queue<XiaoHuoMonster>();
    [NonSerialized] public Queue<EliteDaZuiMonster> EliteDaZuiMonsterQueue = new Queue<EliteDaZuiMonster>();
   //[NonSerialized]public Queue<XiaoHuoAttackTrigger> XiaoHuoAttackTriggerQueue = new Queue<XiaoHuoAttackTrigger>();
   //[NonSerialized]public Queue<DunDiAttackTrigger> DunDiAttackTriggerQueue = new Queue<DunDiAttackTrigger>();
    [NonSerialized]public Queue<DaZuiSkillTriggerLeft> DaZuiSkillTriggerQueueLeft = new Queue<DaZuiSkillTriggerLeft>();
    [NonSerialized]public Queue<DaZuiSkillTriggerRight> DaZuiSkillTriggerQueueRight = new Queue<DaZuiSkillTriggerRight>();
    
    
    //第三关怪
    [NonSerialized] public Queue<JiaChongMonster> JiaChongMonsterQueue = new Queue<JiaChongMonster>();
    [NonSerialized] public Queue<WenZiMonster> WenZiMonsterQueue = new Queue<WenZiMonster>();
    [NonSerialized] public Queue<QingWaMonster> QingWaMonsterQueue = new Queue<QingWaMonster>();
    [NonSerialized] public Queue<ShiRenHuaMonster> ShiRenHuaMonsterQueue = new Queue<ShiRenHuaMonster>();


    
    
    //子弹队列
    [NonReorderable]public Queue<GameObject>TwoNormalAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ThreeNormalAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ThreeNormalAttackHitQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FourNormalAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FourNormalAttackHitQueue = new Queue<GameObject>();


    //血能对象池队列
    [NonReorderable]public Queue<GameObject>BloodEnergyQueue = new Queue<GameObject>();
    //怪物伤害文本对象池队列
    [NonReorderable]public Queue<GameObject>MonsterHurtTextQueue = new Queue<GameObject>();

    //装备对象池
    [NonReorderable]public Queue<GameObject>PrimaryCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>GreenCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>BlueCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>TreeManCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>HuoShanCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanShoeQueue = new Queue<GameObject>();



   
    //怪物数量
    [NonSerialized]public int NormalMonsterCount=0;
    [NonSerialized]public int EliteMonsterCount=0;
    [NonSerialized]public int TotalMonsterCount=0;
    [NonSerialized]public int DieNormalMonsterCount=0;
    [NonSerialized]public int DieEliteMonsterCount=0;

    
    
    [NonSerialized] public List<MonsterBase> FirstlevelMonsterList= new List<MonsterBase>();
    
    
    public float monsterBirthTimeScale = 1f; //间隔一秒钟生成一个怪物
    public float currentTime = 0f;
    public GameObject fightBG;
    [NonSerialized]public Transform[] MonsterBirthPoints1;
    [NonSerialized]public Transform[] MonsterBirthPoints2;
    [NonSerialized]public Transform[] MonsterBirthPoints3;
    [NonSerialized]public Transform[] PlayerBirthPoints;
    //怪物探测器，检测最近的怪物
    public HashSet<MonsterBase> monsterDetetor1 = new HashSet<MonsterBase>();
    public HashSet<MonsterBase> monsterDetetor2 = new HashSet<MonsterBase>();
    public HashSet<MonsterBase> monsterDetetor3 = new HashSet<MonsterBase>();
    public HashSet<MonsterBase> monsterDetetor4 = new HashSet<MonsterBase>();

    //最近怪物位置
    public Vector3 nearMonsterPosition;
    //怪物血条
    public GameObject monsterHpSliderPrefabs;
    //战斗时间文本
    public float fightTime;//秒为单位
    public GameObject fightTimeTextPrefab;
    public Text fightTimeText;
    //Boss相关
    [NonSerialized]public int BossEnergyNum=0;
    [NonSerialized]public int MaxBossEnergyNum;//Boss能量
    [NonSerialized]public bool HaveBoss=false;
    [NonSerialized]public bool HaveBossWarning=false;
    [NonSerialized]public MonsterBase CurrentBoss;
    [NonSerialized]public bool GameOver=false;
    
    //武器源石列表
    [NonSerialized]public List<SourceStoneTable> WeaponSourceStoneList = new List<SourceStoneTable>();
    
    //杀死怪物数量
    [NonSerialized]public int KillMonsterCount=0;

    
    public void RegisterEvent()
    {
        ObserverModuleManager.S.RegisterEvent(ConstKeys.BossEnergy,BossEnergy);
        ObserverModuleManager.S.RegisterEvent(ConstKeys.BossWarning, ShowBossWarning);
        ObserverModuleManager.S.RegisterEvent(ConstKeys.ResumePlayerCamera, ResumePlayerCamera);
    }
    
    
    public GameObject GetEquip(MonsterEquip monsterEquip)
    {
        GameObject equip = null;
        switch (monsterEquip.EquipLevel)
        {
            case PlayerEquipConfig.EquipLevel.Primary:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return PrimaryCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return PrimaryClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return PrimaryRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return PrimaryShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return PrimaryHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return PrimaryNecklaceQueue.Dequeue();
                }
                break;
            case PlayerEquipConfig.EquipLevel.Green:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return GreenCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return GreenClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return GreenRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return GreenShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return GreenHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return GreenNecklaceQueue.Dequeue();
                }
                break;
            case PlayerEquipConfig.EquipLevel.Blue:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return BlueCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return BlueClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return BlueRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return BlueShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return BlueHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return BlueNecklaceQueue.Dequeue();
                }
                break;
            case PlayerEquipConfig.EquipLevel.TreeMan:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return TreeManCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return TreeManClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return TreeManRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return TreeManShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return TreeManHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return TreeManNecklaceQueue.Dequeue();
                }
                break;
           case PlayerEquipConfig.EquipLevel.HuoShan:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return HuoShanCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return HuoShanClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return HuoShanRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return HuoShanShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return HuoShanHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return HuoShanNecklaceQueue.Dequeue();
                }
               break;
        }

        return equip;
    }
    
    private void Awake()
    {
        RegisterEvent();
        GameOver = false;
        var _ = SkillController.S;//激活SkillController
        
        
        //DontDestroyOnLoad(gameObject);
        
        
        //实例化UI
        // Instantiate(Resources.Load<GameObject>("Prefabs/UI/RoleInfoFight"), transform);
        
        
    }

    private void Start()
    {
        KillMonsterCount = 0;
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 ||
            LevelInfoConfig.CurrentGameLevel == 3|| LevelInfoConfig.CurrentGameLevel == 4)
        {
            transform.Find("FightBG(Clone)/Level1").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 5 ||
            LevelInfoConfig.CurrentGameLevel == 6|| LevelInfoConfig.CurrentGameLevel == 8)
        {
            transform.Find("FightBG(Clone)/Level2").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 10 || LevelInfoConfig.CurrentGameLevel == 11 ||
            LevelInfoConfig.CurrentGameLevel == 9|| LevelInfoConfig.CurrentGameLevel == 12)
        {
            transform.Find("FightBG(Clone)/Level3").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 13 || LevelInfoConfig.CurrentGameLevel == 14 ||
            LevelInfoConfig.CurrentGameLevel == 15|| LevelInfoConfig.CurrentGameLevel == 16)
        {
            transform.Find("FightBG(Clone)/Level4").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 17 || LevelInfoConfig.CurrentGameLevel == 18 ||
            LevelInfoConfig.CurrentGameLevel == 19|| LevelInfoConfig.CurrentGameLevel == 20)
        {
            transform.Find("FightBG(Clone)/Level5").gameObject.SetActive(true);
        }
        
        
        //赋值
        FightBGController.S.SaveButton = fightBG.GetComponent<FightBg>().saveButton;
        FightBGController.S.WeaponButton= fightBG.GetComponent<FightBg>().weaponButton;
        FightBGController.S.joystick=fightBG.GetComponent<FightBg>().joystick;
        FightBGController.S.normalAttackButton=fightBG.GetComponent<FightBg>().normalAttackButton;
        FightBGController.S.FightStopButton=fightBG.GetComponent<FightBg>().fightStopButton;
        FightBGController.S.dashButton=fightBG.GetComponent<FightBg>().dashButton;
        FightBGController.S.rageButton=fightBG.GetComponent<FightBg>().rageButton;
        FightBGController.S.shieldButton=fightBG.GetComponent<FightBg>().shieldButton;
        FightBGController.S.iceArrowButton=fightBG.GetComponent<FightBg>().iceArrowButton;
        FightBGController.S.iceExButton=fightBG.GetComponent<FightBg>().iceExButton;
        FightBGController.S.iceBallButton=fightBG.GetComponent<FightBg>().iceBallButton;
        FightBGController.S.IceExYellowCd=fightBG.GetComponent<FightBg>().iceExYellowCd;
        FightBGController.S.IceBallYellowCd=fightBG.GetComponent<FightBg>().iceBallYellowCd;
        FightBGController.S.IceArrowYellowCd=fightBG.GetComponent<FightBg>().iceArrowYellowCd;
        FightBGController.S.BossEnergySlider=fightBG.GetComponent<FightBg>().bossEnergySlider;
        fightTimeText = fightBG.GetComponent<FightBg>().fightTimeText;

        
        //战斗暂停按钮点击事件
        FightBGController.S.FightStopButton.onClick.AddListener(() =>
        {
            Instantiate(Resources.Load("Prefabs/Window/FightExitPanel"));
            Time.timeScale=0;
        });
        
         // EquipController.S.GetMaxEquipId();
         
        FightBGController.S.WeaponButton.onClick.AddListener(() =>
        {
            Time.timeScale = 0;
            Instantiate(Resources.Load("Prefabs/Window/WeaponWindow"));
        });
        //普通攻击按钮
        FightBGController.S.normalAttackButton.onClick.AddListener(() =>
        {
                if (gamePlayer.playerState != PlayerState.Attack)
                {
                    gamePlayer.playerSkeleton.AnimationState.SetAnimation(0, "attack", false);
                }
                gamePlayer.isAttack = true;
                gamePlayer.playerState= PlayerState.Attack;
        });
        //冲击技能
        FightBGController.S.dashButton.onClick.AddListener(() =>
        {
            SkillController.S. IsDash = true;
        });
        //怒气技能
        FightBGController.S.rageButton.onClick.AddListener(() =>
        {
            gamePlayer.transform.Find("Rage").gameObject.SetActive(true);
        });
        //护盾技能
        FightBGController.S.shieldButton.onClick.AddListener(() =>
        {
            gamePlayer.transform.Find("Shield").gameObject.SetActive(true);
        });
        //按钮冰箭技能
        FightBGController.S.iceArrowButton.onClick.AddListener(() =>
        {
            if (SkillController.S.IceArrowCoolingtime > SkillController.S.IceArrowtime)
            {
                AudioController.S.PlayIceArrow();
                SkillController.S.IceArrowUIFX.Play();
                SkillController.S.IceArrowCoolingtime = 0;
                SkillController.S.IceArrow.Play();
                SkillController.S.IceArrow.transform.Find("Trail").gameObject.SetActive(true);
            }
        });
        //按钮冰爆技能
        FightBGController.S.iceExButton.onClick.AddListener(() =>
        {
            if (SkillController.S.IceExplosionCoolingtime > SkillController.S.IceExplosiontime)
            {
                SkillController.S.IceExUIFX.Play();
                AudioController.S.PlayIceEx();
                SkillController.S.IceExplosionCoolingtime=0;
                SkillController.S.IceExplosion1.Play();
                SkillController.S.IceExplosion2.Play();
                SkillController.S.IceExplosion3.Play();
                SkillController.S.IceExTrigger.gameObject.SetActive(true);
            }
        });
        //按钮冰球
        FightBGController.S.iceBallButton.onClick.AddListener(() =>
        {
            if (SkillController.S.IceBallCoolingtime > SkillController.S.IceBalltime)
            {
                AudioController.S.PlayIceBall();
                SkillController.S.IceBallUIFX.Play();
                SkillController.S.IceBallCoolingtime=0;
                SkillController.S.StartIceBallSkill(3,3,3);
            }
        });
    }

    public void BossEnergy(object[] args)
    {
        switch (args[0])
        {
            case 1:
                BossEnergyNum += 1;
                break;
            case 2:
                BossEnergyNum += 10;
                break;
        }

        FightBGController.S.BossEnergySlider.maxValue = MaxBossEnergyNum;
        FightBGController.S.BossEnergySlider.value = BossEnergyNum;
        Debug.Log("最大能量值："+MaxBossEnergyNum);
        Debug.Log("当前能量值："+BossEnergyNum);
        //召唤BOSS
        if (BossEnergyNum > 1 && HaveBossWarning == false&&LevelInfoConfig.CurrentGameLevelType==LevelType.Boss)
        {
            //GameController.S.HaveBoss = true;
            ObserverModuleManager.S.SendEvent(ConstKeys.BossWarning);
        }
    }

    public void ResumePlayerCamera(object[] args)
    {
        ResumePlayer();
        ResumeAllMonster();
    }

    //冻结怪物
    public void FreezeAllMonster()
    {
        MonsterBase[] monsters = FindObjectsByType<MonsterBase>(FindObjectsSortMode.None);
        foreach (var monster in monsters)
        {
            if (monster != null && !monster.IsDead)
            {
                monster.Speed=0f; //将怪物速度设置为0，冻结怪物
                //暂停骨骼动画
                monster.monsterSkeletonAnimation.timeScale = 0f; //暂停骨骼动画
            }
        }
    }

    //冻结人物
    public void FreezePlayer()
    {
        GlobalPlayerAttribute.PlayerMoveSpeed = 0;
        gamePlayer.playerSkeleton.timeScale = 0f;
    }
    
    //恢复怪物速度
    public void ResumeAllMonster()
    {
        MonsterBase[] monsters = FindObjectsByType<MonsterBase>(FindObjectsSortMode.None);
        foreach (var monster in monsters)
        {
            if (monster != null && !monster.IsDead)
            {
                monster.Speed=0.3f; //将怪物速度设置为0，冻结怪物
                //暂停骨骼动画
                monster.monsterSkeletonAnimation.timeScale = 1f; //暂停骨骼动画
            }
        }
    }

    //恢复人物速度
    public void  ResumePlayer()
    {
        GlobalPlayerAttribute.PlayerMoveSpeed = 3;
        gamePlayer.playerSkeleton.timeScale = 1f;
    }


    public void CreatePlayer()
    {
        int playerRandomIndex = UnityEngine.Random.Range(1, PlayerBirthPoints.Length);
        //获取随机选择的子物体    
        Transform playerRandomPoint = PlayerBirthPoints[playerRandomIndex];
        gamePlayer = Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"), transform).GetComponent<Player>();
        gamePlayer.transform.position = playerRandomPoint.position;
    }

    public void CreateEliteMonster()
    {
        if (GameOver)
            return;
        int monsterRandomIndex=0;
        Transform monsterRandomPoint= null;
        switch (LevelInfoConfig.CurrentGameLevel)
        {
            case 3:
            case 4:
                monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints1.Length);
                monsterRandomPoint = MonsterBirthPoints1[monsterRandomIndex];
                break;
            case 7:
            case 8:
                monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints2.Length);
                monsterRandomPoint = MonsterBirthPoints2[monsterRandomIndex];
                break;
            case 11:
            case 12:
                monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints3.Length);
                monsterRandomPoint = MonsterBirthPoints3[monsterRandomIndex];
                break;
        }
        // //从子物体里随机选择一个
        // int monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints1.Length);
        // //获取随机选择的子物体    
        // Transform monsterRandomPoint = MonsterBirthPoints1[monsterRandomIndex];
        
        if ( LevelInfoConfig.CurrentGameLevel == 3|| LevelInfoConfig.CurrentGameLevel ==4)
        {
            EliteBeeMonster eliteBeeMonster = EliteBeeMonsterQueue.Dequeue();
            eliteBeeMonster.gameObject.SetActive(true);
            eliteBeeMonster.CurrentHp = eliteBeeMonster.MaxHp;
            eliteBeeMonster.transform.position = monsterRandomPoint.position;
            eliteBeeMonster.monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);

            TotalMonsterCount++;
            EliteMonsterCount++;
            BeeMonsterSkillTrigger beeMonsterSkillTrigger = BeeMonsterSkillTriggerQueue.Dequeue();
            beeMonsterSkillTrigger.BeeMonster = eliteBeeMonster;
            beeMonsterSkillTrigger.gameObject.SetActive(true);
        }
        if ( LevelInfoConfig.CurrentGameLevel ==7 || LevelInfoConfig.CurrentGameLevel ==8)
        {
            EliteDaZuiMonster eliteDaZuiMonster = EliteDaZuiMonsterQueue.Dequeue();
            eliteDaZuiMonster.gameObject.SetActive(true);
            eliteDaZuiMonster.CurrentHp = eliteDaZuiMonster.MaxHp;
            eliteDaZuiMonster.transform.position = monsterRandomPoint.position;
            eliteDaZuiMonster.monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);

            TotalMonsterCount++;
            EliteMonsterCount++;
            
            DaZuiSkillTriggerLeft daZuiSkillTriggerLeft = DaZuiSkillTriggerQueueLeft.Dequeue();
            daZuiSkillTriggerLeft.DaZuiMonster = eliteDaZuiMonster;
            daZuiSkillTriggerLeft.gameObject.SetActive(true);
            
            DaZuiSkillTriggerRight daZuiSkillTriggerRight = DaZuiSkillTriggerQueueRight.Dequeue();
            daZuiSkillTriggerRight.DaZuiMonster = eliteDaZuiMonster;
            daZuiSkillTriggerRight.gameObject.SetActive(true);
        }

        if (LevelInfoConfig.CurrentGameLevel == 11 || LevelInfoConfig.CurrentGameLevel == 12 )
        {
            ShiRenHuaMonster shirenhuaMonster = ShiRenHuaMonsterQueue.Dequeue();
            shirenhuaMonster.gameObject.SetActive(true);
            shirenhuaMonster.CurrentHp = shirenhuaMonster.MaxHp;
            shirenhuaMonster.transform.position = monsterRandomPoint.position;
            shirenhuaMonster.monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);

            TotalMonsterCount++;
            EliteMonsterCount++;
        }
    }

    //生成怪物
    public void CreateMonster()
    {
        if (GameOver)
            return;
        //Debug.Log("怪物数量："+NormalMonsterCount);
        //从子物体里随机选择一个

        //获取随机选择的子物体    
        //生成怪物
        GameObject monster;
        // if(DieNormalMonsterCount%10==0&&EliteMonsterCount<5)
        // {
        //     EliteBeeMonster eliteBeeMonster = EliteBeeMonsterQueue.Dequeue();
        //     eliteBeeMonster.gameObject.SetActive(true);
        //     eliteBeeMonster.transform.position = monsterRandomPoint.position;
        // }
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3|| LevelInfoConfig.CurrentGameLevel == 4)
        {
            int monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints1.Length);
            Transform monsterRandomPoint = MonsterBirthPoints1[monsterRandomIndex];
            if (NormalMonsterCount < LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
            {
                MonsterBase monsterBase;
                if (NormalMonsterCount % 3 == 0)
                {
                    monsterBase = SnotMonsterQueue.Dequeue();
                }
                else if (NormalMonsterCount % 3 == 1)
                {
                    monsterBase = BatMonsterQueue.Dequeue();
                    // BatAttackTrigger batAttackTrigger = BatAttackTriggerQueue.Dequeue();
                    // batAttackTrigger.BatMonster = monsterBase as BatMonster;
                    // batAttackTrigger.gameObject.SetActive(true);
                }
                else
                {
                    monsterBase = SpiderMonsterQueue.Dequeue();
                }

                monsterBase.gameObject.SetActive(true);
                monsterBase.transform.position = monsterRandomPoint.position;
                monsterBase.CurrentHp = monsterBase.MaxHp;
                monsterBase.transform.SetParent(MonsterBirthPoints1[monsterRandomIndex]);
                monsterBase.monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);

                TotalMonsterCount++;
                NormalMonsterCount++;
            }
            else
            {
                return;
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 5 || LevelInfoConfig.CurrentGameLevel == 6|| LevelInfoConfig.CurrentGameLevel == 8)
        {
            int monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints2.Length);
            Transform monsterRandomPoint = MonsterBirthPoints2[monsterRandomIndex];
            if (NormalMonsterCount < LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
            {
                MonsterBase monsterBase;
                if (NormalMonsterCount % 3 == 0)
                {
                    monsterBase = ChongZiMonsterQueue.Dequeue();
                }
                else if (NormalMonsterCount % 3 == 1)
                {
                    monsterBase = XiaoHuoMonsterQueue.Dequeue();
                }
                else
                {
                    monsterBase = DunDiMonsterQueue.Dequeue();
                }

                monsterBase.gameObject.SetActive(true);
                monsterBase.transform.position = monsterRandomPoint.position;
                monsterBase.CurrentHp = monsterBase.MaxHp;
                monsterBase.transform.SetParent(MonsterBirthPoints2[monsterRandomIndex]);
                monsterBase.monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
                TotalMonsterCount++;
                NormalMonsterCount++;
            }
            else
            {
                return;
            }
        }
        
        
        if (LevelInfoConfig.CurrentGameLevel == 11 || LevelInfoConfig.CurrentGameLevel == 10 || LevelInfoConfig.CurrentGameLevel == 9|| LevelInfoConfig.CurrentGameLevel == 12)
        {
            int monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints3.Length);
            Transform monsterRandomPoint = MonsterBirthPoints3[monsterRandomIndex];
            if (NormalMonsterCount < LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
            {
                MonsterBase monsterBase;
                if (NormalMonsterCount % 3 == 0)
                {
                    monsterBase = WenZiMonsterQueue.Dequeue();
                }
                else if (NormalMonsterCount % 3 == 1)
                {
                    monsterBase = QingWaMonsterQueue.Dequeue();
                }
                else
                {
                    monsterBase = JiaChongMonsterQueue.Dequeue();
                }

                monsterBase.gameObject.SetActive(true);
                monsterBase.transform.position = monsterRandomPoint.position;
                monsterBase.CurrentHp = monsterBase.MaxHp;
                monsterBase.transform.SetParent(MonsterBirthPoints3[monsterRandomIndex]);
                monsterBase.monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
                TotalMonsterCount++;
                NormalMonsterCount++;
            }
            else
            {
                return;
            }
        }


        if(NormalMonsterCount%10==0&& NormalMonsterCount!=0)
         {
             Debug.Log("生成精英怪:"+NormalMonsterCount);
           CreateEliteMonster();
         }
    }
    
    public void ShowBossWarning(object[] args)
    {
        HaveBossWarning = true;
        Instantiate(Resources.Load("Prefabs/Tool/Warning"));
        FreezePlayer();
        FreezeAllMonster();
    }

    private void Update()
    {
        if (GlobalPlayerAttribute.IsGame == false)
            return;
        //更新战斗时间,以秒为单位
        fightTime += Time.deltaTime;
        var minute=(int)fightTime/60;
        var second=(int)fightTime%60;
        fightTimeText.text = "战斗时间：" + minute.ToString("F0") + " 分 " + second.ToString("F0") + " 秒";
        
        //生成怪物
        currentTime += Time.deltaTime;
        distanceUpdateTimer+=Time.deltaTime;
        if (currentTime >= monsterBirthTimeScale)
        {
            CreateMonster();
            currentTime = 0f;
        }
        //获得距离最近的怪物位置
        // 在排序之前清理无效的怪物引用
        // 在排序之前清理无效的怪物引用
// 1. 在Update中添加对IsDead的检查
        if (distanceUpdateTimer > 0.2f)
        {
            distanceUpdateTimer = 0;
            // 清理无效的怪物引用
            monsterDetetor1.RemoveWhere(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);
            monsterDetetor2.RemoveWhere(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);
            monsterDetetor3.RemoveWhere(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);
            monsterDetetor4.RemoveWhere(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);

            // 直接找到最近的怪物，不需要排序
            MonsterBase nearestMonster = FindNearestMonster(monsterDetetor1);
            if (nearestMonster == null)
                nearestMonster = FindNearestMonster(monsterDetetor2);
            if (nearestMonster == null)
                nearestMonster = FindNearestMonster(monsterDetetor3);
            if (nearestMonster == null)
                nearestMonster = FindNearestMonster(monsterDetetor4);

            if (nearestMonster != null)
            {
                nearMonsterPosition = nearestMonster.transform.position;
            }
            else
            {
                //朝向player的右边
                if (gamePlayer.playerSkeleton.Skeleton.FlipX)
                    nearMonsterPosition = gamePlayer.transform.position + new Vector3(-10, 0, 0);
                else
                    nearMonsterPosition = gamePlayer.transform.position + new Vector3(10, 0, 0);
            }
        }

    }
    

    private MonsterBase FindNearestMonster(HashSet<MonsterBase> monsters)
    {
        MonsterBase nearestMonster = null;
        float nearestDistance = float.MaxValue;

        foreach (var monster in monsters)
        {
            // 跳过无效的怪物
            if (monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead)
                continue;

            float distance = Vector3.Distance(gamePlayer.transform.position, monster.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestMonster = monster;
            }
        }

        return nearestMonster;
    }
    
    public void ShotBulletInvoke()
    {
        int penetrate=0;
        int division=0;
        int extremeSpeed=0;
        int explosion=0;
        foreach (var sourceStoneTable in WeaponSourceConfig.WeaponSourceStoneList)
        {
            if(sourceStoneTable.SourceStoneType== (int)WeaponSourceStoneType.Penetrate)
            {
                penetrate++;
            }
            if(sourceStoneTable.SourceStoneType== (int)WeaponSourceStoneType.Division)
            {
                division++;
            }
            if(sourceStoneTable.SourceStoneType== (int)WeaponSourceStoneType.ExtremeSpeed)
            {
                extremeSpeed++;
            }
            if(sourceStoneTable.SourceStoneType== (int)WeaponSourceStoneType.Explosion)
            {
                explosion++;
            }
        }

        switch (GlobalPlayerAttribute.CurrentWeaponType)
        {
            case WeaponType.Primary:
                GameController.S.gamePlayer.currentGun.PrimaryShot(penetrate,division,extremeSpeed,explosion);
                AudioController.S.PlayNormalAttack1();
                break;
            case WeaponType.Two:
                AudioController.S.PlayNormalAttack2();
                GameController.S.gamePlayer.currentGun.TwoShot(penetrate,division,extremeSpeed,explosion);
                break;
        }
        //GameController.S.gamePlayer.currentGun.TwoShot(penetrate,division,extremeSpeed,explosion);
        SkillController.S.NormalAttackCoolingtime+=Time.deltaTime;
    }
    
    
}