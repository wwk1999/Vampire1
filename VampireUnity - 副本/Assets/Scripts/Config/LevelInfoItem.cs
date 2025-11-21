using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelType
{
    Normal,
    Elite,
    Boss
}
public class LevelInfoItem
{
    public int Level;
    public LevelType LevelType;
    public List<Sprite> MonsterIconList;
    public List<Sprite> DiaoLuoIconList;
    public List<String> DiaoLuoNameList;
    public bool LevelInfoDir;//关卡信息方向，false左，true右
    public Vector2 LevelInfoPos;//关卡信息位置
    public Vector2 LoopScrollPos;//LoopScroll位置
}
