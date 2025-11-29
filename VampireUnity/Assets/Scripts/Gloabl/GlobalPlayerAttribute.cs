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
   public static int EquipMaxHp
   {
       get => GetEquipMaxHp();
   }

   public static int EquipDamage
   {
       get => GetEquipDamage();
   }

   public static int EquipMoveSpeed
   {
       get => GetEquipMoveSpeed();
   }
   public static int EquipAttackSpeed=0;

   public static int EquipCRIT
   {
       get => GetEquipCRIT();
   }

   public static int EquipCRITDamage
   {
       get => GetEquipCRITDamage();
   }
   public static int EquipBloodSuck=0;

   public static int EquipDefense
   {
       get => GetEquipDefense();
   }
   public static int EquipGoodFortune=0;
   
   //总属性
   public static int TotalMaxHp => PlayerMaxHp + EquipMaxHp;
   public static int TotalDamage=> PlayerDamage + EquipDamage;
   public static int TotalMoveSpeed => PlayerMoveSpeed + EquipMoveSpeed;
   //public static int TotalAttackSpeed => PlayerAttackSpeed + EquipAttackSpeed;
   public static int TotalCRIT => PlayerCRIT + EquipCRIT;
   public static int TotalCRITDamage => PlayerCRITDamage + EquipCRITDamage;
   //public static int TotalBloodSuck => PlayerBloodSuck + EquipBloodSuck;
   public static int TotalDefense => PlayerDefense + EquipDefense;
   //public static int TotalGoodFortune => PlayerGoodFortune + EquipGoodFortune;
   
   
   
   public static int GetEquipMaxHp()
   {
       int hp = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           hp+=cloak.HP;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           hp+=cloth.HP;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           hp+=shoe.HP;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           hp+=ring.HP;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           hp+=necklace.HP;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           hp+=helmet.HP;
       }

       return hp;
   }
   
   
   public static int GetEquipDamage()
   {
       int Damage = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           Damage+=cloak.Damage;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           Damage+=cloth.Damage;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           Damage+=shoe.Damage;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           Damage+=ring.Damage;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           Damage+=necklace.Damage;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           Damage+=helmet.Damage;
       }

       return Damage;
   }
   
   public static int GetEquipMoveSpeed()
   {
       int MoveSpeed = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           MoveSpeed+=cloak.MoveSpeed;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           MoveSpeed+=cloth.MoveSpeed;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           MoveSpeed+=shoe.MoveSpeed;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           MoveSpeed+=ring.MoveSpeed;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           MoveSpeed+=necklace.MoveSpeed;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           MoveSpeed+=helmet.MoveSpeed;
       }

       return MoveSpeed;
   }
   
   public static int GetEquipCRIT()
   {
       int CRIT = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           CRIT+=cloak.CRIT;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           CRIT+=cloth.CRIT;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           CRIT+=shoe.CRIT;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           CRIT+=ring.CRIT;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           CRIT+=necklace.CRIT;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           CRIT+=helmet.CRIT;
       }

       return CRIT;
   }
   
   
   public static int GetEquipCRITDamage()
   {
       int CRITDamage = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           CRITDamage+=cloak.CRITDamage;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           CRITDamage+=cloth.CRITDamage;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           CRITDamage+=shoe.CRITDamage;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           CRITDamage+=ring.CRITDamage;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           CRITDamage+=necklace.CRITDamage;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           CRITDamage+=helmet.CRITDamage;
       }

       return CRITDamage;
   }
   
   
   public static int GetEquipDefense()
   {
       int Defense = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           Defense+=cloak.Defense;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           Defense+=cloth.Defense;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           Defense+=shoe.Defense;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           Defense+=ring.Defense;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           Defense+=necklace.Defense;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           Defense+=helmet.Defense;
       }

       return Defense;
   }
}
