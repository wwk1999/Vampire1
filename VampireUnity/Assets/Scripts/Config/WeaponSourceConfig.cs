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

public class WeaponSourceConfig 
{
   public static List<SourceStoneTable> WeaponSourceStoneList = new List<SourceStoneTable>();
   public static List<SourceStoneConfigItem> SourceStoneConfig = new List<SourceStoneConfigItem>();//进入rolewindow初始化
   
   public static List<SourceStoneData> UserSourceStone = new List<SourceStoneData>();//用户的源石

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
   