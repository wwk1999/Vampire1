using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class DunDiMonster : MonsterBase
{
    [NonSerialized]public float attackTime = 6f;
    [NonSerialized]public float currentTime = 0f;
    private Vector2 _targetpos;
    public DunDiMonster() : base(MonsterType.Normal, "DunDiMonster", 1, 100, 0.3f, 10, 5, 10, 10, 0)
    {
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
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryRingFight", 10));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryNecklaceFight", 10));
        
        MonsterEquipList.Add(new MonsterEquip("Green/GreenRingFight", 5));
        MonsterEquipList.Add(new MonsterEquip("Green/GreenNecklaceFight", 5));
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


    public void AttackBegin()
    {
        if (IsAttack) return;
        Debug.Log(33333333);
        _targetpos= GameController.S.gamePlayer.transform.position;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0,"skill", false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        IsAttack = true;
        StartCoroutine(AttackEnd());
    }
    
    
    //  协程等待3s
    private IEnumerator AttackEnd()
    {
        yield return new WaitForSeconds(2f);
        //gameObject.SetActive(true);
        transform.localScale=new Vector3(1,1,1);
        monsterSkeletonAnimation.AnimationState.SetAnimation(0,"chuxian", false);
        transform.position = _targetpos;
    }
    
    
    void Update()
    {
        float dis = Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if (IsDead) return;
        currentTime+= Time.deltaTime;
        if(currentTime>= attackTime&&dis<15f)
        {
            AttackBegin();
            currentTime = 0f;
        }
        if (!IsDead&&!IsAttack)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }
}
