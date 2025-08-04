using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class EliteDaZuiMonster : MonsterBase
{
    [NonSerialized]public bool IsTriggerRight;
    [NonSerialized]public bool IsTriggerLeft;
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
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryClothFight", 15));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryRingFight", 15));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryCloakFight", 15));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryShoeFight", 15));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryNecklaceFight", 15));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryHelmetFight", 15));
        
        MonsterEquipList.Add(new MonsterEquip("TreeMan/TreeManClothFight", 10));
        MonsterEquipList.Add(new MonsterEquip("TreeMan/TreeManRingFight", 10));
        MonsterEquipList.Add(new MonsterEquip("TreeMan/TreeManCloakFight", 10));
        MonsterEquipList.Add(new MonsterEquip("TreeMan/TreeManShoeFight", 10));
        MonsterEquipList.Add(new MonsterEquip("TreeMan/TreeManNecklaceFight", 10));
        MonsterEquipList.Add(new MonsterEquip("TreeMan/TreeManHelmetFight", 10));
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
        int randomDelay = UnityEngine.Random.Range(0, 3);
        StartCoroutine(RandomDelayDie(randomDelay));
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
        AddMonsterEquip();
        AddMonsterSourceStone();
    }
    
    public void AttackBeginLeft()
    {
        IsAttack = true;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0,"skill", true);
        Speed = 0;
        Fire.startRotation = -90 * Mathf.Deg2Rad;//转换为弧度
        Fire.transform.localPosition = new Vector2(-2.7f, 0);
        Invoke("PlayFire",0.5f);
        Invoke("AttackEnd",2f);

    }
    
    public void AttackBeginRight()
    {
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
    }
}
