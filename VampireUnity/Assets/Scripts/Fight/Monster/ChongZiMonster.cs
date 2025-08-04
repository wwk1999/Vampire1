using System.Collections;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class ChongZiMonster : MonsterBase
{
    public ChongZiMonster() : base(MonsterType.Normal, "ChongZiMonster", 1, 100, 0.3f, 10, 5, 10, 10, 0)
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
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryClothFight", 10));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryCloakFight", 10));
        
        MonsterEquipList.Add(new MonsterEquip("Green/GreenClothFight", 5));
        MonsterEquipList.Add(new MonsterEquip("Green/GreenRingFight", 5));
        MonsterEquipList.Add(new MonsterEquip("Green/GreenCloakFight", 5));
        MonsterEquipList.Add(new MonsterEquip("Green/GreenShoeFight", 5));
        MonsterEquipList.Add(new MonsterEquip("Green/GreenNecklaceFight", 5));
        MonsterEquipList.Add(new MonsterEquip("Green/GreenHelmetFight", 5));
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
    
    
    void Update()
    {
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }
}
