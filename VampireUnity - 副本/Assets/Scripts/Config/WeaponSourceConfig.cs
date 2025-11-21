using System;
using System.Collections;
using System.Collections.Generic;
using Mysql;
using UnityEngine;
public class SourceStoneConfigItem
{
   public int sourcestoneid;
   public string sourcestonename;
   public string sourcestoneQuality;
   public string sourcestoneeffect;
   public int quality;
   public int sourcestonetype;
}
public class SourceStone
{
   public int sourcestoneid { get; set; }
   public string sourcestonename { get; set; }
   public string sourcestonequality { get; set; }
   public string sourcestoneeffect { get; set; }
}


public class SourceStoneData
{
   public int id { get; set; }
   public int userid { get; set; }
   public int sourcestoneid { get; set; }
   public int sourcestonecount { get; set; }
   public SourceStone sourcestone { get; set; }
}

public class WeaponSource//武器可以镶嵌的源石列表
{
   public List<WeaponSourceStoneType> weaponSourceStoneTypes { get; set; }
   public int quality { get; set; } //武器的品质
}

public class WeaponSourceConfig 
{
   public static List<SourceStoneTable> WeaponSourceStoneList = new List<SourceStoneTable>();//所有的源石列表
   public static List<SourceStoneConfigItem> SourceStoneConfig = new List<SourceStoneConfigItem>();//进入rolewindow初始化
   
   public static List<SourceStoneData> UserSourceStone = new List<SourceStoneData>();//用户的源石
   
   public static WeaponSource OneWeaponSourceConfig = new WeaponSource();//武器可以镶嵌的源石列表
   public static WeaponSource TwoWeaponSourceConfig = new WeaponSource();//武器可以镶嵌的源石列表
   public static WeaponSource ThreeWeaponSourceConfig = new WeaponSource();//武器可以镶嵌的源石列表
   public static WeaponSource FourWeaponSourceConfig = new WeaponSource();//武器可以镶嵌的源石列表

   public static Sprite GetWeaponSourceStoneSprite(int quality,WeaponSourceStoneType weaponSourceStoneType)
   {
      switch (quality)
      {
         case 1:
            switch (weaponSourceStoneType)
            {
               case WeaponSourceStoneType.Division:
                  return ResourcesConfig.WhiteDivision;
               case WeaponSourceStoneType.Penetrate:
                  return ResourcesConfig.WhitePenetrate;
               case WeaponSourceStoneType.Duration:
                  return ResourcesConfig.WhiteDuration;
               case WeaponSourceStoneType.ExtremeSpeed:
                  return ResourcesConfig.WhiteExtremeSpeed;
               case WeaponSourceStoneType.Explosion:
                  return ResourcesConfig.WhiteExplosion;
               case WeaponSourceStoneType.Scale:
                  return ResourcesConfig.WhiteScale;
               default:
                  return null;
            }
            break;
         
         default:
            return null;
      }
   }
  
   public static void InitWeaponSourceConfig()
   {
      //第一个武器源石配置
      OneWeaponSourceConfig.quality = 1;
      OneWeaponSourceConfig.weaponSourceStoneTypes = new List<WeaponSourceStoneType>();
      OneWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Division);
      OneWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Penetrate);
      OneWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Explosion);
      OneWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.ExtremeSpeed);
      
      //第二个武器源石配置
      TwoWeaponSourceConfig.quality = 2;
      TwoWeaponSourceConfig.weaponSourceStoneTypes = new List<WeaponSourceStoneType>();
      TwoWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Division);
      TwoWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Duration);
      TwoWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Scale);
      TwoWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.ExtremeSpeed);
      
      //第三个武器源石配置
      ThreeWeaponSourceConfig.quality = 3;
      ThreeWeaponSourceConfig.weaponSourceStoneTypes = new List<WeaponSourceStoneType>();
      ThreeWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Division);
      ThreeWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Penetrate);
      ThreeWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Explosion);
      ThreeWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.ExtremeSpeed);
      
      //第四个武器源石配置
      FourWeaponSourceConfig.quality = 3;
      FourWeaponSourceConfig.weaponSourceStoneTypes = new List<WeaponSourceStoneType>();
      FourWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Division);
      FourWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.Penetrate);
      FourWeaponSourceConfig.weaponSourceStoneTypes.Add(WeaponSourceStoneType.ExtremeSpeed);
      


   }
   public static Sprite GetWeaponSourceStoneSprite(int sourcestoneid)
   {
      switch (sourcestoneid)
      {
         case 1:
            return ResourcesConfig.WhitePenetrate;
            break;
         case 7:
            return ResourcesConfig.WhiteDivision;
            break;
         case 13:
            return ResourcesConfig.WhiteExtremeSpeed;
            break;
         case 19:
            return ResourcesConfig.WhiteExplosion;
            break;
         case 25:
            return ResourcesConfig.WhiteScale;
            break;
         case 31:
            return ResourcesConfig.WhiteDuration;
            break;
      }
      return null;
   }
   
   public static SourceStoneConfigItem GetSourceStoneConfigById(int sourcestoneid)
   {
      foreach (var item in SourceStoneConfig)
      {
         if (item.sourcestoneid == sourcestoneid)
         {
            return item;
         }
      }
      return null;
   }
}
   