using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayerAttribute 
{
   public static WeaponType CurrentWeaponType= WeaponType.Primary; //当前武器类型
   public static bool IsGame = false;
   public static int CurrentHp=100;

   public static int BloodEnergy
   {
       get => PlayerData.S.bloodEnergy;
       set => PlayerData.S.bloodEnergy = value;
   }
   //等级相关
   public static int Level
   {
         get => PlayerData.S.level;
         set => PlayerData.S.level = value;
   }

   public static int Exp
   {
         get => PlayerData.S.exp;
         set => PlayerData.S.exp = value;
   }
   public static Dictionary<int,int> ExpDic=new Dictionary<int,int>()
   {
         {1,100 },
         {2,200 },
         {3,300 },
         {4,400 },
         {5,500 },
         {6,600 },
         {7,700 },
         {8,800 },
         {9,900 },
         {10,1000 },
         {11,1200 },
         {12,1400 },
         {13,1600 },
         {14,1800 },
         {15,2000 },
         {16,2200 },
         {17,2400 },
         {18,2600 },
         {19,2800 },
         {20,3000 },
         {21,3200 },
         {22,3400 },
         {23,3600 },
         {24,3800 },
         {25,4000 },
         {26,4200 },
         {27,4400 },
         {28,46800 },
         {29,4800 },
         {30,5000 },
   };

   public static int GameLevel
   {
            get => PlayerData.S.maxGameLevel;
            set => PlayerData.S.maxGameLevel = value;
   }
   
   //人物属性,默认属性
   public static int PlayerMaxHp
   {
       get => PlayerInfoConfig.GetPlayerMaxHp();
   }

   public static int PlayerDamage
   {
       get => PlayerInfoConfig.GetPlayerAttack();
   }
   public static int PlayerMoveSpeed=3;
   public static int PlayerAttackSpeed=0;
   public static int PlayerCRIT=0;
   public static int PlayerCRITDamage=0;
   public static int PlayerBloodSuck=0;
   public static int PlayerDefense
   {
       get => PlayerInfoConfig.GetPlayerDenfence();
   }
   public static int PlayerGoodFortune=0;
   
   //装备属性
   public static int EquipMaxHp=0;
   public static int EquipDamage=0;
   public static int EquipMoveSpeed=0;
   public static int EquipAttackSpeed=0;
   public static int EquipCRIT=0;
   public static int EquipCRITDamage=0;
   public static int EquipBloodSuck=0;
   public static int EquipDefense=0;
   public static int EquipGoodFortune=0;
   
   //总属性
   public static int TotalMaxHp => PlayerMaxHp + EquipMaxHp;
   public static int TotalDamage=> PlayerDamage + EquipDamage;
   public static int TotalMoveSpeed => PlayerMoveSpeed + EquipMoveSpeed;
   public static int TotalAttackSpeed => PlayerAttackSpeed + EquipAttackSpeed;
   public static int TotalCRIT => PlayerCRIT + EquipCRIT;
   public static int TotalCRITDamage => PlayerCRITDamage + EquipCRITDamage;
   public static int TotalBloodSuck => PlayerBloodSuck + EquipBloodSuck;
   public static int TotalDefense => PlayerDefense + EquipDefense;
   public static int TotalGoodFortune => PlayerGoodFortune + EquipGoodFortune;
}
