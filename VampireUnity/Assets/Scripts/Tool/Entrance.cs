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
        
        
        //装备对象池
        for (int i = 0; i < 10; i++)
        {
            GameObject primaryCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryCloakFight"));
            primaryCloakFight.gameObject.SetActive(false);
            GameController.S.PrimaryCloakQueue.Enqueue(primaryCloakFight);
            
            GameObject primaryClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryClothFight"));
            primaryClothFight.gameObject.SetActive(false);
            GameController.S.PrimaryClothQueue.Enqueue(primaryClothFight);
            
            GameObject primaryRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryRingFight"));
            primaryRingFight.gameObject.SetActive(false);
            GameController.S.PrimaryRingQueue.Enqueue(primaryRingFight);
            
            GameObject primaryShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryShoeFight"));
            primaryShoeFight.gameObject.SetActive(false);
            GameController.S.PrimaryShoeQueue.Enqueue(primaryShoeFight);
            
            GameObject primaryNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryNecklaceFight"));
            primaryNecklaceFight.gameObject.SetActive(false);
            GameController.S.PrimaryNecklaceQueue.Enqueue(primaryNecklaceFight);
            
            GameObject primaryHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryHelmetFight"));
            primaryHelmetFight.gameObject.SetActive(false);
            GameController.S.PrimaryHelmetQueue.Enqueue(primaryHelmetFight);
            
            
            
            
            GameObject GreenCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenCloakFight"));
            GreenCloakFight.gameObject.SetActive(false);
            GameController.S.GreenCloakQueue.Enqueue(GreenCloakFight);
            
            GameObject GreenClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenClothFight"));
            GreenClothFight.gameObject.SetActive(false);
            GameController.S.GreenClothQueue.Enqueue(GreenClothFight);
            
            GameObject GreenRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenRingFight"));
            GreenRingFight.gameObject.SetActive(false);
            GameController.S.GreenRingQueue.Enqueue(GreenRingFight);
            
            GameObject GreenShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenShoeFight"));
            GreenShoeFight.gameObject.SetActive(false);
            GameController.S.GreenShoeQueue.Enqueue(GreenShoeFight);
            
            GameObject GreenNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenNecklaceFight"));
            GreenNecklaceFight.gameObject.SetActive(false);
            GameController.S.GreenNecklaceQueue.Enqueue(GreenNecklaceFight);
            
            GameObject GreenHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenHelmetFight"));
            GreenHelmetFight.gameObject.SetActive(false);
            GameController.S.GreenHelmetQueue.Enqueue(GreenHelmetFight);
            
            
            
            
            
            GameObject BlueCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueCloakFight"));
            BlueCloakFight.gameObject.SetActive(false);
            GameController.S.BlueCloakQueue.Enqueue(BlueCloakFight);
            
            GameObject BlueClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueClothFight"));
            BlueClothFight.gameObject.SetActive(false);
            GameController.S.BlueClothQueue.Enqueue(BlueClothFight);
            
            GameObject BlueRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueRingFight"));
            BlueRingFight.gameObject.SetActive(false);
            GameController.S.BlueRingQueue.Enqueue(BlueRingFight);
            
            GameObject BlueShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueShoeFight"));
            BlueShoeFight.gameObject.SetActive(false);
            GameController.S.BlueShoeQueue.Enqueue(BlueShoeFight);
            
            GameObject BlueNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueNecklaceFight"));
            BlueNecklaceFight.gameObject.SetActive(false);
            GameController.S.BlueNecklaceQueue.Enqueue(BlueNecklaceFight);
            
            GameObject BlueHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueHelmetFight"));
            BlueHelmetFight.gameObject.SetActive(false);
            GameController.S.BlueHelmetQueue.Enqueue(BlueHelmetFight);
            
            
            
            
            
            
            GameObject TreeManCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManCloakFight"));
            TreeManCloakFight.gameObject.SetActive(false);
            GameController.S.TreeManCloakQueue.Enqueue(TreeManCloakFight);
            
            GameObject TreeManClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManClothFight"));
            TreeManClothFight.gameObject.SetActive(false);
            GameController.S.TreeManClothQueue.Enqueue(TreeManClothFight);
            
            GameObject TreeManRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManRingFight"));
            TreeManRingFight.gameObject.SetActive(false);
            GameController.S.TreeManRingQueue.Enqueue(TreeManRingFight);
            
            GameObject TreeManShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManShoeFight"));
            TreeManShoeFight.gameObject.SetActive(false);
            GameController.S.TreeManShoeQueue.Enqueue(TreeManShoeFight);
            
            GameObject TreeManNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManNecklaceFight"));
            TreeManNecklaceFight.gameObject.SetActive(false);
            GameController.S.TreeManNecklaceQueue.Enqueue(TreeManNecklaceFight);
            
            GameObject TreeManHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManHelmetFight"));
            TreeManHelmetFight.gameObject.SetActive(false);
            GameController.S.TreeManHelmetQueue.Enqueue(TreeManHelmetFight);
            
            
            
            
            
            GameObject HuoShanCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanCloakFight"));
            HuoShanCloakFight.gameObject.SetActive(false);
            GameController.S.HuoShanCloakQueue.Enqueue(HuoShanCloakFight);
            
            GameObject HuoShanClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanClothFight"));
            HuoShanClothFight.gameObject.SetActive(false);
            GameController.S.HuoShanClothQueue.Enqueue(HuoShanClothFight);
            
            GameObject HuoShanRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanRingFight"));
            HuoShanRingFight.gameObject.SetActive(false);
            GameController.S.HuoShanRingQueue.Enqueue(HuoShanRingFight);
            
            GameObject HuoShanShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanShoeFight"));
            HuoShanShoeFight.gameObject.SetActive(false);
            GameController.S.HuoShanShoeQueue.Enqueue(HuoShanShoeFight);
            
            GameObject HuoShanNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanNecklaceFight"));
            HuoShanNecklaceFight.gameObject.SetActive(false);
            GameController.S.HuoShanNecklaceQueue.Enqueue(HuoShanNecklaceFight);
            
            GameObject HuoShanHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanHelmetFight"));
            HuoShanHelmetFight.gameObject.SetActive(false);
            GameController.S.HuoShanHelmetQueue.Enqueue(HuoShanHelmetFight);
        }
        

        for (int i = 0; i < 200; i++)
        {
            GameObject bloodEnergy = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BloodEnergy"));
            bloodEnergy.gameObject.SetActive(false);
            GameController.S.BloodEnergyQueue.Enqueue(bloodEnergy);
        }
        
        for (int i = 0; i < 1000; i++)
        {
            GameObject monsterHurtText = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterHurtText"));
            monsterHurtText.gameObject.SetActive(false);
            GameController.S.MonsterHurtTextQueue.Enqueue(monsterHurtText);
        }
        
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
            var spiderWeb= Instantiate(Resources.Load("Prefabs/Monster/Level1/SpiderWeb"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
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
        FightBGController.S.TreeManBoss=Instantiate(Resources.Load("Prefabs/Monster/Level1/TreeManBOSS"), new Vector3(0,0,0), Quaternion.identity).GetComponent<TreeManBoss>();
        FightBGController.S.TreeManBoss.gameObject.SetActive(false);
        
        FightBGController.S.CircleAttack = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CircleAttack")).gameObject;
        FightBGController.S.CircleAttack.SetActive(false);

        
        //初始化怪物队列
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3|| LevelInfoConfig.CurrentGameLevel == 4)
        {
            for (int i = 0; i < 100; i++)
            {
                var snotMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level1/SnotMonster").GetComponent<SnotMonster>(),
                        GameController.S.transform);
                snotMonster.gameObject.SetActive(false);
                GameController.S.SnotMonsterQueue.Enqueue(snotMonster.GetComponent<SnotMonster>());

                var batMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level1/BatMonster").GetComponent<BatMonster>(),
                        GameController.S.transform);
                batMonster.gameObject.SetActive(false);
                GameController.S.BatMonsterQueue.Enqueue(batMonster.GetComponent<BatMonster>());

                var spiderMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/SpiderMonster").GetComponent<SpiderMonster>(),
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
        
        if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 5 || LevelInfoConfig.CurrentGameLevel == 6|| LevelInfoConfig.CurrentGameLevel == 8)
        {
            for (int i = 0; i < 100; i++)
            {
                var chongziMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level2/ChongZiMonster").GetComponent<ChongZiMonster>(),
                        GameController.S.transform);
                chongziMonster.gameObject.SetActive(false);
                GameController.S.ChongZiMonsterQueue.Enqueue(chongziMonster.GetComponent<ChongZiMonster>());

                var xiaohuoMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level2/XiaoHuoMonster").GetComponent<XiaoHuoMonster>(),
                        GameController.S.transform);
                xiaohuoMonster.gameObject.SetActive(false);
                GameController.S.XiaoHuoMonsterQueue.Enqueue(xiaohuoMonster.GetComponent<XiaoHuoMonster>());

                var dundiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level2/DunDiMonster").GetComponent<DunDiMonster>(),
                        GameController.S.transform);
                dundiMonster.gameObject.SetActive(false);
                GameController.S.DunDiMonsterQueue.Enqueue(dundiMonster.GetComponent<DunDiMonster>());

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


        if (LevelInfoConfig.CurrentGameLevel == 11 || LevelInfoConfig.CurrentGameLevel == 10 ||
            LevelInfoConfig.CurrentGameLevel == 9|| LevelInfoConfig.CurrentGameLevel == 12)
        {
            for (int i = 0; i < 100; i++)
            {
                var jiachongMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level3/JiaChongMonster").GetComponent<JiaChongMonster>(),
                        GameController.S.transform);
                jiachongMonster.gameObject.SetActive(false);
                GameController.S.JiaChongMonsterQueue.Enqueue(jiachongMonster.GetComponent<JiaChongMonster>());


                var wenziMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level3/WenZiMonster").GetComponent<WenZiMonster>(),
                        GameController.S.transform);
                wenziMonster.gameObject.SetActive(false);
                GameController.S.WenZiMonsterQueue.Enqueue(wenziMonster.GetComponent<WenZiMonster>());

                var qingwaMonster =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Monster/Level3/QingWaMonster").GetComponent<QingWaMonster>(),
                        GameController.S.transform);
                qingwaMonster.gameObject.SetActive(false);
                GameController.S.QingWaMonsterQueue.Enqueue(qingwaMonster.GetComponent<QingWaMonster>());
            }
        }
        

        

        //精英怪队列
        if (LevelInfoConfig.CurrentGameLevel == 3|| LevelInfoConfig.CurrentGameLevel == 4)
        {
            for (int i = 0; i < 15; i++)
            {
                var eliteBeeMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/EliteBeeMonster").GetComponent<EliteBeeMonster>(),
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

        if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 8)
        {
            for (int i = 0; i < 15; i++)
            {
                var elitedazuiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level2/EliteDaZuiMonster").GetComponent<EliteDaZuiMonster>(),
                        GameController.S.transform);
                elitedazuiMonster.gameObject.SetActive(false);
                GameController.S.EliteDaZuiMonsterQueue.Enqueue(elitedazuiMonster.GetComponent<EliteDaZuiMonster>());
            }
        }

        if (LevelInfoConfig.CurrentGameLevel == 11 || LevelInfoConfig.CurrentGameLevel == 12)
        {
            for (int i = 0; i < 15; i++)
            {
                var shirenhuaMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level3/EliteShiRenHuaMonster")
                            .GetComponent<ShiRenHuaMonster>(), GameController.S.transform);
                shirenhuaMonster.gameObject.SetActive(false);
                GameController.S.ShiRenHuaMonsterQueue.Enqueue(shirenhuaMonster
                    .GetComponent<ShiRenHuaMonster>());
            }

        }
        
        
        
        
        

        GameController.S.MonsterBirthPoint1 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterBirthPoint1"), GameController.S.transform);
        GameController.S.MonsterBirthPoint2 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterBirthPoint2"), GameController.S.transform);
        GameController.S.MonsterBirthPoint3 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterBirthPoint3"), GameController.S.transform);


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
        
        
        
    // //赋值
    //     FightBGController.S.SaveButton = GameController.S.fightBG.GetComponent<FightBg>().saveButton;
    //     FightBGController.S.WeaponButton= GameController.S.transform.Find("FightBG(Clone)/Canvas/Weapon").GetComponent<Button>();
    //     FightBGController.S.joystick=GameController.S.transform.Find("FightBG(Clone)/Canvas/Fixed Joystick").GetComponent<Joystick>();
    //     FightBGController.S.normalAttackButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/NormalAttack").GetComponent<Button>();
    //     FightBGController.S.FightStopButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Stop/StopButton").GetComponent<Button>();
    //     FightBGController.S.dashButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/Dash").GetComponent<Button>();
    //     FightBGController.S.rageButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/Rage").GetComponent<Button>();
    //     FightBGController.S.shieldButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/Shield").GetComponent<Button>();
    //     FightBGController.S.iceArrowButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceArrow").GetComponent<Button>();
    //     FightBGController.S.iceExButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceEx").GetComponent<Button>();
    //     FightBGController.S.iceBallButton=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceBall").GetComponent<Button>();
    //     FightBGController.S.IceExYellowCd=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceExYellowCd").GetComponent<Image>();
    //     FightBGController.S.IceBallYellowCd=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceBallYellowCd").GetComponent<Image>();
    //     FightBGController.S.IceArrowYellowCd=GameController.S.transform.Find("FightBG(Clone)/Canvas/Skill/IceArrowYellowCd").GetComponent<Image>();
    //     FightBGController.S.BossEnergySlider=GameController.S.transform.Find("FightBG(Clone)/Canvas/BossEnergySlider").GetComponent<Slider>();


        
        GameController.S.MonsterBirthPoints1=GameController.S.MonsterBirthPoint1.GetComponentsInChildren<Transform>();
        GameController.S.MonsterBirthPoints2=GameController.S.MonsterBirthPoint2.GetComponentsInChildren<Transform>();
        GameController.S.MonsterBirthPoints3=GameController.S.MonsterBirthPoint3.GetComponentsInChildren<Transform>();


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
        
        
        
        GameController.S.CreatePlayer();

        GameController.S.FirstlevelMonsterList.Add(GameController.S.snotMonster);
        GameController.S.FirstlevelMonsterList.Add(GameController.S.batMonster);
        GameController.S.FirstlevelMonsterList.Add(GameController.S.spiderMonster);

        GameController.S.monsterDetetor1 = new HashSet<MonsterBase>();
        GameController.S.monsterDetetor2 = new HashSet<MonsterBase>();
        GameController.S.monsterDetetor3 = new HashSet<MonsterBase>();
        GameController.S.monsterDetetor4 = new HashSet<MonsterBase>();
        
    }
}
