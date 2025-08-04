using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Mysql;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

//怪物类型枚举
public enum MonsterType
{
    None = 0,
    Normal = 1,
    Elite = 2,
    Boss = 3,
}

public enum State
{
    None,
    Idle,
    Move,
    Attack,
    Skill1,
    Skill2,
    Skill3,
    Die
}
public abstract class MonsterBase : MonoBehaviour
{
    [NonSerialized]public MonsterType MonsterType;//怪物类型
    [NonSerialized]public string MonsterName;//怪物名称
    [NonSerialized]public int MonsterLevel;//怪物等级
    [NonSerialized]public int CurrentHp;//当前血量
    [NonSerialized]public  int MaxHp;//最大血量
    [NonSerialized]public float Speed;//速度
    [NonSerialized]public int Attack;//攻击力
    [NonSerialized]public int Defense;//防御力
    [NonSerialized]public int Exp;//经验值
    [NonSerialized]public int BloodEnergy;//血能
    [NonSerialized]public int EvolutionEnergy;//源能
    [NonSerialized]public bool IsDead=false;//是否死亡
    [NonSerialized]public bool IsAttack=false;//是否攻击
    [NonSerialized]public State MonsterState = State.None;
    [NonSerialized]public bool IsSkill=false;//是否在放技能
    public SkeletonAnimation monsterSkeletonAnimation;
    //public SpriteRenderer monsterSpriteRenderer;
    //public Animator monsterAnimator;
    [NonSerialized]public GameObject monsterHurtText;
    public Slider hpSlider;
    [NonSerialized]public List<MonsterEquip> MonsterEquipList=new List<MonsterEquip>() ;//怪物装备列表
    [NonSerialized]public List<MonsterWeaponSource> MonsterWeaponSourceStoneList=new List<MonsterWeaponSource>() ;//怪物源石列表

    //经验相关
    [NonSerialized]public Text playerLevelText;


    //构造方法
    public MonsterBase(MonsterType monsterType, string monsterName, int monsterLevel, int maxHp, float speed, int attack, int defense, int exp, int bloodEnergy, int evolutionEnergy)
    {
        this.MonsterType = monsterType;
        this.MonsterName = monsterName;
        this.MonsterLevel = monsterLevel;
        this.MaxHp = maxHp;
        this.Speed = speed;
        this.Attack = attack;
        this.Defense = defense;
        this.Exp = exp;
        this.BloodEnergy = bloodEnergy;
        this.EvolutionEnergy = evolutionEnergy;
    }

    public abstract void AddMonsterEquip();
    public abstract void AddMonsterSourceStone();
    
    public void Awake()
    {
        ObserverModuleManager.S.RegisterEvent(ConstKeys.Resumemonster,Resumemonster);
        monsterHurtText=Resources.Load<GameObject>("Prefabs/Tool/MonsterHurtText");
        monsterSkeletonAnimation.AnimationState.Complete += OnAnimationComplete;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        CurrentHp = MaxHp;
    }
    public void Resumemonster(object[] args)
    {
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        MonsterState= State.Move;
        CameraContraller.CameraStatus= CameraStatus.MoveToPlayer;
    }

    public abstract void Skill();


    public void OnAnimationComplete(TrackEntry trackEntry)
    {
        //如果动画播放完毕
        if (trackEntry.Animation.Name == "hit"||trackEntry.Animation.Name == "attack"||trackEntry.Animation.Name == "skill")
        {
            //monsterAnimator.SetBool("isHurt", false);
            MonsterState = State.Move;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        }
        if (trackEntry.Animation.Name == "attack")
        {
            //monsterAnimator.SetBool("isHurt", false);
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        }
        if (trackEntry.Animation.Name == "chuxian")
        {
            //monsterAnimator.SetBool("isHurt", false);
            monsterSkeletonAnimation.AnimationState.SetAnimation(0,"walk", true);
            GetComponent<DunDiMonster>().IsAttack = false;
        }
        
        if (trackEntry.Animation.Name == "skill")
        {
            if (GetComponent<DunDiMonster>())
            { 
                //gameObject.SetActive(false);
                monsterSkeletonAnimation.AnimationState.SetAnimation(0,"walk", true);
                transform.localScale= new Vector3(0, 0, 0);
                return;
            }
            if (!GetComponent<EliteDaZuiMonster>())
            {
                Skill();
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
            }
        }
        if (trackEntry.Animation.Name == "die")
        {
            if (GetComponent<SnotMonster>())
            {
                gameObject.SetActive(false);
                GameController.S.SnotMonsterQueue.Enqueue(GetComponent<SnotMonster>());
            }
            if (GetComponent<BatMonster>())
            {
                gameObject.SetActive(false);
                GameController.S.BatMonsterQueue.Enqueue(GetComponent<BatMonster>());
            }
            if (GetComponent<SpiderMonster>())
            {
                gameObject.SetActive(false);
                GameController.S.SpiderMonsterQueue.Enqueue(GetComponent<SpiderMonster>());
            }
            if (GetComponent<EliteBeeMonster>())
            {
                gameObject.SetActive(false);
                GameController.S.EliteBeeMonsterQueue.Enqueue(GetComponent<EliteBeeMonster>());
            }
            
            
            if (GetComponent<ChongZiMonster>())
            {
                gameObject.SetActive(false);
                GameController.S.ChongZiMonsterQueue.Enqueue(GetComponent<ChongZiMonster>());
            }
            if (GetComponent<XiaoHuoMonster>())
            {
                gameObject.SetActive(false);
                GameController.S.XiaoHuoMonsterQueue.Enqueue(GetComponent<XiaoHuoMonster>());
            }
            if (GetComponent<DunDiMonster>())
            {
                gameObject.SetActive(false);
                GameController.S.DunDiMonsterQueue.Enqueue(GetComponent<DunDiMonster>());
            }
            if (GetComponent<EliteDaZuiMonster>())
            {
                gameObject.SetActive(false);
                GameController.S.EliteDaZuiMonsterQueue.Enqueue(GetComponent<EliteDaZuiMonster>());
            }
        }
        if (trackEntry.Animation.Name == "Exit")
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
            MonsterState= State.Move;
            CameraContraller.CameraStatus= CameraStatus.MoveToPlayer;
        }
        if (trackEntry.Animation.Name == "skill_01")
        {
            MonsterState= State.Move;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        }
        if (trackEntry.Animation.Name == "skill_02")
        {
            MonsterState= State.Move;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        }
        if (trackEntry.Animation.Name == "skill_03")
        {
            MonsterState= State.Move;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        }

        if (trackEntry.Animation.Name == "zhiwnag")
        {
            SpiderWeb spiderWeb = FightBGController.S.SpiderWebQueue.Dequeue();
            spiderWeb.transform.position = transform.position;
            spiderWeb.gameObject.SetActive(true);
            IsSkill= false;
        }
    }

    public void MonsterMove()
    {
        //朝着主角以speed的速度前进
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        //刚体移动
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "Exit"&&!IsSkill)
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
        }
    }
    

    // //动画事件，设置isHurt
    // public void SetIsHurt()
    // {
    //     monsterAnimator.SetBool("isHurt", false);
    // }
    // //动画事件，销毁怪物
    // public void DestroyMonster()
    // {
    //     Destroy(this.gameObject);
    // }
    public void SpriteFlipX(bool isRight)
    {
        float dis=Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position);
        if(dis<0.2f)
        {
            //如果距离小于0.2f，则不翻转
            return;
        }
        //翻转精灵
        if (isRight)
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                monsterSkeletonAnimation.skeleton.FlipX = false;
            }
            else
            {
                monsterSkeletonAnimation.skeleton.FlipX = true;
            }
        }else
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                monsterSkeletonAnimation.skeleton.FlipX = true;
            }
            else
            {
                monsterSkeletonAnimation.skeleton.FlipX = false;
            }
        }
        
    }

    /// <summary>
    /// 获得经验
    /// </summary>
    public void GetEx()
    {
        GlobalPlayerAttribute.Exp+= Exp;
        if(GlobalPlayerAttribute.Exp>GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level])
        {
            //升级
            playerLevelText = GameController.S.gamePlayer.levelText;
            GameController.S.gamePlayer.transform.Find("LevelUp").gameObject.SetActive(true);
            GameController.S.gamePlayer.transform.Find("LevelUp").GetComponent<ParticleSystem>().Play();
            GlobalPlayerAttribute.Level++;
            playerLevelText.text =  GlobalPlayerAttribute.Level.ToString();
            GlobalPlayerAttribute.Exp=GlobalPlayerAttribute.Exp-GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level-1];
            PlayerInfoController.S.UpdatePlayerInfo( UserController.S.selfuserId,GlobalPlayerAttribute.Level, GlobalPlayerAttribute.Exp);
        }
        GameController.S.gamePlayer.exSlider.maxValue=GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level];
        GameController.S.gamePlayer.exSlider.value=GlobalPlayerAttribute.Exp ;
    }

    // /// <summary>
    // /// 获得BOSS能量
    // /// </summary>
    // public void GetBossEnergy()
    // {
    //     switch (MonsterType)
    //     {
    //         case MonsterType.Normal:
    //             GameController.S.BossEnergy+= 1;
    //             break;
    //         case MonsterType.Elite:
    //             GameController.S.BossEnergy+= 10;
    //             break;
    //     }
    // }

    /// <summary>
    /// 生成血能
    /// </summary>
    public void CreateBloodEnergy()
    {
        //生成血能
        GameObject bloodEnergy = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BloodEnergy"));
        //设置血能位置为怪物位置
        bloodEnergy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    /// <summary>
    /// 死亡通用
    /// </summary>
    public void GeneralDie()
    {
        if (monsterSkeletonAnimation.timeScale == 0)
            monsterSkeletonAnimation.timeScale = 1;
        if (GetComponent<TreeManBoss>())
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "die_02", false);
        }else
             monsterSkeletonAnimation.AnimationState.SetAnimation(0, "die", false);
        // 从所有探测器列表中移除自己
        // 立即从所有探测器列表中移除自己
        if (GameController.S != null)
        {
            GameController.S.monsterDetetor1.RemoveAll(m => m == this);
            GameController.S.monsterDetetor2.RemoveAll(m => m == this);
            GameController.S.monsterDetetor3.RemoveAll(m => m == this);
            GameController.S.monsterDetetor4.RemoveAll(m => m == this);
        }
        // 禁用碰撞器，防止继续触发碰撞
        if(GetComponent<Collider2D>() != null)
            GetComponent<Collider2D>().enabled = false;
        
        // 禁用移动
        if(GetComponent<Rigidbody2D>() != null)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public abstract void Die();
  
    public virtual void Hurt(int damage)
    {
        if (MonsterType != MonsterType.Boss)
        {
            GameObject monsterHpGameObject = Instantiate(monsterHurtText);
            monsterHpGameObject.transform.position = transform.position;
            //在monsterHpGameObject子类中查找Canvas的紫累HPText
            Text monsterHpText = monsterHpGameObject.transform.Find("Canvas/HPText").GetComponent<Text>();
            //设置monsterHpText的text为-damage
            monsterHpText.text = "-" + damage.ToString();
            //设置monsterHpGameObject的position为怪物位置
            monsterHpGameObject.transform.position = new Vector3(transform.position.x + 0.1f,
                transform.position.y + 0.2f, transform.position.z);
            //设置monsterAnimator的ishuru为true
            // monsterAnimator.SetBool("isHurt", true);
            //重新播放Hurt动画
            //monsterAnimator.Play("SnotMonsterHit");
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "hit", false);
            CurrentHp -= damage;
            //设置血条
            hpSlider.value = (float)CurrentHp / MaxHp;
            if (CurrentHp <= 0 && !IsDead)
            {
                IsDead = true;
                Die();
            }
        }
        else
        {
            if(MonsterState== State.Die) return;
            if (MonsterState == State.Move)
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "hit", false);
                CurrentHp -= damage;
                hpSlider.value = (float)CurrentHp / MaxHp;
                if (CurrentHp <= 0 && !IsDead)
                {
                    IsDead = true;
                    Die();
                }
            }else if (MonsterState == State.Skill1 || MonsterState == State.Skill2 || MonsterState == State.Skill3)
            {
                CurrentHp -= damage;
                hpSlider.value = (float)CurrentHp / MaxHp;
                if (CurrentHp <= 0 && !IsDead)
                {
                    IsDead = true;
                    Die();
                }
            }
        }
    }

     /// <summary>
     /// 生成装备
     /// </summary>
    public void CreateEquip()
    {
        //根据MonsterEquip的概率随机生成装备
        foreach (MonsterEquip monsterEquip in MonsterEquipList)
        {
            int random = UnityEngine.Random.Range(0, 100);
            if (random <= monsterEquip.Probability)
            {
                //生成装备
                Debug.Log("生成装备："+monsterEquip.Name);
                GameObject equip = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/" + monsterEquip.Name));
                //设置装备位置为怪物位置
                equip.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
     
     
    public void CreateWeaponSourceStone()
    {
        //根据MonsterEquip的概率随机生成装备
        foreach (MonsterWeaponSource monsterWeaponSource in MonsterWeaponSourceStoneList)
        {
            int random = UnityEngine.Random.Range(0, 100);
            if (random <= monsterWeaponSource.Probability)
            {
                //生成装备
                Debug.Log("生成源石");
                GameObject sourcestone;
                switch (monsterWeaponSource.SourceStoneType)
                {
                    case WeaponSourceStoneType.Penetrate:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponPenetrate"));
                        break;
                    case WeaponSourceStoneType.Division:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponDivision"));
                        break;
                    case WeaponSourceStoneType.Explosion:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponExplosion"));
                        break;
                    case WeaponSourceStoneType.ExtremeSpeed:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponExtremeSpeed"));
                        break;
                    case WeaponSourceStoneType.Scale:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponScale"));
                        break;
                    case WeaponSourceStoneType.Duration:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponDuration"));
                        break;
                    default:
                        sourcestone = Instantiate(Resources.Load<GameObject>("Prefabs/WeaponSourceStone/FightWeaponExtremeSpeed"));
                        break;
                }
                //设置装备位置为怪物位置
                sourcestone.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //BulletBase bullet = other.gameObject.GetComponent<BulletBase>();
//            Hurt(bullet.damage);
            //销毁子弹
           // Destroy(other.gameObject);
            
        }else if ((tag=="Monster"||tag=="Boss")&&other.gameObject.CompareTag("PlayerTrigger")&& !GameController.S.gamePlayer.IsWuDi)
        {
            if (GetComponent<BatMonster>())
            {
                var batskillparticle=FightBGController.S.BatSkillParticleQueue.Dequeue();
                batskillparticle.gameObject.SetActive(true);
                batskillparticle.Play();
                batskillparticle.transform.position = new Vector3(GameController.S.gamePlayer.transform.position.x, GameController.S.gamePlayer.transform.position.y, GameController.S.gamePlayer.transform.position.z);
                StartCoroutine(BatParticleEnQueue(batskillparticle));
            }
            GameController.S.gamePlayer.PlayerHurt(Attack);
        }
    }
    
    private IEnumerator BatParticleEnQueue(ParticleSystem particle)
    {
        yield return new WaitForSeconds(0.6f);
       particle.gameObject.SetActive(false);
         FightBGController.S.BatSkillParticleQueue.Enqueue(particle);

    }

}
