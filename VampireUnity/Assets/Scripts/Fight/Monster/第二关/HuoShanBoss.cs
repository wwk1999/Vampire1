using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class HuoShanBoss : MonsterBase
{
    public HuoShanBoss() : base(MonsterType.Boss, "TreeManBoss", 1, 1000, 0.5f, 10, 5, 10, 10, 0) { }

    private float _distance= 0f;
    [NonSerialized]public float Skill1Time= 8f;
    [NonSerialized]public float Skill1CurrentTime = 0f;
    [NonSerialized]public float Skill2Time = 20f;
    [NonSerialized]public float Skill2CurrentTime = 0f;
    [NonSerialized]public float Skill3Time = 15f;
    [NonSerialized]public float Skill3CurrentTime = 0f;
    [NonSerialized]public State CurrentState = State.Move;
    public HuoShanTrigger huoShanTrigger;
    
    public  void Awake()
    {
        base.Awake();
        size = 1.2f;
        MonsterState= State.Move;
        // 获取 SkeletonAnimation
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;

        ObserverModuleManager.S.RegisterEvent(ConstKeys.HuoShanSkill1Q1L,HuoShanSkill1Q1L);
        ObserverModuleManager.S.RegisterEvent(ConstKeys.HuoShanSkill1Q1R,HuoShanSkill1Q1R);

    }
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        Debug.Log($"触发事件帧！动画名称: {trackEntry.Animation.Name}, 事件名称: {e.Data.Name}, 事件值: {e.String}");

        // 根据事件名称处理逻辑
        if (e.Data.Name == "huoyan")
        {
            if (MonsterState == State.Skill1)
            {
                transform.Find("Skill1").gameObject.SetActive(true);
                transform.Find("Skill1").GetComponent<Animator>().Play("HuoShanSkill1");
            }else if (MonsterState == State.Skill2)
            {
                for (int i = 0; i < 5; i++)
                {
                    var bullet=Instantiate(Resources.Load<GameObject>("Prefabs/MonsterSkill/HuoShanSkill2"));
                    float x = Random.Range(-3f, 3f);
                    bullet.transform.position = new Vector3(GameController.S.gamePlayer.transform.position.x+x, GameController.S.gamePlayer.transform.position.y+5f, 0f);
                }
            }else if (MonsterState == State.Skill3)
            {
                transform.Find("HuoShanSkill3").gameObject.SetActive(true);
            }
        }
    }

    public void HuoShanSkill1Q1L(object[] args)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.Find("Skill1").GetComponent<SpriteRenderer>().flipX = true;
        transform.Find("Skill1").transform.localPosition = new Vector3(-4.11f,-0.48f,0);
        // Vector2 direction = GameController.S.gamePlayer.transform.position - transform.position;
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.Find("Skill1").rotation = Quaternion.Euler(0f,0f,-10f);
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_01", false);
    }
    public void HuoShanSkill1Q1R(object[] args)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.Find("Skill1").GetComponent<SpriteRenderer>().flipX = false;
        transform.Find("Skill1").transform.localPosition = new Vector3(3.71f,-0.29f,0);
        // Vector2 direction = GameController.S.gamePlayer.transform.position - transform.position;
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.Find("Skill1").rotation = Quaternion.Euler(0f,0f,20f);
        
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_01", false);
    }
    
    
    public override void Skill() { }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 10));
        
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.HuoShan, 10));
    }
    
    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,10));
    }
    
    public override void Die()
    {
        GeneralDie();
        GetEx();
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
    }

    void Update()
    {
        if (IsDead) return;
        
        base.Update();
        
        _distance= Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        switch (MonsterState)
        {
            case State.Move:
                if (!IsDead)
                {
                    MonsterMove();
                    SpriteFlipX(true);
                }
                break;
            case State.Skill1:
                // if(!FightBGController.S.HaveCircleAttack&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "skill_01")
                //     Skill1Pre();
                break;
            case State.Skill2:
               // GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                break;
        }
        Skill1CurrentTime+=Time.deltaTime;
        Skill2CurrentTime+= Time.deltaTime;
        Skill3CurrentTime+= Time.deltaTime;
        
        if (Skill1CurrentTime >= Skill1Time &&  _distance < 7&&MonsterState==State.Move)
        {
            MonsterState= State.Skill1;
            Skill1CurrentTime = 0f;
            //判断monsterSkeletonAnimation是否翻转
            if(transform.position.x> GameController.S.gamePlayer.transform.position.x)
                ObserverModuleManager.S.SendEvent(ConstKeys.HuoShanSkill1Q1L);
            else
                ObserverModuleManager.S.SendEvent(ConstKeys.HuoShanSkill1Q1R);
        }

        if (Skill2CurrentTime >= Skill2Time && _distance < 7 && MonsterState == State.Move)
        {
            MonsterState = State.Skill2;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_02", false);
            Skill2CurrentTime = 0f;
        }
        if (Skill3CurrentTime >= Skill3Time && _distance < 6 && MonsterState == State.Move)
        {
            MonsterState = State.Skill3;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_03", false);
            Skill3CurrentTime = 0f;
        }
    }
}
