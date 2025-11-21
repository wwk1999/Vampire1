using UnityEngine;

public class GunBase : MonoBehaviour
{
    private float _attackSpeed;
    public BulletBase _bullet;

    public SpriteRenderer gunSpriteRender;
    //构造方法
    public GunBase(float attackSpeed)
    {
        this._attackSpeed = attackSpeed;
    }
    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }

    /// <summary>
    /// 第二个武器普通攻击
    /// </summary>
    /// <param name="scale"></param>
    /// <param name="division"></param>
    /// <param name="extremeSpeed"></param>
    /// <param name="duration"></param>
    public void TwoShot(int scale, int division, int extremeSpeed, int duration)
    {
        // 原始方向
        Vector2 baseDir = (GameController.S.nearMonsterPosition -GameController.S.gamePlayer.transform.position).normalized;

        // 两个偏移角度：+10° 和 -10°
        Vector2[] dirs =
        {
            Quaternion.AngleAxis( 10f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis(-10f, Vector3.forward) * baseDir
        };

        // 连发两颗
        foreach (Vector2 dir in dirs)
        {
            GameObject bullet = GameController.S.TwoNormalAttackQueue.Dequeue();
            bullet.transform.position = GameController.S.gamePlayer.transform.position;
            bullet.SetActive(true);

            var attack = bullet.GetComponent<TwoNormalAttack>();
            attack.MoveDirection = dir;
            attack.MoveSpeed = 2f;
        }
    }
    
    public void ThreeShot(int scale, int division, int extremeSpeed, int duration)
    {
        Vector2 direction = (GameController.S.nearMonsterPosition- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.ThreeNormalAttackQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<ThreeNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<ThreeNormalAttack>().MoveSpeed = 12f;
    }
    
    public void FourShot(int scale, int division, int extremeSpeed, int duration)
    {
        Vector2 direction = (GameController.S.nearMonsterPosition- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.FourNormalAttackQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<FourNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<FourNormalAttack>().MoveSpeed = 10f;
    }


    /// <summary>
    /// 原始武器普通攻击
    /// </summary>
    /// <param name="penetrate"></param>
    /// <param name="division"></param>
    /// <param name="extremeSpeed"></param>
    /// <param name="explosion"></param>
    public void PrimaryShot(int penetrate,int division,int extremeSpeed,int explosion)
    {
        // //实例化子弹
        // BulletBase bullet=Instantiate(Resources.Load<BulletBase>("Prefabs/Bullet/PistolBullet"));
        // //设置子弹方向
        // bullet.Direction = GameController.S.gamePlayer.transform.position - transform.position;
        // if (GameController.S.gamePlayer.currentGun.gunSpriteRender.flipY)
        //     bullet.transform.localPosition=new Vector3(bullet.transform.localPosition.x,-2,bullet.transform.localPosition.z);
        // bullet.transform.position=transform.position;
        switch (division)
        {
            case 0:
                ParticleSystem.MainModule mainModule = SkillController.S.NormalAttack.main;
                ParticleSystem.MainModule mainModuleTrail = SkillController.S.NormalAttack.transform.Find("Trail")
                    .GetComponent<ParticleSystem>().main;
                switch (extremeSpeed)
                {
                    case 1:
                        mainModule.simulationSpeed = 2f;
                        mainModuleTrail.simulationSpeed = 2f;
                        break;
                    case 2:
                        mainModule.simulationSpeed = 3f;
                        mainModuleTrail.simulationSpeed = 3f;
                        break;
                    case 3:
                        mainModule.simulationSpeed = 4f;
                        mainModuleTrail.simulationSpeed = 4f;
                        break;
                }

                switch (explosion)
                {
                    case 1:
                        SkillController.S.NormalAttack.GetComponent<NormalAttack>().Explosion = 1;
                        break;
                    case 2:
                        SkillController.S.NormalAttack.GetComponent<NormalAttack>().Explosion = 2;
                        break;
                    case 3:
                        SkillController.S.NormalAttack.GetComponent<NormalAttack>().Explosion = 3;
                        break;
                }
               // mainModule.simulationSpeed = 1.5f;
                SkillController.S.NormalAttack.Play();
                SkillController.S.NormalAttack.transform.Find("Trail").gameObject.SetActive(true);
                break;
            case 1:
               ParticleSystem normalAttack21=SkillController.S.NormalAttack2.transform.Find("NormalAttack-1").GetComponent<ParticleSystem>();
               ParticleSystem normalAttack22=SkillController.S.NormalAttack2.transform.Find("NormalAttack-2").GetComponent<ParticleSystem>();
               ParticleSystem.MainModule mainModuleTrail21 = SkillController.S.NormalAttack2.transform.Find("NormalAttack-1/Trail").GetComponent<ParticleSystem>().main;
               ParticleSystem.MainModule mainModuleTrail22 = SkillController.S.NormalAttack2.transform.Find("NormalAttack-2/Trail").GetComponent<ParticleSystem>().main;

               ParticleSystem.MainModule mainModule21 = normalAttack21.main;
               //mainModule21.simulationSpeed = 1.5f;
               normalAttack21.Play();
               normalAttack21.transform.Find("Trail").gameObject.SetActive(true);
               
               ParticleSystem.MainModule mainModule22 = normalAttack22.main;
               //mainModule22.simulationSpeed = 1.5f;
               normalAttack22.Play();
               normalAttack22.transform.Find("Trail").gameObject.SetActive(true);

               switch (extremeSpeed)
               {
                   case 1:
                       mainModule21.simulationSpeed = 2f;
                       mainModule22.simulationSpeed = 2f;
                       mainModuleTrail21.simulationSpeed = 2f;
                       mainModuleTrail22.simulationSpeed = 2f;
                   break;
                   case 2:
                       mainModule21.simulationSpeed = 3f;
                       mainModule22.simulationSpeed = 3f;
                       mainModuleTrail21.simulationSpeed = 3f;
                       mainModuleTrail22.simulationSpeed = 3f;
                       break;
                   case 3:
                       mainModule21.simulationSpeed = 4f;
                       mainModule22.simulationSpeed = 4f;
                       mainModuleTrail21.simulationSpeed = 4f;
                       mainModuleTrail22.simulationSpeed = 4f;
                       break;
               }
               
               switch (explosion)
               {
                   case 1:
                       SkillController.S.NormalAttack2.transform.Find("NormalAttack-1").GetComponent<NormalAttack>().Explosion = 1;
                       SkillController.S.NormalAttack2.transform.Find("NormalAttack-2").GetComponent<NormalAttack>().Explosion = 1;
                       break;
                   case 2:
                       SkillController.S.NormalAttack2.transform.Find("NormalAttack-1").GetComponent<NormalAttack>().Explosion = 2;
                       SkillController.S.NormalAttack2.transform.Find("NormalAttack-2").GetComponent<NormalAttack>().Explosion = 2;
                       break;
                   case 3:
                       SkillController.S.NormalAttack2.transform.Find("NormalAttack-1").GetComponent<NormalAttack>().Explosion = 3;
                       SkillController.S.NormalAttack2.transform.Find("NormalAttack-2").GetComponent<NormalAttack>().Explosion = 3;
                       break;
               }
               
                break;
            case 2:
                ParticleSystem normalAttack31=SkillController.S.NormalAttack3.transform.Find("NormalAttack-1").GetComponent<ParticleSystem>();
                ParticleSystem normalAttack32=SkillController.S.NormalAttack3.transform.Find("NormalAttack-2").GetComponent<ParticleSystem>();
                ParticleSystem normalAttack33=SkillController.S.NormalAttack3.transform.Find("NormalAttack-3").GetComponent<ParticleSystem>();
                ParticleSystem.MainModule mainModuleTrail31 = SkillController.S.NormalAttack3.transform.Find("NormalAttack-1/Trail").GetComponent<ParticleSystem>().main;
                ParticleSystem.MainModule mainModuleTrail32 = SkillController.S.NormalAttack3.transform.Find("NormalAttack-2/Trail").GetComponent<ParticleSystem>().main;
                ParticleSystem.MainModule mainModuleTrail33 = SkillController.S.NormalAttack3.transform.Find("NormalAttack-3/Trail").GetComponent<ParticleSystem>().main;


                ParticleSystem.MainModule mainModule31 = normalAttack31.main;
                //mainModule31.simulationSpeed = 1.5f;
                normalAttack31.Play();
                normalAttack31.transform.Find("Trail").gameObject.SetActive(true);
               
                ParticleSystem.MainModule mainModule32 = normalAttack32.main;
                //mainModule32.simulationSpeed = 1.5f;
                normalAttack32.Play();
                normalAttack32.transform.Find("Trail").gameObject.SetActive(true);
                
                ParticleSystem.MainModule mainModule33 = normalAttack33.main;
                //mainModule33.simulationSpeed = 1.5f;
                normalAttack33.Play();
                normalAttack33.transform.Find("Trail").gameObject.SetActive(true);
                
                switch (extremeSpeed)
                {
                    case 1:
                        mainModule31.simulationSpeed = 2f;
                        mainModule32.simulationSpeed = 2f;
                        mainModule33.simulationSpeed = 2f;
                        mainModuleTrail31.simulationSpeed = 2f;
                        mainModuleTrail32.simulationSpeed = 2f;
                        mainModuleTrail33.simulationSpeed = 2f;

                        break;
                    case 2:
                        mainModule21.simulationSpeed = 3f;
                        mainModule22.simulationSpeed = 3f;
                        mainModule33.simulationSpeed = 3f;
                        mainModuleTrail31.simulationSpeed = 3f;
                        mainModuleTrail32.simulationSpeed = 3;
                        mainModuleTrail33.simulationSpeed = 3f;
                        break;
                    case 3:
                        mainModule21.simulationSpeed = 4f;
                        mainModule22.simulationSpeed = 4f;
                        mainModule33.simulationSpeed = 4f;
                        mainModuleTrail31.simulationSpeed = 4f;
                        mainModuleTrail32.simulationSpeed = 4f;
                        mainModuleTrail33.simulationSpeed = 4f;
                        break;
                }
                
                switch (explosion)
                {
                    case 1:
                        SkillController.S.NormalAttack3.transform.Find("NormalAttack-1").GetComponent<NormalAttack>().Explosion = 1;
                        SkillController.S.NormalAttack3.transform.Find("NormalAttack-2").GetComponent<NormalAttack>().Explosion = 1;
                        SkillController.S.NormalAttack3.transform.Find("NormalAttack-3").GetComponent<NormalAttack>().Explosion = 1;
                        break;
                    case 2:
                        SkillController.S.NormalAttack3.transform.Find("NormalAttack-1").GetComponent<NormalAttack>().Explosion = 2;
                        SkillController.S.NormalAttack3.transform.Find("NormalAttack-2").GetComponent<NormalAttack>().Explosion = 2;
                        SkillController.S.NormalAttack3.transform.Find("NormalAttack-3").GetComponent<NormalAttack>().Explosion = 2;
                        break;
                    case 3:
                        SkillController.S.NormalAttack3.transform.Find("NormalAttack-1").GetComponent<NormalAttack>().Explosion = 3;
                        SkillController.S.NormalAttack3.transform.Find("NormalAttack-2").GetComponent<NormalAttack>().Explosion = 3;
                        SkillController.S.NormalAttack3.transform.Find("NormalAttack-3").GetComponent<NormalAttack>().Explosion = 3;
                        break;
                }
                
                break;
            case 3:
                ParticleSystem normalAttack41=SkillController.S.NormalAttack4.transform.Find("NormalAttack-1").GetComponent<ParticleSystem>();
                ParticleSystem normalAttack42=SkillController.S.NormalAttack4.transform.Find("NormalAttack-2").GetComponent<ParticleSystem>();
                ParticleSystem normalAttack43=SkillController.S.NormalAttack4.transform.Find("NormalAttack-3").GetComponent<ParticleSystem>();
                ParticleSystem normalAttack44=SkillController.S.NormalAttack4.transform.Find("NormalAttack-4").GetComponent<ParticleSystem>();
                ParticleSystem.MainModule mainModuleTrail41 = SkillController.S.NormalAttack4.transform.Find("NormalAttack-1/Trail").GetComponent<ParticleSystem>().main;
                ParticleSystem.MainModule mainModuleTrail42 = SkillController.S.NormalAttack4.transform.Find("NormalAttack-2/Trail").GetComponent<ParticleSystem>().main;
                ParticleSystem.MainModule mainModuleTrail43 = SkillController.S.NormalAttack4.transform.Find("NormalAttack-3/Trail").GetComponent<ParticleSystem>().main;
                ParticleSystem.MainModule mainModuleTrail44 = SkillController.S.NormalAttack4.transform.Find("NormalAttack-4/Trail").GetComponent<ParticleSystem>().main;

                
                ParticleSystem.MainModule mainModule41 = normalAttack41.main;
                //mainModule41.simulationSpeed = 1.5f;
                normalAttack41.Play();
                normalAttack41.transform.Find("Trail").gameObject.SetActive(true);
                
                ParticleSystem.MainModule mainModule42 = normalAttack42.main;
                //mainModule41.simulationSpeed = 1.5f;
                normalAttack42.Play();
                normalAttack42.transform.Find("Trail").gameObject.SetActive(true);
                
                ParticleSystem.MainModule mainModule43 = normalAttack43.main;
                //mainModule41.simulationSpeed = 1.5f;
                normalAttack43.Play();
                normalAttack43.transform.Find("Trail").gameObject.SetActive(true);
                
                ParticleSystem.MainModule mainModule44 = normalAttack44.main;
                //mainModule41.simulationSpeed = 1.5f;
                normalAttack44.Play();
                normalAttack44.transform.Find("Trail").gameObject.SetActive(true);

                switch (extremeSpeed)
                {
                    case 1:
                        mainModule41.simulationSpeed = 2f;
                        mainModule42.simulationSpeed = 2f;
                        mainModule43.simulationSpeed = 2f;
                        mainModule44.simulationSpeed = 2f;
                        mainModuleTrail41.simulationSpeed = 2f;
                        mainModuleTrail42.simulationSpeed = 2f;
                        mainModuleTrail43.simulationSpeed = 2f;
                        mainModuleTrail44.simulationSpeed = 2f;

                        break;
                    case 2:
                        mainModule41.simulationSpeed = 3f;
                        mainModule42.simulationSpeed = 3f;
                        mainModule43.simulationSpeed = 3f;
                        mainModule44.simulationSpeed = 3f;
                        mainModuleTrail41.simulationSpeed = 3f;
                        mainModuleTrail42.simulationSpeed = 3f;
                        mainModuleTrail43.simulationSpeed = 3f;
                        mainModuleTrail44.simulationSpeed = 3f;
                        break;
                    case 3:
                        mainModule41.simulationSpeed = 4f;
                        mainModule42.simulationSpeed = 4f;
                        mainModule43.simulationSpeed = 4f;
                        mainModule44.simulationSpeed = 4f;
                        mainModuleTrail41.simulationSpeed = 4f;
                        mainModuleTrail42.simulationSpeed = 4f;
                        mainModuleTrail43.simulationSpeed = 4f;
                        mainModuleTrail44.simulationSpeed = 4f;
                        break;
                }
                
                switch (explosion)
                {
                    case 1:
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-1").GetComponent<NormalAttack>().Explosion = 1;
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-2").GetComponent<NormalAttack>().Explosion = 1;
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-3").GetComponent<NormalAttack>().Explosion = 1;
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-4").GetComponent<NormalAttack>().Explosion = 1;
                        break;
                    case 2:
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-1").GetComponent<NormalAttack>().Explosion = 2;
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-2").GetComponent<NormalAttack>().Explosion = 2;
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-3").GetComponent<NormalAttack>().Explosion = 2;
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-4").GetComponent<NormalAttack>().Explosion = 2;
                        break;
                    case 3:
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-1").GetComponent<NormalAttack>().Explosion = 3;
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-2").GetComponent<NormalAttack>().Explosion = 3;
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-3").GetComponent<NormalAttack>().Explosion = 3;
                        SkillController.S.NormalAttack4.transform.Find("NormalAttack-4").GetComponent<NormalAttack>().Explosion = 3;
                        break;
                }
                break;

        }

    }
    
}
