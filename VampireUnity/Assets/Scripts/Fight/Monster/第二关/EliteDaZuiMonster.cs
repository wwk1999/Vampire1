using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class EliteDaZuiMonster : MonsterBase
{
    [NonSerialized]public bool IsTriggerRight;
    [NonSerialized]public bool IsTriggerLeft;
    [NonSerialized]public bool Dir;
    [NonSerialized]public float attackTime = 5f;
    [NonSerialized]public float currentTime = 0f;
    public ParticleSystem Fire;
    public EliteDaZuiMonster() : base(MonsterType.Elite, "EliteDaZuiMonster", 1, 1000, 0.3f, 20, 5, 50, 100, 10) { }

    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Scale,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Duration,2));
    }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 10));
    }
    
    public override void Hurt(int damage)
    {
        base.Hurt(damage);
        if (!IsDead)
        {
            AudioController.S.PlaySnotHit();
        }
    }
    
    public override void Skill()
    {
        // Implement the skill logic here
    }
    
    public override void Die()
    {
        
        //生成随机数
        int randomDelay = UnityEngine.Random.Range(0, 10);
        GameController.S.StartCoroutine(RandomDelayDie(randomDelay));
    }
    
    private IEnumerator RandomDelayDie(int delay)
    {
        for (int i = 0; i < delay; i++)
        {
            yield return null;
        }
        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy,1);
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
        
        // gameObject.SetActive(false);
        // GameController.S.SnotMonsterQueue.Enqueue(this);
    }
    
    private void Start()
    {
        size = 0.55f;
        AddMonsterEquip();
        AddMonsterSourceStone();
    }
    
    public void AttackBeginLeft()
    {
        IsAttack = true;
        Dir = false;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0,"skill", true);
        Speed = 0;
        Fire.startRotation = -90 * Mathf.Deg2Rad;//转换为弧度
        Fire.transform.localPosition = new Vector2(-2.7f, 0);
        Invoke("PlayFire",0.5f);
        Invoke("AttackEnd",2f);

    }
    
    public void AttackBeginRight()
    {
        Dir = true;
        IsAttack = true;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0,"skill", true);
        Speed = 0;
        Fire.startRotation = 90* Mathf.Deg2Rad;
        Fire.transform.localPosition = new Vector2(0.7f, 0);
        Invoke("PlayFire",0.5f);
        Invoke("AttackEnd",2f);
    }

    public void AttackEnd()
    {
        Fire.gameObject.SetActive(false);
        IsAttack = false;
        Speed = 0.3f;
    }


    public void PlayFire()
    {
        if (Fire!=null)
        {
            Fire.gameObject.SetActive(true);
            Fire.Play();
        }
    }
    
    void Update()
    {
        if (IsDead) return;
        
        //碰撞检测
        float dis=Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position);
        base.Update();
        currentTime+= Time.deltaTime;
        if(currentTime>= attackTime&&IsTriggerLeft)
        {
            AttackBeginLeft();
            currentTime = 0f;
        }
        if(currentTime>= attackTime&&IsTriggerRight)
        {
            AttackBeginRight();
            currentTime = 0f;
        }
        if (!IsDead&&!IsAttack)
        {
            MonsterMove();
            SpriteFlipX(true);
        }

        if (Fire.gameObject.activeSelf && IsTriggerLeft&&!Dir)
        {
            GameController.S.gamePlayer.PlayerHurt(10);
        }
        if (Fire.gameObject.activeSelf && IsTriggerRight&&Dir)
        {
            GameController.S.gamePlayer.PlayerHurt(10);
        }
    }
}
