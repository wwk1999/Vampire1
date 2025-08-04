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
        _scale = 0.5f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Division },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Duration },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Explosion },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.ExtremeSpeed },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Penetrate },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Scale },
        }
    };
    static public MonsterBookData bossTreeManBookData = new MonsterBookData
    {
        _name = "幽影守护神",
        _location = "幽影密林",
        _monsterType = "首领",
        _introduce = "A small, green, slimy creature that attacks in groups.",
        _scale = 0.3f,
        _diaoluoList = new List<MonsterDiaoLuoListItem>
        {
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloth } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryCloak },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryShoe } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryHelmet },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryRing } ,
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.PrimaryNecklace },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Division },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Duration },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Explosion },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.ExtremeSpeed },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Penetrate },
            new MonsterDiaoLuoListItem { _bg =ResourcesConfig.WhiteBg, _buttonIcon = ResourcesConfig.Scale },
        }
    };
}
