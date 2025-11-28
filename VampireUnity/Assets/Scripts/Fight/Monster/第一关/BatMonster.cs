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
        size = 0.15f;
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
        if (IsDead) return;
        base.Update();
        
        
        float distance = Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        currentTime+= Time.deltaTime;
        if(currentTime>= attackTime&&distance<2.6f)
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
         int randomDelay = UnityEngine.Random.Range(0, 10);
         GameController.S.StartCoroutine(RandomDelayDie(randomDelay));
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
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Primary, 100));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Primary, 100));
    }

    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,20));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,20));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,20));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,20));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Scale,20));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Duration,20));
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
