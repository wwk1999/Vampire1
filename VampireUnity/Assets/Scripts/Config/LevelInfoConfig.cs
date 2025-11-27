using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfoConfig 
{
    public static bool IsOneGame = true; //第一次游戏
    public static int CurrentGameLevel = 1; // 当前游戏关卡

    public static int MaxGameLevel
    {
        get=>PlayerData.S.maxGameLevel;
        set=>PlayerData.S.maxGameLevel=value;
    }
    public static LevelType CurrentGameLevelType = LevelType.Normal;
    public static List<Sprite> LevelDiaoLuo1 = new List<Sprite>();//关卡1掉落列表
    public static List<Sprite> LevelDiaoLuo2 = new List<Sprite>();//关卡2掉落列表
    public static List<Sprite> LevelDiaoLuo3 = new List<Sprite>();//关卡3掉落列表
    
    public static int[] LevelMonsterCount= new int[100];//关卡敌人数量

    public static List<MonsterBase> LevelMonster = new List<MonsterBase>();//关卡敌人列表
   
    public static void InitGameLevel()
    {
        LevelMonsterCount[0] = 0;
        LevelMonsterCount[1] = 50;
        LevelMonsterCount[2] = 100;
        LevelMonsterCount[3] = 100;
        LevelMonsterCount[4] = 50;
        LevelMonsterCount[5] = 100;
        LevelMonsterCount[6] = 100;
        LevelMonsterCount[7] = 50;
        LevelMonsterCount[8] = 100;
        LevelMonsterCount[9] = 100;
        LevelMonsterCount[10] = 50;
        LevelMonsterCount[11] = 100;
        LevelMonsterCount[12] = 100;
        LevelMonsterCount[13] = 50;
        LevelMonsterCount[14] = 100;
        LevelMonsterCount[15] = 100;
        LevelMonsterCount[16] = 50;
        LevelMonsterCount[17] = 100;
        LevelMonsterCount[18] = 100;
        LevelMonsterCount[19] = 50;
        LevelMonsterCount[20] = 100;
        LevelMonsterCount[21] = 100;
        if (IsOneGame)
        {
            LevelDiaoLuo1.Add(ResourcesConfig.PrimaryCloak);
            LevelDiaoLuo1.Add(ResourcesConfig.PrimaryCloth);
            LevelDiaoLuo1.Add(ResourcesConfig.PrimaryShoe);
            LevelDiaoLuo1.Add(ResourcesConfig.PrimaryHelmet);
            LevelDiaoLuo1.Add(ResourcesConfig.PrimaryNecklace);
            LevelDiaoLuo1.Add(ResourcesConfig.PrimaryRing);
        }

        if (IsOneGame)
        {
            LevelDiaoLuo2.Add(ResourcesConfig.PrimaryCloak);
            LevelDiaoLuo2.Add(ResourcesConfig.PrimaryCloth);
            LevelDiaoLuo2.Add(ResourcesConfig.PrimaryShoe);
            LevelDiaoLuo2.Add(ResourcesConfig.PrimaryHelmet);
            LevelDiaoLuo2.Add(ResourcesConfig.PrimaryNecklace);
            LevelDiaoLuo2.Add(ResourcesConfig.PrimaryRing);

            LevelDiaoLuo2.Add(ResourcesConfig.WhiteDivision);
            LevelDiaoLuo2.Add(ResourcesConfig.WhiteExplosion);
            LevelDiaoLuo2.Add(ResourcesConfig.WhiteDuration);
            LevelDiaoLuo2.Add(ResourcesConfig.WhiteScale);
            LevelDiaoLuo2.Add(ResourcesConfig.WhitePenetrate);
            LevelDiaoLuo2.Add(ResourcesConfig.WhiteExtremeSpeed);
        }
        
        if (IsOneGame)
        {
            LevelDiaoLuo3.Add(ResourcesConfig.PrimaryCloak);
            LevelDiaoLuo3.Add(ResourcesConfig.PrimaryCloth);
            LevelDiaoLuo3.Add(ResourcesConfig.PrimaryShoe);
            LevelDiaoLuo3.Add(ResourcesConfig.PrimaryHelmet);
            LevelDiaoLuo3.Add(ResourcesConfig.PrimaryNecklace);
            LevelDiaoLuo3.Add(ResourcesConfig.PrimaryRing);

            LevelDiaoLuo3.Add(ResourcesConfig.TreeManCloak);
            LevelDiaoLuo3.Add(ResourcesConfig.TreeManCloth);
            LevelDiaoLuo3.Add(ResourcesConfig.TreeManShoe);
            LevelDiaoLuo3.Add(ResourcesConfig.TreeManHelmet);
            LevelDiaoLuo3.Add(ResourcesConfig.TreeManNecklace);
            LevelDiaoLuo3.Add(ResourcesConfig.TreeManRing);

            LevelDiaoLuo3.Add(ResourcesConfig.WhiteDivision);
            LevelDiaoLuo3.Add(ResourcesConfig.WhiteExplosion);
            LevelDiaoLuo3.Add(ResourcesConfig.WhiteDuration);
            LevelDiaoLuo3.Add(ResourcesConfig.WhiteScale);
            LevelDiaoLuo3.Add(ResourcesConfig.WhitePenetrate);
            LevelDiaoLuo3.Add(ResourcesConfig.WhiteExtremeSpeed);
        }
    }
   public static LevelInfoItem LevelInfoItem1= new LevelInfoItem
   {
       Level = 1,
       LevelType = LevelType.Normal,
       MonsterIconList = new List<Sprite>(),
       DiaoLuoIconList = new List<Sprite>(),
       DiaoLuoNameList = new List<string>()
   };
    public static LevelInfoItem LevelInfoItem2 = new LevelInfoItem
    {
         Level = 2,
         LevelType = LevelType.Elite,
         MonsterIconList = new List<Sprite>(),
         DiaoLuoIconList = new List<Sprite>(),
            DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem3 = new LevelInfoItem
    {
         Level = 3,
         LevelType = LevelType.Boss,
         MonsterIconList = new List<Sprite>(),
         DiaoLuoIconList = new List<Sprite>(),
            DiaoLuoNameList = new List<string>()
    };

    public static LevelInfoItem LevelInfoItem4= new LevelInfoItem
    {
        Level = 4,
        LevelType = LevelType.Normal,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem5= new LevelInfoItem
    {
        Level = 5,
        LevelType = LevelType.Elite,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem6= new LevelInfoItem
    {
        Level = 6,
        LevelType = LevelType.Boss,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem7= new LevelInfoItem
    {
        Level = 7,
        LevelType = LevelType.Normal,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem8= new LevelInfoItem
    {
        Level = 8,
        LevelType = LevelType.Elite,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static LevelInfoItem LevelInfoItem9= new LevelInfoItem
    {
        Level = 9,
        LevelType = LevelType.Boss,
        MonsterIconList = new List<Sprite>(),
        DiaoLuoIconList = new List<Sprite>(),
        DiaoLuoNameList = new List<string>()
    };
    public static void init()
    {
        //关卡1
        if (IsOneGame)
        {
            LevelInfoItem1.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem1.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem1.MonsterIconList.Add(ResourcesConfig.Spidericon);

            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloak);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloth);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryShoe);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryHelmet);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryNecklace);
            LevelInfoItem1.DiaoLuoIconList.Add(ResourcesConfig.PrimaryRing);

            LevelInfoItem1.DiaoLuoNameList.Add("新手披风");
            LevelInfoItem1.DiaoLuoNameList.Add("新手衣服");
            LevelInfoItem1.DiaoLuoNameList.Add("新手鞋子");
            LevelInfoItem1.DiaoLuoNameList.Add("新手头盔");
            LevelInfoItem1.DiaoLuoNameList.Add("新手项链");
            LevelInfoItem1.DiaoLuoNameList.Add("新手戒指");

            LevelInfoItem1.LevelInfoDir = true;
            LevelInfoItem1.LevelInfoPos = new Vector2(374, -407);
            LevelInfoItem1.LoopScrollPos = new Vector2(-334, -34);

            //关卡2
            LevelInfoItem2.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem2.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem2.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem2.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);

            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloak);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloth);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryShoe);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryHelmet);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryNecklace);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.PrimaryRing);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteDivision);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteExplosion);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteDuration);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteScale);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhitePenetrate);
            LevelInfoItem2.DiaoLuoIconList.Add(ResourcesConfig.WhiteExtremeSpeed);

            LevelInfoItem2.DiaoLuoNameList.Add("新手披风");
            LevelInfoItem2.DiaoLuoNameList.Add("新手衣服");
            LevelInfoItem2.DiaoLuoNameList.Add("新手鞋子");
            LevelInfoItem2.DiaoLuoNameList.Add("新手头盔");
            LevelInfoItem2.DiaoLuoNameList.Add("新手项链");
            LevelInfoItem2.DiaoLuoNameList.Add("新手戒指");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：分裂");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：爆炸");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：持续");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：缩放");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：穿透");
            LevelInfoItem2.DiaoLuoNameList.Add("初级源石：极速");

            LevelInfoItem2.LevelInfoDir = true;
            LevelInfoItem2.LevelInfoPos = new Vector2(374, -200);
            LevelInfoItem2.LoopScrollPos = new Vector2(-335, 169);

            //关卡3
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem3.MonsterIconList.Add(ResourcesConfig.BossTreeManIcon);
            
            
            
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteDivision);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteExplosion);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteDuration);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteScale);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhitePenetrate);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.WhiteExtremeSpeed);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloak);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryCloth);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryShoe);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryHelmet);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryNecklace);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.PrimaryRing);
          
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManCloak);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManCloth);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManShoe);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManHelmet);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManNecklace);
            LevelInfoItem3.DiaoLuoIconList.Add(ResourcesConfig.TreeManRing);

            LevelInfoItem3.DiaoLuoNameList.Add("新手披风");
            LevelInfoItem3.DiaoLuoNameList.Add("新手衣服");
            LevelInfoItem3.DiaoLuoNameList.Add("新手鞋子");
            LevelInfoItem3.DiaoLuoNameList.Add("新手头盔");
            LevelInfoItem3.DiaoLuoNameList.Add("新手项链");
            LevelInfoItem3.DiaoLuoNameList.Add("新手戒指");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：分裂");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：爆炸");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：持续");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：缩放");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：穿透");
            LevelInfoItem3.DiaoLuoNameList.Add("初级源石：极速");
            LevelInfoItem3.DiaoLuoNameList.Add("树人披风");
            LevelInfoItem3.DiaoLuoNameList.Add("树人衣服");
            LevelInfoItem3.DiaoLuoNameList.Add("树人鞋子");
            LevelInfoItem3.DiaoLuoNameList.Add("树人头盔");
            LevelInfoItem3.DiaoLuoNameList.Add("树人项链");
            LevelInfoItem3.DiaoLuoNameList.Add("树人戒指");

            LevelInfoItem3.LevelInfoDir = false;
            LevelInfoItem3.LevelInfoPos = new Vector2(-22, -3);
            LevelInfoItem3.LoopScrollPos = new Vector2(-597, 364);

            //关卡4
            LevelInfoItem4.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem4.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem4.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem4.LevelInfoDir = false;
            LevelInfoItem4.LevelInfoPos = new Vector2(441, -73);
            
            
            //关卡5
            LevelInfoItem5.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem5.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem5.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem5.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem5.LevelInfoDir = true;
            LevelInfoItem5.LevelInfoPos = new Vector2(1220, -161);
            
            //关卡6
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem6.MonsterIconList.Add(ResourcesConfig.BossTreeManIcon);
            LevelInfoItem6.LevelInfoDir = true;
            LevelInfoItem6.LevelInfoPos = new Vector2(715, -400);
            
            
            //关卡7
            LevelInfoItem7.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem7.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem7.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem7.LevelInfoDir = false;
            LevelInfoItem7.LevelInfoPos = new Vector2(468, -365);
            
            
            //关卡8
            LevelInfoItem8.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem8.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem8.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem8.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem8.LevelInfoDir = false;
            LevelInfoItem8.LevelInfoPos = new Vector2(618, -547);
            
            //关卡9
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.SnotIcon);
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.BatIcon);
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.Spidericon);
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.EliteBeeIcon);
            LevelInfoItem9.MonsterIconList.Add(ResourcesConfig.BossTreeManIcon);
            LevelInfoItem9.LevelInfoDir = false;
            LevelInfoItem9.LevelInfoPos = new Vector2(886, -501);
        }
    }
}
