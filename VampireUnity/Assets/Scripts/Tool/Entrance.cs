using System;
using System.Collections.Generic;
using Mysql;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{
    private void Awake()
    { 
        
            Application.targetFrameRate = 30;
            
            LevelInfoConfig.IsOneGame = false;
            
            AudioController.S.BGAudioSource.clip = Resources.Load<AudioClip>("Audio/BG/Level1BG");
            AudioController.S.BGAudioSource.Play();
            
            
            //初始化最大boss能量值
            GameController.S.MaxBossEnergyNum = LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel]*2;//这时小怪数量，精英不算数量，每10只普通怪出一只精英，所以正好是2倍
            GameController.S.MaxBossEnergyNum = 10;

    //实例化
        //FightBGController
        for (int i = 0; i < 10; i++)
        {
            var circleAttack = Instantiate(Resources.Load("Prefabs/Tool/CircleAttack"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            circleAttack.SetActive(false);
            FightBGController.S.CircleAttackQueue.Enqueue(circleAttack.GetComponent<CircleAttack>());
            var fire= Instantiate(Resources.Load("Prefabs/Skill/TreeManFire"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            fire.SetActive(false);
            FightBGController.S.TreeManFireQueue.Enqueue(fire.GetComponent<TreeManFire>());
            var sqrtattack= Instantiate(Resources.Load("Prefabs/Tool/SqrtAttack"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            sqrtattack.SetActive(false);
            FightBGController.S.SqrtAttackQueue.Enqueue(sqrtattack.GetComponent<SqrtAttack>());
            var playerhit= Instantiate(Resources.Load("Prefabs/Player/PlayerHit"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            playerhit.SetActive(false);
            FightBGController.S.PlayerHitQueue.Enqueue(playerhit.GetComponent<PlayerHit>());
            
            var batskillparticle= Instantiate(Resources.Load("Prefabs/Skill/BatSkillParticle").GetComponent<ParticleSystem>(), new Vector3(0, 0, 0), Quaternion.identity);
            batskillparticle.gameObject.SetActive(false);
            FightBGController.S.BatSkillParticleQueue.Enqueue(batskillparticle.GetComponent<ParticleSystem>());
            
        }

        for (int i = 0; i < 100; i++)
        {
            var spiderWeb= Instantiate(Resources.Load("Prefabs/Monster/SpiderWeb"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            spiderWeb.SetActive(false);
            FightBGController.S.SpiderWebQueue.Enqueue(spiderWeb.GetComponent<SpiderWeb>());

            switch ( GlobalPlayerAttribute.CurrentWeaponType)
            {
                case WeaponType.Primary:
                    var primaryEx= Instantiate(Resources.Load("Prefabs/Skill/PrimaryEx"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    primaryEx.SetActive(false);
                    FightBGController.S.PrimaryNormalAttackExQueue.Enqueue(primaryEx);
                    break;
                case WeaponType.Two:
                    var twoNormalAttack= Instantiate(Resources.Load("Prefabs/Skill/2NormalAttackPrefab"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    twoNormalAttack.SetActive(false);
                    GameController.S.TwoNormalAttackQueue.Enqueue(twoNormalAttack);
                    break;
                case WeaponType.Three:
                    var threeNormalAttack= Instantiate(Resources.Load("Prefabs/Skill/3NormalAttack"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    threeNormalAttack.SetActive(false);
                    GameController.S.ThreeNormalAttackQueue.Enqueue(threeNormalAttack);
                    
                    
                    var threeNormalAttackhit= Instantiate(Resources.Load("Prefabs/Skill/3NormalAttackHit"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    threeNormalAttackhit.SetActive(false);
                    GameController.S.ThreeNormalAttackHitQueue.Enqueue(threeNormalAttackhit);
                    break;
                case WeaponType.Four:
                    var fourNormalAttack= Instantiate(Resources.Load("Prefabs/Skill/4NormalAttack"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    fourNormalAttack.SetActive(false);
                    GameController.S.FourNormalAttackQueue.Enqueue(fourNormalAttack);
                    
                    var fourNormalAttackhit= Instantiate(Resources.Load("Prefabs/Skill/4NormalAttackHit"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    fourNormalAttackhit.SetActive(false);
                    GameController.S.FourNormalAttackHitQueue.Enqueue(fourNormalAttackhit);
                    break;
            }
        }
        
        FightBGController.S.DiLie=Instantiate(Resources.Load("Prefabs/Skill/BossGroundFissure"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
        FightBGController.S.DiLie.SetActive(false);
        FightBGController.S.TreeManBoss=Instantiate(Resources.Load("Prefabs/Monster/TreeManBOSS"), new Vector3(0,0,0), Quaternion.identity).GetComponent<TreeManBoss>();
        FightBGController.S.TreeManBoss.gameObject.SetActive(false);
        
        FightBGController.S.CircleAttack = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CircleAttack")).gameObject;
        FightBGController.S.CircleAttack.SetActive(false);

        
        //初始化怪物队列
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3)
        {
            for (int i = 0; i < 100; i++)
            {
                var snotMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/SnotMonster").GetComponent<SnotMonster>(),
                        GameController.S.transform);
                snotMonster.gameObject.SetActive(false);
                GameController.S.SnotMonsterQueue.Enqueue(snotMonster.GetComponent<SnotMonster>());

                var batMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/BatMonster").GetComponent<BatMonster>(),
                        GameController.S.transform);
                batMonster.gameObject.SetActive(false);
                GameController.S.BatMonsterQueue.Enqueue(batMonster.GetComponent<BatMonster>());

                var spiderMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/SpiderMonster").GetComponent<SpiderMonster>(),
                        GameController.S.transform);
                spiderMonster.gameObject.SetActive(false);
                GameController.S.SpiderMonsterQueue.Enqueue(spiderMonster.GetComponent<SpiderMonster>());

                // var batAttackTrigger =
                //     Instantiate(
                //         Resources.Load<GameObject>("Prefabs/Tool/BatAttackTrigger").GetComponent<BatAttackTrigger>(),
                //         GameController.S.transform);
                // batAttackTrigger.gameObject.SetActive(false);
                //GameController.S.BatAttackTriggerQueue.Enqueue(batAttackTrigger.GetComponent<BatAttackTrigger>());

            }
        }
        
        if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5 || LevelInfoConfig.CurrentGameLevel == 6)

        {
            for (int i = 0; i < 100; i++)
            {
                var chongziMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/ChongZiMonster").GetComponent<ChongZiMonster>(),
                        GameController.S.transform);
                chongziMonster.gameObject.SetActive(false);
                GameController.S.ChongZiMonsterQueue.Enqueue(chongziMonster.GetComponent<ChongZiMonster>());

                var xiaohuoMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/XiaoHuoMonster").GetComponent<XiaoHuoMonster>(),
                        GameController.S.transform);
                xiaohuoMonster.gameObject.SetActive(false);
                GameController.S.XiaoHuoMonsterQueue.Enqueue(xiaohuoMonster.GetComponent<XiaoHuoMonster>());

                var dundiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/DunDiMonster").GetComponent<DunDiMonster>(),
                        GameController.S.transform);
                dundiMonster.gameObject.SetActive(false);
                GameController.S.DunDiMonsterQueue.Enqueue(dundiMonster.GetComponent<DunDiMonster>());
                
                // var xiaohuoAttackTrigger =
                //     Instantiate(
                //         Resources.Load<GameObject>("Prefabs/Tool/XiaoHuoAttackTrigger").GetComponent<XiaoHuoAttackTrigger>(),
                //         GameController.S.transform);
                // xiaohuoAttackTrigger.gameObject.SetActive(false);
               // GameController.S.XiaoHuoAttackTriggerQueue.Enqueue(xiaohuoAttackTrigger.GetComponent<XiaoHuoAttackTrigger>());

                // var dundiAttackTrigger =
                //     Instantiate(
                //         Resources.Load<GameObject>("Prefabs/Tool/DunDiAttackTrigger").GetComponent<DunDiAttackTrigger>(),
                //         GameController.S.transform);
                // dundiAttackTrigger.gameObject.SetActive(false);
                // GameController.S.DunDiAttackTriggerQueue.Enqueue(dundiAttackTrigger.GetComponent<DunDiAttackTrigger>());

                var daZuiSkillTriggerLeft =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Tool/DaZuiSkillTriggerLeft").GetComponent<DaZuiSkillTriggerLeft>(),
                        GameController.S.transform);
                daZuiSkillTriggerLeft.gameObject.SetActive(false);
                GameController.S.DaZuiSkillTriggerQueueLeft.Enqueue(daZuiSkillTriggerLeft.GetComponent<DaZuiSkillTriggerLeft>());
                var daZuiSkillTriggerRight =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Tool/DaZuiSkillTriggerRight").GetComponent<DaZuiSkillTriggerRight>(),
                        GameController.S.transform);
                daZuiSkillTriggerRight.gameObject.SetActive(false);
                GameController.S.DaZuiSkillTriggerQueueRight.Enqueue(daZuiSkillTriggerRight.GetComponent<DaZuiSkillTriggerRight>());


            }
        }
        
        
        
        
        
        

        //精英怪队列
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3)
        {
            for (int i = 0; i < 15; i++)
            {
                var eliteBeeMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteBeeMonster").GetComponent<EliteBeeMonster>(),
                        GameController.S.transform);
                eliteBeeMonster.gameObject.SetActive(false);
                GameController.S.EliteBeeMonsterQueue.Enqueue(eliteBeeMonster.GetComponent<EliteBeeMonster>());

                var beeMonsterSkillTrigger =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Tool/BeeSkillTrigger")
                            .GetComponent<BeeMonsterSkillTrigger>(), GameController.S.transform);
                beeMonsterSkillTrigger.gameObject.SetActive(false);
                GameController.S.BeeMonsterSkillTriggerQueue.Enqueue(beeMonsterSkillTrigger
                    .GetComponent<BeeMonsterSkillTrigger>());
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5|| LevelInfoConfig.CurrentGameLevel == 6)
        {
            for (int i = 0; i < 15; i++)
            {
                var elitedazuiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteDaZuiMonster").GetComponent<EliteDaZuiMonster>(),
                        GameController.S.transform);
                elitedazuiMonster.gameObject.SetActive(false);
                GameController.S.EliteDaZuiMonsterQueue.Enqueue(elitedazuiMonster.GetComponent<EliteDaZuiMonster>());
            }
        }
        
        GameController.S.MonsterBirthPoint1 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterBirthPoint1"), GameController.S.transform);
        GameController.S.MonsterBirthPoint2 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterBirthPoint2"), GameController.S.transform);

        GameController.S.PlayerBirthPoint1= Instantiate(Resources.Load<GameObject>("Prefabs/Tool/PlayerBirthPoint").transform.Find("Level1").gameObject, GameController.S.transform);
        GameController.S.PlayerBirthPoint2= Instantiate(Resources.Load<GameObject>("Prefabs/Tool/PlayerBirthPoint").transform.Find("Level2").gameObject, GameController.S.transform);
        GameController.S.fightBG=Instantiate(Resources.Load<GameObject>("Prefabs/Window/FightBG"), GameController.S.transform);
        GameController.S.fightBG.transform.position = new Vector3(0, 0, 0.1f);
        GameController.S.MonsterBirthPoint1.transform.position = new Vector3(0, 0, 0f);
        GameController.S.PlayerBirthPoint1.transform.position = new Vector3(0, 0, 0f);
        GameController.S.PlayerBirthPoint2.transform.position = new Vector3(0, 0, 0f);
        // GameController.S.snotMonster = Resources.Load<GameObject>("Prefabs/Monster/SnotMonster").GetComponent<SnotMonster>();
        // GameController.S.batMonster = Resources.Load<GameObject>("Prefabs/Monster/BatMonster").GetComponent<BatMonster>();
        // GameController.S.spiderMonster = Resources.Load<GameObject>("Prefabs/Monster/SpiderMonster").GetComponent<SpiderMonster>();
        // GameController.S.elitebeeMonster = Resources.Load<GameObject>("Prefabs/Monster/EliteBeeMonster").GetComponent<EliteBeeMonster>();
        GameController.S.monsterHpSliderPrefabs=Resources.Load<GameObject>("Prefabs/Tool/MonsterHPBloodBar");
        
        
        
    //赋值
        FightBGController.S.SaveButton= GameController.S.transform.Find("FightBG(Clone)/Canvas/Save").GetComponent<Button>();
        FightBGController.S.WeaponButton= GameController.S.transform.Find("FightBG(Clone)/Canvas/Weapon").GetComponent<Button>();
        FightBGController.S.joystick=GameController.S.transform.Find("FightBG(Clone)/Canvas/Fixed Joystick").GetComponent<Joystick>();
        FightBGController.S.normalAttackButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/NormalAttack").GetComponent<Button>();
        FightBGController.S.FightStopButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Stop/StopButton").GetComponent<Button>();
        FightBGController.S.dashButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/Dash").GetComponent<Button>();
        FightBGController.S.rageButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/Rage").GetComponent<Button>();
        FightBGController.S.shieldButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/Shield").GetComponent<Button>();
        FightBGController.S.iceArrowButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceArrow").GetComponent<Button>();
        FightBGController.S.iceExButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceEx").GetComponent<Button>();
        FightBGController.S.iceBallButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceBall").GetComponent<Button>();
        FightBGController.S.IceExYellowCd=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceExYellowCd").GetComponent<Image>();
        FightBGController.S.IceBallYellowCd=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceBallYellowCd").GetComponent<Image>();
        FightBGController.S.IceArrowYellowCd=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceArrowYellowCd").GetComponent<Image>();
        FightBGController.S.BossEnergySlider=GameController.S.transform.Find("FightBG(Clone)/Canvas/BossEnergySlider").GetComponent<Slider>();


        
        GameController.S.MonsterBirthPoints1=GameController.S.MonsterBirthPoint1.GetComponentsInChildren<Transform>();
        GameController.S.MonsterBirthPoints2=GameController.S.MonsterBirthPoint2.GetComponentsInChildren<Transform>();

        //根据关卡设置玩家出生点
        switch (LevelInfoConfig.CurrentGameLevel)
        {
            case 1:
            case 2:
            case 3:
                GameController.S.PlayerBirthPoints=GameController.S.PlayerBirthPoint1.GetComponentsInChildren<Transform>();
                break;
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                GameController.S.PlayerBirthPoints=GameController.S.PlayerBirthPoint2.GetComponentsInChildren<Transform>();
                break;
        }
        //GameController.S.PlayerBirthPoints=GameController.S.PlayerBirthPoint1.GetComponentsInChildren<Transform>();

        GameController.S.fightTimeTextPrefab=GameController.S.transform.Find("FightBG(Clone)/Canvas/FightTime").gameObject;
        GameController.S.fightTimeText=GameController.S.fightTimeTextPrefab.transform.Find("Canvas/FightTimeText").GetComponent<Text>();
        
        
        
        GameController.S.CreatePlayer();

        GameController.S.FirstlevelMonsterList.Add(GameController.S.snotMonster);
        GameController.S.FirstlevelMonsterList.Add(GameController.S.batMonster);
        GameController.S.FirstlevelMonsterList.Add(GameController.S.spiderMonster);

        GameController.S.monsterDetetor1 = new List<MonsterBase>();
        GameController.S.monsterDetetor2 = new List<MonsterBase>();
        GameController.S.monsterDetetor3 = new List<MonsterBase>();
        GameController.S.monsterDetetor4 = new List<MonsterBase>();
        
        
        //战斗暂停按钮点击事件
        FightBGController.S.FightStopButton.onClick.AddListener(() =>
        {
            Instantiate(Resources.Load("Prefabs/Window/FightExitPanel"));
            Time.timeScale=0;
        });
        
        
        EquipController.S.GetMaxEquipId();
        
        FightBGController.S.SaveButton.onClick.AddListener(() =>
        {
            EquipController.S.BatchInsertEquipsWithTransaction(BagController.S.EquipIdList);
        });
        FightBGController.S.WeaponButton.onClick.AddListener(() =>
        {
            Time.timeScale = 0;
            Instantiate(Resources.Load("Prefabs/Window/WeaponWindow"));
        });
        //普通攻击按钮
        FightBGController.S.normalAttackButton.onClick.AddListener(() =>
        {
            if (SkillController.S.NormalAttackCoolingtime >SkillController.S.NormalAttacktime)
            {
                SkillController.S.NormalAttackCoolingtime = 0;
                if (GameController.S.gamePlayer.playerState != PlayerState.Attack)
                {
                    Invoke("ShotBulletInvoke",0.3f);
                    GameController.S.gamePlayer.playerSkeleton.AnimationState.SetAnimation(0, "attack", false);
                }
                GameController.S.gamePlayer.isAttack = true;
                GameController.S.gamePlayer.playerState= PlayerState.Attack;
            }
        });
        //冲击技能
        FightBGController.S.dashButton.onClick.AddListener(() =>
        {
            SkillController.S. IsDash = true;
        });
        //怒气技能
        FightBGController.S.rageButton.onClick.AddListener(() =>
        {
            GameController.S.gamePlayer.transform.Find("Rage").gameObject.SetActive(true);
        });
        //护盾技能
        FightBGController.S.shieldButton.onClick.AddListener(() =>
        {
            GameController.S.gamePlayer.transform.Find("Shield").gameObject.SetActive(true);
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
