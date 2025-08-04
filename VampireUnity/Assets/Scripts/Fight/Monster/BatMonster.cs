using System;
using System.Collections;
using Equip;
using UnityEngine;

public class BatMonster : MonsterBase
{
    //[NonSerialized]public bool IsTrigger;
    [NonSerialized]public float attackTime = 3f;
    [NonSerialized]public float currentTime = 0f;

    public BatMonster() : base(MonsterType.Normal, "BatMonster", 1, 100, 0.3f, 10, 5, 10, 10, 0) { }
    void Start()
    {
        AddMonsterEquip();
        AddMonsterSourceStone();
    }
   
    public override void Skill()
    {
        // Implement the skill logic here
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if (IsDead) return;
        currentTime+= Time.deltaTime;
        if(currentTime>= attackTime&&distance<13)
        {
            AttackBegin();
            currentTime = 0f;
        }
        if (!IsDead&&!IsAttack)
        {
            MonsterMove();
            SpriteFlipX(false);
        }
    }

    

    public void AttackBegin()
    {
        transform.Find("MonsterWarning").gameObject.SetActive(true);
        transform.Find("MonsterWarning").GetComponent<Animator>().Play("MonsterWarning");
        IsAttack = true;
        
        // monsterSkeletonAnimation.AnimationState.SetAnimation(0,"attack", false);
         Speed = 0;
        // MonsterMove();
        // Invoke("AttackEnd",1f);
    }

    private IEnumerator RandomDelayDie(int delay)
    {
        // for (int i = 0; i < delay; i++)
        // {
        //     yield return null;
        // }
        // gameObject.SetActive(false);
        // GameController.S.BatMonsterQueue.Enqueue(this);
        AudioController.S.PlayBatDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy,1);
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
        yield return null;
    }

    public override void Die()
    {
        //生成随机数
         int randomDelay = UnityEngine.Random.Range(0, 3);
         StartCoroutine(RandomDelayDie(randomDelay));
         // gameObject.SetActive(false);
         // GameController.S.BatMonsterQueue.Enqueue(this);
         // GeneralDie();
         // GetEx();
         // ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy);
         // CreateBloodEnergy();
         // CreateEquip();
    }

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryRingFight", 10));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryNecklaceFight", 10));
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
            AudioController.S.PlayBatHit();
        }
    }
}
