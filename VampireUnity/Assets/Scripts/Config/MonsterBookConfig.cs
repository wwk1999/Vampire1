using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MonsterDiaoLuoListItem
{
    public Sprite _bg;
    public Sprite _buttonIcon;
}
public struct MonsterBookData
{
    public string _name;
    public string _location;
    public string _monsterType;
    public string _introduce;
    public float _scale;
    public List<MonsterDiaoLuoListItem> _diaoluoList;
}
public class MonsterBookConfig 
{
    
    //第一关怪物列表配置
    public static MonsterBookData snotBookData = new MonsterBookData
    {
        _name = "粘液怪",
        _location = "幽影密林",
        _monsterType = "普通怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloak },
        }
    };
    public static MonsterBookData spiderBookData = new MonsterBookData
    {
        _name = "蜘蛛",
        _location = "幽影密林",
        _monsterType = "普通怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryHelmet },
        }
    };
    public static MonsterBookData batBookData = new MonsterBookData
    {
        _name = "蝙蝠",
        _location = "幽影密林",
        _monsterType = "普通怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryNecklace },
        }
    };
    public static MonsterBookData eliteBeeBookData = new MonsterBookData
    {
        _name = "蜜蜂",
        _location = "幽影密林",
        _monsterType = "精英怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDivision },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDuration },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExplosion },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExtremeSpeed },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhitePenetrate },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteScale },
        }
    };
    static public MonsterBookData bossTreeManBookData = new MonsterBookData
    {
        _name = "幽影守护神",
        _location = "幽影密林",
        _monsterType = "首领",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.2f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDivision },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDuration },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExplosion },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExtremeSpeed },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhitePenetrate },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteScale },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.TreeManCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.TreeManCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.TreeManShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.TreeManHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.TreeManRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.TreeManNecklace },
        }
    };
    
    
    
    //第二关怪物列表配置
    public static MonsterBookData chongziBookData = new MonsterBookData
    {
        _name = "虫子怪",
        _location = "熔岩火山",
        _monsterType = "普通怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 1f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloak },
        }
    };
    public static MonsterBookData xiaohuoBookData = new MonsterBookData
    {
        _name = "小火怪",
        _location = "熔岩火山",
        _monsterType = "普通怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 1f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenHelmet },
        }
    };
    public static MonsterBookData dundiBookData = new MonsterBookData
    {
        _name = "遁地怪",
        _location = "熔岩火山",
        _monsterType = "普通怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.6f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenNecklace },
        }
    };
    public static MonsterBookData elitedazuiBookData = new MonsterBookData
    {
        _name = "大嘴怪",
        _location = "熔岩火山",
        _monsterType = "精英怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDivision },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDuration },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExplosion },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExtremeSpeed },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhitePenetrate },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteScale },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenNecklace },

        }
    };
    static public MonsterBookData bossHuoShanBookData = new MonsterBookData
    {
        _name = "火山Boss",
        _location = "熔岩火山",
        _monsterType = "首领",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDivision },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDuration },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExplosion },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExtremeSpeed },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhitePenetrate },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteScale },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.HuoShanCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.HuoShanCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.HuoShanShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.HuoShanHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.HuoShanRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.HuoShanNecklace },
        }
    };
    
    
     //第三关怪物列表配置
    public static MonsterBookData wenziBookData = new MonsterBookData
    {
        _name = "蚊子怪",
        _location = "死地沼泽",
        _monsterType = "普通怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.6f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueCloak },
        }
    };
    public static MonsterBookData qingwaBookData = new MonsterBookData
    {
        _name = "青蛙怪",
        _location = "死地沼泽",
        _monsterType = "普通怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.6f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueHelmet },
        }
    };
    public static MonsterBookData jiachongBookData = new MonsterBookData
    {
        _name = "甲虫怪",
        _location = "死地沼泽",
        _monsterType = "普通怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueNecklace },
        }
    };
    public static MonsterBookData shirenhuaBookData = new MonsterBookData
    {
        _name = "食人花",
        _location = "死地沼泽",
        _monsterType = "精英怪",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.8f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDivision },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDuration },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExplosion },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExtremeSpeed },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhitePenetrate },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteScale },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueNecklace },

        }
    };
    static public MonsterBookData bossStoneBookData = new MonsterBookData
    {
        _name = "石头Boss",
        _location = "死地沼泽",
        _monsterType = "首领",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.4f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.GreenBg, _buttonIcon = ResourcesConfig.GreenNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDivision },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteDuration },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExplosion },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteExtremeSpeed },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhitePenetrate },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.WhiteScale },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.BlueNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.ZhaoZeCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.ZhaoZeCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.ZhaoZeShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.ZhaoZeHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.ZhaoZeRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.BlueBg, _buttonIcon = ResourcesConfig.ZhaoZeNecklace },
        }
    };
}
