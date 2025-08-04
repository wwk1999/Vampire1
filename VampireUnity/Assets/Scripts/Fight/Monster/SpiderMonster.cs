using System;
using System.Collections;
using Equip;
using UnityEngine;

public class SpiderMonster : MonsterBase
{
    [NonSerialized]public float attackTime = 60f;
    [NonSerialized]public float currentTime = 0f;
    public SpiderWeb spiderWeb;
    
    public SpiderMonster() : base(MonsterType.Normal, "BatMonster", 1, 100, 0.3f, 10, 5, 10, 10, 0) { }
    void Start()
    {
        AddMonsterEquip();
        AddMonsterSourceStone();
    }

    private IEnumerator RandomDelayDie(int delay)
    {
        for (int i = 0; i < delay; i++)
        {
            yield return null;
        }
        AudioController.S.PlaySpiderDie();
        // gameObject.SetActive(false);
        // GameController.S.SpiderMonsterQueue.Enqueue(this);
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy,1);
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
    }

    public override void Die()
    {
        //生成随机数
        int randomDelay = UnityEngine.Random.Range(0, 3);
        StartCoroutine(RandomDelayDie(randomDelay));
        // gameObject.SetActive(false);
        // GameController.S.SpiderMonsterQueue.Enqueue(this);
        // GeneralDie();
        // GetEx();
        // ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy);
        // CreateBloodEnergy();
        // CreateEquip();
    }
    
    
   
    public override void Skill()
    {
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "zhiwnag", false);
        IsSkill= true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime+= Time.deltaTime;
        if(currentTime>= attackTime)
        {
            Skill();
            currentTime = 0f;
        }
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(false);
        }
    }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryShoeFight", 10));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryHelmetFight", 10));
    }
    
    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Scale,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Duration,2));
    }
    
    public override void Hurt(int damage)
    {
        base.Hurt(damage);
        if (!IsDead)
        {
            AudioController.S.PlaySpiderHit();
        } 
    }
}
