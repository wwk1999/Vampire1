using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : XSingleton<AudioController>
{
    //AudioSource
    [NonSerialized]public AudioSource BGAudioSource;
    [NonSerialized]public AudioSource MonsterAudioSource;
    [NonSerialized]public AudioSource PlayerAudioSource;
    [NonSerialized]public AudioSource UIAudioSource;


    //UIAudioClip
    [NonSerialized]public AudioClip NormalClickAudioClip;
    
    //PlayerAudioClip
    [NonSerialized]public AudioClip NormalAttack1;
    [NonSerialized]public AudioClip Boom; 
    [NonSerialized]public AudioClip Defeat;
    [NonSerialized]public AudioClip IceArrow;
    [NonSerialized]public AudioClip IceBall;
    [NonSerialized]public AudioClip IceEx;
    [NonSerialized]public AudioClip NormalAttack2;
    [NonSerialized]public AudioClip LevelUp;
    [NonSerialized]public AudioClip PlayerHurt;
    
    //MonsterAudioClip
    [NonSerialized]public AudioClip BatHit;
    [NonSerialized]public AudioClip BeeDie; 
    [NonSerialized]public AudioClip BeeSkill;
    [NonSerialized]public AudioClip BoosJump;
    [NonSerialized]public AudioClip BossAppear;
    [NonSerialized]public AudioClip BossDie;
    [NonSerialized]public AudioClip BossFireShotSkill;
    [NonSerialized]public AudioClip BossFireSkill;
    [NonSerialized]public AudioClip SnotHit;
    [NonSerialized]public AudioClip SpiderHit;
    [NonSerialized]public AudioClip Warning; 
    [NonSerialized]public AudioClip EliteBeeHit; 
    [NonSerialized]public AudioClip SnotDie;
    [NonSerialized]public AudioClip BatDie; 
    [NonSerialized]public AudioClip SpiderDie; 
    [NonSerialized]public AudioClip EliteBeeDie; 

    
    //AudioMixer
    [NonSerialized]public AudioMixer AudioMixer;

    public void PlayNormalAttack1()
    {
        PlayerAudioSource.PlayOneShot(NormalAttack1);
    }
    public void PlayBoom()
    {
        PlayerAudioSource.PlayOneShot(Boom);
    }
    public void PlayDefeat()
    {
        PlayerAudioSource.PlayOneShot(Defeat);
    }
    public void PlayIceArrow()
    {
        PlayerAudioSource.PlayOneShot(IceArrow);
    }
    public void PlayIceBall()
    {
        PlayerAudioSource.PlayOneShot(IceBall);
    }
    public void PlayIceEx()
    {
        PlayerAudioSource.PlayOneShot(IceEx);
    }
    public void PlayNormalAttack2()
    {
        PlayerAudioSource.PlayOneShot(NormalAttack2);
    }
    public void PlayLevelUp()
    {
        PlayerAudioSource.PlayOneShot(LevelUp);
    }
    public void PlayPlayerHurt()
    {
        PlayerAudioSource.PlayOneShot(PlayerHurt);
    }
    
    public void PlayBatHit()
    {
        MonsterAudioSource.PlayOneShot(BatHit);
    }
    public void PlayBeeDie()
    {
        MonsterAudioSource.PlayOneShot(BeeDie);
    }
    public void PlayBeeSkill()
    {
        MonsterAudioSource.PlayOneShot(BeeSkill);
    }
    public void PlayBoosJump()
    {
        MonsterAudioSource.PlayOneShot(BoosJump);
    }
    public void PlayBossAppear()
    {
        MonsterAudioSource.PlayOneShot(BossAppear);
    }
    public void PlayBossDie()
    {
        MonsterAudioSource.PlayOneShot(BossDie);
    }
    public void PlayBossFireShotSkill()
    {
        MonsterAudioSource.PlayOneShot(BossFireShotSkill);
    }
    public void PlayBossFireSkill()
    {
        MonsterAudioSource.PlayOneShot(BossFireSkill);
    }
    public void PlaySnotHit()
    {
        MonsterAudioSource.PlayOneShot(SnotHit);
    }
    public void PlaySpiderHit()
    {
        MonsterAudioSource.PlayOneShot(SpiderHit);
    }
    public void PlayWarning()
    {
        MonsterAudioSource.PlayOneShot(Warning);
    }
    public void PlayEliteBeeHit()
    {
        MonsterAudioSource.PlayOneShot(EliteBeeHit);
    }
    public void PlaySnotDie()
    {
        MonsterAudioSource.PlayOneShot(SnotDie);
    }
    public void PlaySpiderDie()
    {
        MonsterAudioSource.PlayOneShot(SpiderDie);
    }
    public void PlayBatDie()
    {
        MonsterAudioSource.PlayOneShot(BatDie);
    }
    public void PlayEliteBeeDie()
    {
        MonsterAudioSource.PlayOneShot(EliteBeeDie);
    }
    

    private void Awake()
    {
        //创建3个空的子物体
        GameObject bgAudioObject = new GameObject("BGAudioSource");
        bgAudioObject.transform.SetParent(transform);
        GameObject monsterAudioObject = new GameObject("MonsterAudioSource");
        monsterAudioObject.transform.SetParent(transform);
        GameObject playerAudioObject = new GameObject("PlayerAudioSource");
        playerAudioObject.transform.SetParent(transform);
        GameObject uiAudioObject = new GameObject("UIAudioSource");
        uiAudioObject.transform.SetParent(transform);
        
        
        //添加AudioSource组件
        bgAudioObject.AddComponent<AudioSource>();
        BGAudioSource=bgAudioObject.GetComponent<AudioSource>();
        BGAudioSource.clip = Resources.Load<AudioClip>("Audio/BG/UIBG");
        BGAudioSource.loop = true;
        
        monsterAudioObject.AddComponent<AudioSource>();
        MonsterAudioSource=monsterAudioObject.GetComponent<AudioSource>();
        
        playerAudioObject.AddComponent<AudioSource>();
        PlayerAudioSource=playerAudioObject.GetComponent<AudioSource>();
        
        uiAudioObject.AddComponent<AudioSource>();
        UIAudioSource=uiAudioObject.GetComponent<AudioSource>();
       

        //音频
        NormalClickAudioClip = Resources.Load<AudioClip>("Audio/UI/NormalClick");
        if (NormalClickAudioClip == null)
        {
            Debug.LogError("NormalClickAudioClip is not found in Resources.");
        }
        NormalAttack1 = Resources.Load<AudioClip>("Audio/Player/NormalAttack1");
        Boom = Resources.Load<AudioClip>("Audio/Player/Boom");
        IceArrow = Resources.Load<AudioClip>("Audio/Player/IceArrow");
        IceBall = Resources.Load<AudioClip>("Audio/Player/IceBall");
        IceEx = Resources.Load<AudioClip>("Audio/Player/IceEx");
        PlayerHurt = Resources.Load<AudioClip>("Audio/Player/PlayerHurt");
        NormalAttack2 = Resources.Load<AudioClip>("Audio/Player/NormalAttack2");
        LevelUp = Resources.Load<AudioClip>("Audio/Player/LevelUp");
        Defeat = Resources.Load<AudioClip>("Audio/Player/Defeat");
        
        BatHit= Resources.Load<AudioClip>("Audio/Monster/BatHit");
        BeeDie= Resources.Load<AudioClip>("Audio/Monster/BeeDie");
        BeeSkill= Resources.Load<AudioClip>("Audio/Monster/BeeSkill");
        BoosJump= Resources.Load<AudioClip>("Audio/Monster/BoosJump");
        BossAppear= Resources.Load<AudioClip>("Audio/Monster/BossAppear");
        BossDie= Resources.Load<AudioClip>("Audio/Monster/BossDie");
        BossFireShotSkill= Resources.Load<AudioClip>("Audio/Monster/BossFireShotSkill");
        BossFireSkill= Resources.Load<AudioClip>("Audio/Monster/BossFireSkill");
        SnotHit= Resources.Load<AudioClip>("Audio/Monster/SnotHit");
        SpiderHit= Resources.Load<AudioClip>("Audio/Monster/SpiderHit");
        Warning= Resources.Load<AudioClip>("Audio/Monster/Warning");
        EliteBeeHit= Resources.Load<AudioClip>("Audio/Monster/EliteBeeHit");
        SnotDie= Resources.Load<AudioClip>("Audio/Monster/SnotDie");
        BatDie= Resources.Load<AudioClip>("Audio/Monster/BatDie");
        SpiderDie= Resources.Load<AudioClip>("Audio/Monster/SpiderDie");
        EliteBeeDie= Resources.Load<AudioClip>("Audio/Monster/EliteBeeDie");




        
        
        //混音器设置
        AudioMixer=Resources.Load<AudioMixer>("Audio/AudioMixer");
        // 找到 Audio Mixer 的 Group
        AudioMixerGroup bgMixerGroup = AudioMixer.FindMatchingGroups("BGSound")[0];
        if (bgMixerGroup == null)
        {
            Debug.LogError("BGSound group为空.");
        }
        else
        {
            // 将 BGAudioSource 的输出设置为 BGSound 组
            BGAudioSource.outputAudioMixerGroup = bgMixerGroup;
        }
        
        AudioMixerGroup monsterMixerGroup = AudioMixer.FindMatchingGroups("MonsterSound")[0];
        if (monsterMixerGroup == null)
        {
            Debug.LogError("monsterMixerGroup group为空");
        }
        else
        {
            // 将 BGAudioSource 的输出设置为 BGSound 组
            MonsterAudioSource.outputAudioMixerGroup = monsterMixerGroup;
        }
        
        AudioMixerGroup playerMixerGroup = AudioMixer.FindMatchingGroups("PlayerSound")[0];
        if (playerMixerGroup == null)
        {
            Debug.LogError("playerMixerGroup group为空");
        }
        else
        {
            // 将 BGAudioSource 的输出设置为 BGSound 组
            PlayerAudioSource.outputAudioMixerGroup = playerMixerGroup;
        }
        
        AudioMixerGroup uiMixerGroup = AudioMixer.FindMatchingGroups("UISound")[0];
        if (uiMixerGroup == null)
        {
            Debug.LogError("uiMixerGroup group为空");
        }
        else
        {
            // 将 BGAudioSource 的输出设置为 BGSound 组
            UIAudioSource.outputAudioMixerGroup = uiMixerGroup;
        }
        
    }
    public void UIPlayNormalClick()
    {
        //播放NormalClickAudioClip
        if (NormalClickAudioClip != null && BGAudioSource != null)
        {
            UIAudioSource.PlayOneShot(NormalClickAudioClip);
        }
        else
        {
            Debug.LogWarning("NormalClickAudioClip or AudioSource is not set.");
        }
    }
}
