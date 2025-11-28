using System;
using System.Collections;
using Equip;
using Spine;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
public class TreeManBoss : MonsterBase
{
    public TreeManBoss() : base(MonsterType.Boss, "TreeManBoss", 1, 1000, 0.5f, 10, 5, 10, 10, 0) { }
   [NonSerialized]public float FireSkillTime = 30f;
   [NonSerialized]public float FireSkillCurrentTime = 0f;
   [NonSerialized]public float DashSkillTime = 10f;
   [NonSerialized]public float DashSkillCurrentTime = 0f;
   [NonSerialized]public float GroundFissureSkillTime = 20f;
   [NonSerialized]public float GroundFissureSkillCurrentTime = 0f;
   [NonSerialized]public Vector2 Dashdirection = Vector2.zero;
   [NonSerialized]public Vector2 GroundFissurepos = Vector2.zero;
   [NonSerialized]public Vector2 BaoZhapos = Vector2.zero;
   public TreeManJumpTrigger treeManJumpTrigger;
   [NonSerialized]public bool CircleAttackEnd = false;
   //[NonSerialized] public bool HaveCircleAttack = false;

    public  void Awake()
    {
        base.Awake();
        size = 1.5f;
        // 获取 SkeletonAnimation
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;

       ObserverModuleManager.S.RegisterEvent(ConstKeys.TreeManFireSkill1,TreeManFireSkill1);
       ObserverModuleManager.S.RegisterEvent(ConstKeys.TreeManDashSkill1,TreeManDashSkill1);
    }
    
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        Debug.Log($"触发事件帧！动画名称: {trackEntry.Animation.Name}, 事件名称: {e.Data.Name}, 事件值: {e.String}");

        // 根据事件名称处理逻辑
        if (e.Data.Name == "chong")
        {
            Debug.Log("执行攻击逻辑");
           
            TreeManDash(Dashdirection);
        }
        else if (e.Data.Name == "tiao")
        {
            Debug.Log("执行跳跃逻辑");
            StartCoroutine(MoveToTarget(GroundFissurepos, 5f)); // 移动速度：5f
        }else if (e.Data.Name == "baozha")
        {
            Debug.Log("执行跳跃逻辑");
            //FightBGController.S.PlayGroundFissure(BaoZhapos);
        }
    }

    public void TreeManDashSkill1(object[] args)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SqrtAttack sqrtAttack = FightBGController.S.SqrtAttackQueue.Dequeue();
        sqrtAttack.gameObject.SetActive(true);
        sqrtAttack.transform.position = transform.position;
        //主角朝最近怪物的方向
        Vector3 direction = (GameController.S.gamePlayer.transform.position - transform.position).normalized;
        Dashdirection = direction;
        //设置枪的位置
        //currentGun.transform.position = transform.position + direction * _gunDistance;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sqrtAttack.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        sqrtAttack.transform.position += direction * 4f;
        //播放冲刺动画，chong的时候开始移动
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_04", false);

       // StartCoroutine(TreeManDash(2f,direction));
    }

    private void TreeManDash(Vector2 dir)
    {
        //朝着主角以speed的速度前进
        GetComponent<Rigidbody2D>().velocity = dir.normalized * 10;
        StartCoroutine(TreeManDashEnd(1f));
    }

    private IEnumerator TreeManDashEnd(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        MonsterState= State.Move;
    }



    public void TreeManFireSkill1(object[] args)
    {
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_03", true);
        StartCoroutine(WaitForTime( 0.5f));
    }
    private IEnumerator WaitForTime(float waitTime)
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("TreeManFire技能");
        
            // 从队列中取出 CircleAttack
            CircleAttack circleAttack = FightBGController.S.CircleAttackQueue.Dequeue();
            // 随机生成速度
            Vector2 linearVelocity = new Vector2(UnityEngine.Random.Range(-2.5f, 2.5f), UnityEngine.Random.Range(3f, 6f));
            // 计算落地方位
            Vector2 pos = FightBGController.S.CalculateLandingPosition(transform.position, linearVelocity, UnityEngine.Random.Range(2f, 3f), 3f);
            circleAttack.transform.position = pos;
            circleAttack.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            circleAttack.gameObject.SetActive(true);
            circleAttack.circleAttackState = CircleAttackState.TreeManSkill2;
            yield return new WaitForSeconds(waitTime);
        }
        yield return new WaitForSeconds(1f);
        MonsterState= State.Move;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
    }

    private IEnumerator WaitForTimeStill(float waitTime, TreeManFire fire)
    {
        yield return new WaitForSeconds(waitTime);
        fire.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        fire.GetComponent<Rigidbody2D>().gravityScale= 0f;
    }


   
    public override void Die()
    {
        GeneralDie();
        GetEx();
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
        TreeManBossDie();
        FightBGController.S.PlaySuccessAnim();
    }

    public void TreeManBossDie()
    {
        GameController.S.GameOver = true;
        var protalopen=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/PortalGreenOpen"));
        protalopen.transform.position = transform.position;
        GameController.S.StartCoroutine(ProtalIdle(protalopen,transform.position));
       // hpSlider.gameObject.SetActive(false);
        Destroy(gameObject);
    }
    
    //携程等待1s
    private IEnumerator ProtalIdle(GameObject obj,Vector3 position)
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(obj);
        var protalidle=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/PortalGreenIdle"));
        protalidle.transform.position =position;
    }
    
    public void Skill1Pre()
    {
        Debug.Log("Skill1Pre");
        //播放CircleAttack动画
        if (!FightBGController.S.HaveCircleAttack)
        {
            FightBGController.S.TreeManBoss.Skill1End(GameController.S.gamePlayer.transform.position);
            FightBGController.S.CircleAttack.SetActive(true);
            FightBGController.S.CircleAttack.GetComponent<CircleAttack>().circleAttackState = CircleAttackState.TreeManSkill1;
            FightBGController.S.CircleAttack.transform.position=GameController.S.gamePlayer.transform.position;
        }
        // monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_01", false);
        // Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        // GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * 3f; 
    }

    public void Skill1End(Vector3 pos)
    {
        GroundFissurepos = pos;
        // 设置动画状态为“skill_01”
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_01", false);

        // 开启协程进行平滑移动
        //StartCoroutine(MoveToTarget(pos, 5f)); // 移动速度：5f
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition, float speed)
    {
       
        Rigidbody2D rb = GetComponent<Rigidbody2D>(); // 获取刚体组件

        // 持续移动，直到达到目标位置
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f) // 阈值
        {
            // 计算移动方向
            Vector3 direction = (targetPosition - transform.position).normalized;
            //计算targetPosition和transform.position的距离
            float distance = Vector3.Distance(targetPosition, transform.position);

            // 设置刚体速度
            rb.velocity = direction * speed*distance;

            // 等待下一帧
            yield return null;
        }
        BaoZhapos = targetPosition;
        // 到达目标位置后，停止刚体运动
        rb.velocity = Vector2.zero;
        FightBGController.S.PlayGroundFissure(targetPosition);
        yield break; // 退出协程
    }

    private void Update()
    {
        if (IsDead) return;
        base.Update();
        
        
        //Debug.Log("BOSS状态："+MonsterState);
        switch (MonsterState)
        {
            case State.Move:
                if (!IsDead)
                {
                    MonsterMove();
                    SpriteFlipX(true);
                }
                break;
            case State.Skill1:
                if(!FightBGController.S.HaveCircleAttack&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "skill_01")
                    Skill1Pre();
                break;
            case State.Skill2:
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                break;
        }
        GroundFissureSkillCurrentTime+=Time.deltaTime;
        FireSkillCurrentTime+= Time.deltaTime;
        DashSkillCurrentTime+= Time.deltaTime;

        if (FireSkillCurrentTime >= FireSkillTime && treeManJumpTrigger.isTrigger && MonsterState == State.Move)
        {
            MonsterState = State.Skill2;
            if (FireSkillCurrentTime >= FireSkillTime)
                ObserverModuleManager.S.SendEvent(ConstKeys.TreeManFireSkill1);
            FireSkillCurrentTime = 0;
        }

        if (GroundFissureSkillCurrentTime >= GroundFissureSkillTime && treeManJumpTrigger.isTrigger&&MonsterState==State.Move)
        {
            GroundFissureSkillCurrentTime = 0;
            MonsterState= State.Skill1;
        }
        

        if (DashSkillCurrentTime >= DashSkillTime && treeManJumpTrigger.isTrigger && MonsterState == State.Move)
        {
            MonsterState= State.Skill3;
            ObserverModuleManager.S.SendEvent(ConstKeys.TreeManDashSkill1);
            DashSkillCurrentTime = 0;
        }

    }

    public override void Skill() { }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Primary, 10));
        
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.TreeMan, 10));
    }

    // public override void Hurt(int damage)
    // {
    //     base.Hurt(damage);
    //     hpSlider.value -= damage;
    // }

    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,10));
    }
}
