using System;
using System.Collections;
using Equip;
using UnityEngine;

public class EliteBeeMonster : MonsterBase
{
    [NonSerialized] public float SkillTime = 3f;
    [NonSerialized] public float SkillColingTime = 0f;
    //public GameObject skillRangeTrigger;
    [NonSerialized]public bool IsTrigger = false; // 是否触发攻击
    public GameObject beeBullet;
   



    public EliteBeeMonster() : base(MonsterType.Elite, "EliteBeeMonster", 1, 1000, 0.3f, 20, 5, 50, 100, 10) { }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Primary, 10));
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

    public void Start()
    {
        size = 0.5f;
        AddMonsterEquip();
        AddMonsterSourceStone();
    }

    private IEnumerator RandomDelayDie(int delay)
    {
        for (int i = 0; i < delay; i++)
        {
            yield return null;
        }

        AudioController.S.PlayEliteBeeDie();
        // gameObject.SetActive(false);
        // GameController.S.EliteBeeMonsterQueue.Enqueue(this);
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy,2);
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
    }

    public override void Die()
    {
        //生成随机数
        int randomDelay = UnityEngine.Random.Range(0, 10);
        GameController.S.StartCoroutine(RandomDelayDie(randomDelay));
        // gameObject.SetActive(false);
        // GameController.S.EliteBeeMonsterQueue.Enqueue(this);
        // GeneralDie();
        // GetEx();
        // ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy);
        // CreateBloodEnergy();
        // CreateEquip();
    }
    
    

    public override void Skill()
    {
        GameObject bullet = Instantiate(beeBullet, beeBullet.transform.parent);
        ParticleSystem flash= bullet.transform.Find("Flash 1").GetComponent<ParticleSystem>();
        ParticleSystem projectile=bullet.transform.Find("Projectile 1").GetComponent<ParticleSystem>();
        //主角朝最近怪物的方向
        Vector3 direction = (GameController.S.gamePlayer.transform.position - transform.position).normalized;
        //设置枪的位置
        //currentGun.transform.position = transform.position + direction * _gunDistance;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        flash.Play();
        projectile.Play();
        AudioController.S.PlayBeeSkill();
    }
    void Update()
    {
        if (IsDead) return;
        base.Update();
        
        SkillColingTime+= Time.deltaTime;
        if(SkillColingTime>=SkillTime&&IsTrigger&& !IsDead)
        {
            SkillColingTime = 0;
            //这这里设置为skill状态，然后在base里的complete回调里执行skill方法
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill", false);
        }
        if (!IsDead)
        {
            SpriteFlipX(false);
            //SpriteFlipX(false);
        }

        if (!IsDead && !IsTrigger)
        {
             MonsterMove();
        }
    }
    
    public override void Hurt(int damage)
    {
        base.Hurt(damage);
        if (!IsDead)
        {
            AudioController.S.PlayEliteBeeHit();
        }
    }
}
