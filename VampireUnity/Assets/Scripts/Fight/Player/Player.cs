using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public enum PlayerState
{
    None,
    Idle,
    Walk,
    Attack,
    Hurt,
    Dead
}
public enum WeaponType
{
    None,
    Primary,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine
}
public class Player : MonoBehaviour
{
    //public Animator animator;
    public WeaponType weaponType = WeaponType.Primary;
    public GunBase currentGun;
    private float _gunDistance = 0.3f;
    public GameObject iceBall;
    public SkeletonAnimation playerSkeleton;
    public PlayerState playerState= PlayerState.None;
    public bool isAttack=false;
    public Slider hpSlider;
    public Slider exSlider;
    public Text levelText;
    public float size = 0.28f;
    [NonSerialized] public bool IsWuDi = false;//红闪的时候无敌

    public Animation levelUpAnim;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI denfenseText;




    private void Awake()
    {
        currentGun = Instantiate(Resources.Load<GameObject>("Prefabs/Gun/Pistol").GetComponent<GunBase>(),transform);
        playerSkeleton.AnimationState.Complete += OnAnimationComplete;
        ObserverModuleManager.S.RegisterEvent(ConstKeys.LevelUpAnim, PlayLevelUpAnim);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent(ConstKeys.LevelUpAnim, PlayLevelUpAnim);
    }

    public void PlayLevelUpAnim(object obj)
    {
        levelUpAnim.gameObject.SetActive(true);
        attackText.text=PlayerInfoConfig.AttackDic[GlobalPlayerAttribute.Level].ToString();
        hpText.text=PlayerInfoConfig.HpDic[GlobalPlayerAttribute.Level].ToString();
        denfenseText.text=PlayerInfoConfig.DenfenseDic[GlobalPlayerAttribute.Level].ToString();
        levelUpAnim.Play("LevelUpTextAnim");
    }
    
    public void TempChangePlayerMoveSpeed(int speed,float time)
    {
        int t = GlobalPlayerAttribute.PlayerMoveSpeed;
        GlobalPlayerAttribute.PlayerMoveSpeed = speed;
        StartCoroutine(ResumeSpeed(time,t));
    }
    //携程等待1s
    private IEnumerator ResumeSpeed(float seconds,int speed)
    {
        yield return new WaitForSeconds(seconds);
        GlobalPlayerAttribute.PlayerMoveSpeed = speed;

    }

    public void OnAnimationComplete(Spine.TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "attack")
        {
            isAttack = false;
            SkillController.S.ShotBulletInvoke();
            GameController.S.gamePlayer.playerState= PlayerState.None;
        }
        if (trackEntry.Animation.Name == "hit")
        {
            GameController.S.gamePlayer.playerState= PlayerState.None;
        }
    }
    /// <summary>
    /// 主角动画
    /// </summary>
    public void PlayerMoveAnimation()
    {
        //获得输入
        Vector2 joydir = FightBGController.S.joystick.input.normalized;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (!isAttack)
        {
            if (joydir == Vector2.zero)
            {
                if (horizontal == 0 && vertical == 0)
                {
                    if (playerState != PlayerState.Idle)
                    {
                        playerSkeleton.AnimationState.SetAnimation(0, "idle", true);
                    }

                    //player播放idle动画，player是spine动画
                    playerState = PlayerState.Idle;
                }
                else
                {
                    if (playerState != PlayerState.Walk)
                    {
                        playerSkeleton.AnimationState.SetAnimation(0, "walk", true);
                    }

                    playerState = PlayerState.Walk;
                }
            }
            else
            {
                if (playerState != PlayerState.Walk)
                {
                    playerSkeleton.AnimationState.SetAnimation(0, "walk", true);
                }

                playerState = PlayerState.Walk;
            }
        }
    }
    
    /// <summary>
    /// 主角移动
    /// </summary>
    public void PlayerMove()
    {
        //获得输入
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 joydir = FightBGController.S.joystick.input.normalized;
        if (joydir.x > 0)
        {
           // spriteRenderer.flipX = false;
           playerSkeleton.Skeleton.FlipX = false;
        } else if (joydir.x < 0)
        {
            playerSkeleton.Skeleton.FlipX = true;
        }
        if (joydir == Vector2.zero)//设置pc和安卓的移动
        {
            if(horizontal>0)
            {
                playerSkeleton.Skeleton.FlipX = false;
            }
            else if(horizontal<0)
            {
                playerSkeleton.Skeleton.FlipX = true;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal, vertical).normalized * GlobalPlayerAttribute.PlayerMoveSpeed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = joydir * GlobalPlayerAttribute.PlayerMoveSpeed;
        }
        
        
        // //刚体移动角色
        // Vector3 direction = new Vector3(horizontal, vertical, 0);
        // //刚体移动
        // GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * GlobalPlayerAttribute.PlayerMoveSpeed;
        
        // //限制角色在屏幕内
        // if (transform.position.x < -16f)
        //     transform.position = new Vector3(-16f, transform.position.y, transform.position.z);
        // if (transform.position.x > 16f)
        //     transform.position = new Vector3(16f, transform.position.y, transform.position.z);
        // if (transform.position.y < -8.5f)
        //     transform.position = new Vector3(transform.position.x, -8.5f, transform.position.z);
        // if (transform.position.y > 8.5f)
        //     transform.position = new Vector3(transform.position.x, 8.5f, transform.position.z);
            
    }
    
    
    public void SetGunRotate(Vector3 nearMonsterPosition)
    {
        //主角朝最近怪物的方向
        Vector3 direction = (nearMonsterPosition - transform.position).normalized;
        //设置枪的位置
        //currentGun.transform.position = transform.position + direction * _gunDistance;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //如果角度在90-270之间
        if (angle > 90 || angle <-90)
        {
            currentGun.transform.localPosition = new Vector3(-2.54f,
                currentGun.transform.localPosition.y, currentGun.transform.localPosition.z);

            //currentGun.gunSpriteRender.flipY = true;
        }
        else
        {
            currentGun.transform.localPosition = new Vector3(2.54f,
                currentGun.transform.localPosition.y, currentGun.transform.localPosition.z);        
        }
        currentGun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 主角受伤
    /// </summary>
    /// <param name="damage"></param>
    public void PlayerHurt(int damage)
    {
        if (IsWuDi)
            return;
        //打印调用这个方法的脚本name
        Debug.Log("PlayerHurt被调用，来自脚本：" + new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().DeclaringType.Name);
        AudioController.S.PlayPlayerHurt();
        CameraContraller.S.CameraShake(0.1f, 0.005f);
        var playerhit = FightBGController.S.PlayerHitQueue.Dequeue();
        playerhit.gameObject.SetActive(true);
        playerSkeleton.AnimationState.SetAnimation(0, "hit", false);
    }

    private void Update()
    {
        //主角操作
        PlayerMove();
        PlayerMoveAnimation();
//        Debug.Log("枪的方向：" + GameController.S.nearMonsterPosition);
        SetGunRotate(GameController.S.nearMonsterPosition);
    }
}
