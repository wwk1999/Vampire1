using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelRankData
{
    public string rank_type { get; set; }
    public List<LevelRankDataItem> rankings { get; set; }= new List<LevelRankDataItem>();
}
public class LevelRankDataItem
{
    public int userid { get; set; }
    public string username { get; set; }
    public int value { get; set; }
    public int position { get; set; }
}
public class UserLevelRankData
{
    public int userid { get; set; }
    public string username { get; set; }
    public string rank_type { get; set; }
    public int value { get; set; }
    public int position { get; set; }
}

public class MonsterCountRankDataItem
{
    public int userid { get; set; }
    public string username { get; set; }
    public int level { get; set; } 
    public int count { get; set; } 
    public int rank { get; set; }
}

public class UserMonsterCountRankData
{
    public int userid { get; set; }
    public string username { get; set; }
    public int level { get; set; }
    public int count { get; set; }
    public int rank { get; set; }
}
public class RankConfig : MonoBehaviour
{
    public static LevelRankData LevelRankData { get; set; } = new LevelRankData();
    public static UserLevelRankData UserLevelRankData { get; set; } = new UserLevelRankData();
    
    public static List<MonsterCountRankDataItem> MonsterCountRankData { get; set; } = new List<MonsterCountRankDataItem>();
    public static UserMonsterCountRankData UserMonsterCountRankData { get; set; } = new UserMonsterCountRankData();
}
