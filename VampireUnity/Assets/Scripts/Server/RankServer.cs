using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GetLevelRankData
{
    public string rank_type { get; set; }
    public int limit { get; set; }
}
public class GetUserLevelRankData
{
    public string rank_type { get; set; }
}
public class MonsterCountData
{
    public int normal { get; set; }
    public int elite { get; set; }
    public int boss { get; set; }
}

public class MonsterCountRankData
{
    public int limit { get; set; }
}


public class RankServer : XSingleton<RankServer>
{
    /// <summary>
    /// 获取等级排行榜请求
    /// </summary>
    /// <param name="rank_type"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    public async Task<bool> GetLevelRankRequest(string rank_type, int limit)
    {
        var GetLevelRankRequest = new GameRequest
        {
            type = "ranking",
            action = "getPlayerRanking",
            data = new GetLevelRankData
            {
                rank_type = rank_type,
                limit = limit
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(GetLevelRankRequest);
        return true;
    }
    
    /// <summary>
    /// 获取当前用户等级排行榜请求
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetUserLevelRankRequest()
    {

        var GetUserLevelRankRequest = new GameRequest
        {
            type = "ranking",
            action = "getUserRank",
            data = new GetUserLevelRankData
            {
                rank_type = "level"
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(GetUserLevelRankRequest);
        return true;
    }
    /// <summary>
    /// 发送杀怪数量
    /// </summary>
    /// <param name="normal"></param>
    /// <param name="elite"></param>
    /// <param name="boss"></param>
    /// <returns></returns>
    
    public async Task<bool> SendMonsterCountRequest(int normal, int elite,int boss)
    {
        var SendMonsterCountRequest = new GameRequest
        {
            type = "killcount",
            action = "batchIncrementKillCount",
            data = new MonsterCountData
            {
                normal = normal,
                elite = elite,
                boss = boss
            }
        };

        await ServerConnect.S.SendMessageAsync(SendMonsterCountRequest);
        return true;
    }
    
    
    /// <summary>
    /// 获取个人杀怪数量排行榜请求
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetUserMonsterCountRequest()
    {

        var GetUserMonsterCountRequest = new GameRequest
        {
            type = "killcount",
            action = "getUserKillRank",
            data = new MonsterCountData
            {
            }
        };

        await ServerConnect.S.SendMessageAsync(GetUserMonsterCountRequest);
        return true;
    }
    /// <summary>
    /// 获取杀怪数量排行榜请求
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetMonsterCountRequest()
    {
        var GetMonsterCountRequest = new GameRequest
        {
            type = "killcount",
            action = "getKillRanking",
            data = new MonsterCountRankData
            {
                limit = 0 
            }
        };

        await ServerConnect.S.SendMessageAsync(GetMonsterCountRequest);
        return true;
    }
}
