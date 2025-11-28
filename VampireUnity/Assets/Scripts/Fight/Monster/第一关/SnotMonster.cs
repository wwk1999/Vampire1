using System;
using System.Collections;
using Equip;
using NUnit.Framework;
using UnityEngine;


public class SnotMonster : MonsterBase
{
   // [NonSerialized] public bool IsOriginal = true; //是否是原始状态

    //构造方法
    public SnotMonster() : base(MonsterType.Normal, "SnotMonster", 1, 100, 0.3f, 10, 5, 10, 10, 0)
    {
    }

    private void Start()
    {
        size = 0.15f;
        AddMonsterEquip();
        AddMonsterSourceStone();
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

    public override void Die()
    {
        
        //生成随机数
        int randomDelay = UnityEngine.Random.Range(0, 10);
        GameController.S.StartCoroutine(RandomDelayDie(randomDelay));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead) return;
       base.Update();
        
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }

    public override void Skill()
    {
        // Implement the skill logic here
    }
    
    public override void Hurt(int damage)
    {
        base.Hurt(damage);
        if (!IsDead)
        {
            AudioController.S.PlaySnotHit();
        }
    }

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Primary, 10));
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
}