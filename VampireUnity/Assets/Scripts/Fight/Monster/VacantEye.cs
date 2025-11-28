using System;
using Equip;
using UnityEngine;

public class VacantEye : MonsterBase
{
    [NonSerialized]public VacantEyeBullet VacantEyeBullet;
    public VacantEye() : base(MonsterType.Boss, "VacantEye", 1, 10000, 0.3f, 20, 5, 500, 10, 100) { }
    [NonSerialized] public float SkillTime = 10;
    [NonSerialized] public float CurrentSkillTime = 0;
     public GameObject LaserObject;

     
     public override void Die()
     {
         GeneralDie();
         GetEx();
         ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy);
         CreateBloodEnergy();
         CreateEquip();
     }
     public override void Skill()
     {
     }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Blue, 10));
    }
    
    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,10));
    }

    public void ShotBullet()
    {
        //向四周发射vacantEyeBullet，发射12颗
        for (int i = 0; i < 12; i++)
        {
            float angle = i * 30f;
            Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
            VacantEyeBullet bullet = Instantiate(VacantEyeBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<VacantEyeBullet>().SetDirection(direction);
            bullet.gameObject.SetActive(true);
        }
    }

    public void SetAnimator()
    {
        //monsterAnimator.SetBool("isAttack", true);
    }
    //动画事件
    public void ShotLaserSkill()
    {
        LaserObject.gameObject.SetActive(true);
    }
    //动画事件
    public void StopLaserSkill()
    {
        LaserObject.gameObject.SetActive(false);
        //monsterAnimator.SetBool("isAttack", false);
    }
    private void Start()
    {
        VacantEyeBullet=Resources.Load<VacantEyeBullet>("Prefabs/Monster/VacantEyeBullet");
        AddMonsterEquip();
    }
    void Update()
    {
        CurrentSkillTime+= Time.deltaTime;
        if (CurrentSkillTime >= SkillTime)
        {
            SetAnimator();
            CurrentSkillTime = 0;
        }
        if (!IsDead)
        {
            MonsterMove();
            //SpriteFlipX(false);
        }
        //LaserObject.GetComponent<SpriteRenderer>().flipX=monsterSpriteRenderer.flipX;
        if (!LaserObject.GetComponent<SpriteRenderer>().flipX)
        {
            LaserObject.transform.localPosition=new Vector3(-29,0,LaserObject.transform.localPosition.z);
        }
        else
        {
            LaserObject.transform.localPosition=new Vector3(29,0,LaserObject.transform.localPosition.z);
        }
        //每隔1秒发射一次子弹
        if (Time.frameCount%100==0)
        {
            ShotBullet();
        }
    }
    
}
