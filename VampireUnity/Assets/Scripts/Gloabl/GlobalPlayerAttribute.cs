using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayerAttribute 
{
   public static WeaponType CurrentWeaponType= WeaponType.Primary; //当前武器类型
   public static bool IsGame = false;
   public static int CurrentHp=100;

   public static int BloodEnergy;//元灵数量
   //等级相关
   public static int Level=1;
   public static int Exp=0;
   public static Dictionary<int,int> ExpDic=new Dictionary<int,int>();
   public static int GameLevel=1; //游戏关卡
   
   //人物属性,默认属性
   public static int PlayerMaxHp=100;
   public static int PlayerDamage=10;
   public static int PlayerMoveSpeed=3;
   public static int PlayerAttackSpeed=0;
   public static int PlayerCRIT=0;
   public static int PlayerCRITDamage=0;
   public static int PlayerBloodSuck=0;
   public static int PlayerDenfense=0;
   public static int PlayerGoodFortune=0;
   
   //装备属性
   public static int EquipMaxHp=0;
   public static int EquipDamage=0;
   public static int EquipMoveSpeed=0;
   public static int EquipAttackSpeed=0;
   public static int EquipCRIT=0;
   public static int EquipCRITDamage=0;
   public static int EquipBloodSuck=0;
   public static int EquipDenfense=0;
   public static int EquipGoodFortune=0;
   
   //总属性
   public static int TotalMaxHp => PlayerMaxHp + EquipMaxHp;
   public static int TotalDamage=> PlayerDamage + EquipDamage;
   public static int TotalMoveSpeed => PlayerMoveSpeed + EquipMoveSpeed;
   public static int TotalAttackSpeed => PlayerAttackSpeed + EquipAttackSpeed;
   public static int TotalCRIT => PlayerCRIT + EquipCRIT;
   public static int TotalCRITDamage => PlayerCRITDamage + EquipCRITDamage;
   public static int TotalBloodSuck => PlayerBloodSuck + EquipBloodSuck;
   public static int TotalDenfense => PlayerDenfense + EquipDenfense;
   public static int TotalGoodFortune => PlayerGoodFortune + EquipGoodFortune;
}
