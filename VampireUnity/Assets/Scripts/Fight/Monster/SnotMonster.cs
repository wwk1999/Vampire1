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
        int randomDelay = UnityEngine.Random.Range(0, 3);
        StartCoroutine(RandomDelayDie(randomDelay));
        // if (IsOriginal)
        // {
        //     GeneralDie();
        //     Debug.Log("分裂");
        //     GameObject obj1 = Instantiate(gameObject,
        //         new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z),
        //         Quaternion.identity);
        //     GameObject obj2 = Instantiate(gameObject,
        //         new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z),
        //         Quaternion.identity);
        //     obj1.transform.localScale = new Vector3(transform.localScale.x * 0.7f, transform.localScale.y * 0.7f,
        //         transform.localScale.z * 0.7f);
        //     obj2.transform.localScale = new Vector3(transform.localScale.x * 0.7f, transform.localScale.y * 0.7f,
        //         transform.localScale.z * 0.7f);
        //     obj1.GetComponent<SnotMonster>().IsOriginal = false;
        //     obj2.GetComponent<SnotMonster>().IsOriginal = false;
        //     obj1.GetComponent<BoxCollider2D>().enabled = true;
        //     obj2.GetComponent<BoxCollider2D>().enabled = true;
        //     
        //     gameObject.SetActive(false);
        //     GameController.S.SnotMonsterQueue.Enqueue(this);
        //     //Destroy(gameObject);
        // }
        // else
        // {
        //     GeneralDie();
        //     GetEx();
        //     ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy);
        //     CreateBloodEnergy();
        //     CreateEquip();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
        // else if (IsDead && IsOriginal)
        // {
        //     Debug.Log("分裂");
        //     GameObject obj1 = Instantiate(gameObject,
        //         new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z),
        //         Quaternion.identity);
        //     GameObject obj2 = Instantiate(gameObject,
        //         new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z),
        //         Quaternion.identity);
        //     obj1.transform.localScale = new Vector3(transform.localScale.x * 0.7f, transform.localScale.y * 0.7f,
        //         transform.localScale.z * 0.7f);
        //     obj2.transform.localScale = new Vector3(transform.localScale.x * 0.7f, transform.localScale.y * 0.7f,
        //         transform.localScale.z * 0.7f);
        //     obj1.GetComponent<SnotMonster>().IsOriginal = false;
        //     obj2.GetComponent<SnotMonster>().IsOriginal = false;
        //     obj1.GetComponent<BoxCollider2D>().enabled = true;
        //     obj2.GetComponent<BoxCollider2D>().enabled = true;
        //     // var equipRb1 = obj1.GetComponent<Rigidbody2D>();
        //     // equipRb1.linearVelocity = new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(3f, 5f));
        //     // var equipRb2 = obj2.GetComponent<Rigidbody2D>();
        //     // equipRb2.linearVelocity = new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(3f, 5f));
        // }
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
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryClothFight", 10));
        MonsterEquipList.Add(new MonsterEquip("Primary/PrimaryCloakFight", 10));
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
}