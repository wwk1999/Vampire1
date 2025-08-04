using System;
using System.Collections.Generic;
using System.Diagnostics;
using Mysql;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class GameController : XSingleton<GameController>
{
    private float distanceUpdateTimer = 0f;
    [NonSerialized]public Player gamePlayer;
    [NonSerialized]public GameObject MonsterBirthPoint1;
    [NonSerialized]public GameObject MonsterBirthPoint2;
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


    
    
    //子弹队列
    [NonReorderable]public Queue<GameObject>TwoNormalAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ThreeNormalAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ThreeNormalAttackHitQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FourNormalAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FourNormalAttackHitQueue = new Queue<GameObject>();




   
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
    [NonSerialized]public Transform[] PlayerBirthPoints;
    //怪物探测器，检测最近的怪物
    public List<MonsterBase> monsterDetetor1 = new List<MonsterBase>();
    public List<MonsterBase> monsterDetetor2 = new List<MonsterBase>();
    public List<MonsterBase> monsterDetetor3 = new List<MonsterBase>();
    public List<MonsterBase> monsterDetetor4 = new List<MonsterBase>();

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
    
    public void RegisterEvent()
    {
        ObserverModuleManager.S.RegisterEvent(ConstKeys.BossEnergy,BossEnergy);
        ObserverModuleManager.S.RegisterEvent(ConstKeys.BossWarning, ShowBossWarning);
        ObserverModuleManager.S.RegisterEvent(ConstKeys.ResumePlayerCamera, ResumePlayerCamera);

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
       
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 ||
            LevelInfoConfig.CurrentGameLevel == 3)
        {
            transform.Find("FightBG(Clone)/Level1").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5 ||
            LevelInfoConfig.CurrentGameLevel == 6)
        {
            transform.Find("FightBG(Clone)/Level2").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 8 ||
            LevelInfoConfig.CurrentGameLevel == 9)
        {
            transform.Find("FightBG(Clone)/Level3").gameObject.SetActive(true);
        }
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
            case 1:
            case 2:
            case 3:
                monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints1.Length);
                monsterRandomPoint = MonsterBirthPoints1[monsterRandomIndex];
                break;
            case 4:
            case 5:
            case 6:
                monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints2.Length);
                monsterRandomPoint = MonsterBirthPoints2[monsterRandomIndex];
                break;
        }
        // //从子物体里随机选择一个
        // int monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints1.Length);
        // //获取随机选择的子物体    
        // Transform monsterRandomPoint = MonsterBirthPoints1[monsterRandomIndex];
        
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3)
        {
            EliteBeeMonster eliteBeeMonster = EliteBeeMonsterQueue.Dequeue();
            eliteBeeMonster.gameObject.SetActive(true);
            eliteBeeMonster.CurrentHp = eliteBeeMonster.MaxHp;
            eliteBeeMonster.transform.position = monsterRandomPoint.position;
            TotalMonsterCount++;
            EliteMonsterCount++;
            BeeMonsterSkillTrigger beeMonsterSkillTrigger = BeeMonsterSkillTriggerQueue.Dequeue();
            beeMonsterSkillTrigger.BeeMonster = eliteBeeMonster;
            beeMonsterSkillTrigger.gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel ==5 || LevelInfoConfig.CurrentGameLevel ==6)
        {
            EliteDaZuiMonster eliteDaZuiMonster = EliteDaZuiMonsterQueue.Dequeue();
            eliteDaZuiMonster.gameObject.SetActive(true);
            eliteDaZuiMonster.CurrentHp = eliteDaZuiMonster.MaxHp;
            eliteDaZuiMonster.transform.position = monsterRandomPoint.position;
            TotalMonsterCount++;
            EliteMonsterCount++;
            
            DaZuiSkillTriggerLeft daZuiSkillTriggerLeft = DaZuiSkillTriggerQueueLeft.Dequeue();
            daZuiSkillTriggerLeft.DaZuiMonster = eliteDaZuiMonster;
            daZuiSkillTriggerLeft.gameObject.SetActive(true);
            
            DaZuiSkillTriggerRight daZuiSkillTriggerRight = DaZuiSkillTriggerQueueRight.Dequeue();
            daZuiSkillTriggerRight.DaZuiMonster = eliteDaZuiMonster;
            daZuiSkillTriggerRight.gameObject.SetActive(true);
        }
    }

    //生成怪物
    public void CreateMonster()
    {
        if (GameOver)
            return;
        //Debug.Log("怪物数量："+NormalMonsterCount);
        //从子物体里随机选择一个
        int monsterRandomIndex = UnityEngine.Random.Range(1, MonsterBirthPoints1.Length);

        //获取随机选择的子物体    
        Transform monsterRandomPoint = MonsterBirthPoints1[monsterRandomIndex];
        //生成怪物
        GameObject monster;
        // if(DieNormalMonsterCount%10==0&&EliteMonsterCount<5)
        // {
        //     EliteBeeMonster eliteBeeMonster = EliteBeeMonsterQueue.Dequeue();
        //     eliteBeeMonster.gameObject.SetActive(true);
        //     eliteBeeMonster.transform.position = monsterRandomPoint.position;
        // }
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3)
        {
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
                TotalMonsterCount++;
                NormalMonsterCount++;
            }
            else
            {
                return;
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5 || LevelInfoConfig.CurrentGameLevel == 6)
        {
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
                    // XiaoHuoAttackTrigger xiaohuoAttackTrigger = XiaoHuoAttackTriggerQueue.Dequeue();
                    // xiaohuoAttackTrigger.XiaoHuoMonster = monsterBase as XiaoHuoMonster;
                    // xiaohuoAttackTrigger.gameObject.SetActive(true);
                }
                else
                {
                    monsterBase = DunDiMonsterQueue.Dequeue();
                   // DunDiAttackTrigger dundiAttackTrigger = DunDiAttackTriggerQueue.Dequeue();
                    // dundiAttackTrigger.DundiMonster = monsterBase as DunDiMonster;
                    // dundiAttackTrigger.gameObject.SetActive(true);
                }

                monsterBase.gameObject.SetActive(true);
                monsterBase.transform.position = monsterRandomPoint.position;
                monsterBase.CurrentHp = monsterBase.MaxHp;
                monsterBase.transform.SetParent(MonsterBirthPoints1[monsterRandomIndex]);
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
        // MonsterBase monsterBase = monster.GetComponent<MonsterBase>();
        // monsterBase.CurrentHp=monsterBase.MaxHp;
        // monster.transform.SetParent(MonsterBirthPoints[monsterRandomIndex]);
        // //生成怪物血条
        // GameObject monsterHpBar = Instantiate(monsterHpSliderPrefabs.gameObject, monster.transform);
        // Slider monsterHpSlider = monsterHpBar.transform.Find("Canvas/MonsterHPSlider").GetComponent<Slider>();
        // if (monsterBase.MonsterType == MonsterType.Elite)
        // {
        //     monsterHpBar.transform.localScale= new Vector3(0.02f, 0.02f, 0.02f);
        //     monsterHpBar.transform.position = new Vector3(monsterHpBar.transform.position.x, monsterHpBar.transform.position.y + 0.8f, monsterHpBar.transform.position.z-0.1f);
        // }
        // monsterBase.hpSlider = monsterHpSlider;
        // monsterHpBar.transform.position = new Vector3(monsterHpBar.transform.position.x, monsterHpBar.transform.position.y + 0.2f, monsterHpBar.transform.position.z-0.1f);

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
        // //出现BOSS
        // if (BossEnergy > 10 && HaveBoss==false)
        // {
        //     ObserverModuleManager.S.SendEvent(ConstKeys.CameraMoveToBoss);
        //     // HaveBoss = true;
        //     // CurrentBoss=Instantiate(Resources.Load<MonsterBase>("Prefabs/Monster/VacantEye"), transform);
        //     // CurrentBoss.transform.position = new Vector3(0, 0, 0f);
        //     // GameObject BossHp=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/BOSSHP"), transform);
        //     // Slider BossHPSlider = BossHp.transform.Find("Canvas/Slider").GetComponent<Slider>();
        // }
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
            monsterDetetor1.RemoveAll(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);
            monsterDetetor2.RemoveAll(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);
            monsterDetetor3.RemoveAll(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);
            monsterDetetor4.RemoveAll(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);

            monsterDetetor1 = SortMonsterDistance(monsterDetetor1);
            monsterDetetor2 = SortMonsterDistance(monsterDetetor2);
            monsterDetetor3 = SortMonsterDistance(monsterDetetor3);
            monsterDetetor4 = SortMonsterDistance(monsterDetetor4);

            if (monsterDetetor1.Count > 0)
            {
                nearMonsterPosition = monsterDetetor1[0].transform.position;
            }
            else if (monsterDetetor2.Count > 0)
            {
                nearMonsterPosition = monsterDetetor2[0].transform.position;
            }
            else if (monsterDetetor3.Count > 0)
            {
                nearMonsterPosition = monsterDetetor3[0].transform.position;
            }
            else if (monsterDetetor4.Count > 0)
            {
                nearMonsterPosition = monsterDetetor4[0].transform.position;
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
    

    private List<MonsterBase> SortMonsterDistance(List<MonsterBase> monsters)
    {
        // 移除所有已经被销毁或无效的怪物
        foreach (var monster in monsters)
        {
            if (monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead)
            {
                monsters.Remove(monster);
            }
        }

        //按monsters距离player的距离排序，越小越在前面
        monsters.Sort((a, b) =>
        {
            if (a == null || b == null || a.gameObject == null || b.gameObject == null)
                return 0;
            
            float distanceA = Vector3.Distance(gamePlayer.transform.position, a.transform.position);
            float distanceB = Vector3.Distance(gamePlayer.transform.position, b.transform.position);
            return distanceA.CompareTo(distanceB);
        });
        return monsters;
    }
    
    
}