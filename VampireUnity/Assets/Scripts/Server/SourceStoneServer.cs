using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AddSourceStoneData
{
    public int sourcestoneid { get; set; }
    public int sourcestonecount { get; set; }
}

public class GetUserSourceStoneData
{
    public bool with_details { get; set; }
}

public class BatchRemoveSourceStoneData
{
    public int[] sourcestoneids { get; set; }
}


public class SourceStoneServer : XSingleton<SourceStoneServer>
{
    /// <summary>
    /// 获取源石配置
    /// </summary>
    /// <returns></returns>
    public async Task<bool> SendGetSourceStoneConfigRequest()
    {
        var SourceStoneConfigRequest = new GameRequest
        {
            type = "sourcestone",
            action = "getAllSourceStones",
            data = new RemoveFrienddAData
                { },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(SourceStoneConfigRequest);
        return true;
    }
    
    
    /// <summary>
    /// 发送添加源石
    /// </summary>
    /// <param name="sourcestoneid"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public async Task<bool> SendAddSourceStoneRequest(int sourcestoneid,int count)
    {
        var AddSourceStoneRequest = new GameRequest
        {
            type = "usersourcestone",
            action = "addUserSourceStone",
            data = new AddSourceStoneData
            {
                sourcestoneid=sourcestoneid,
                sourcestonecount = count
            }
        };

        await ServerConnect.S.SendMessageAsync(AddSourceStoneRequest);
        return true;
    }
    
    /// <summary>
    /// 获取用户源石
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetUserSourceStoneRequest()
    {

        var GetUserSourceStoneRequest = new GameRequest
        {
            type = "usersourcestone",
            action = "getUserSourceStones",
            data = new GetUserSourceStoneData
            {
                with_details= true
            }
        };

        await ServerConnect.S.SendMessageAsync(GetUserSourceStoneRequest);
        return true;
    }
    
    /// <summary>
    /// 批量删除源石
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public async Task<bool> BatchRemoveSourceStoneRequest(int[] ids)
    {
        int count = 0;
        int[] ids1=new int[100];
        foreach (var item in ids)
        {
            foreach (var t in BagController.S.SourceStoneTable)
            {
                if (t.Quality == item)
                {
                    ids1[count] = t.SourceStoneId;
                    count++;
                }
            }
        }

        var BatchRemoveSourceStoneRequest = new GameRequest
        {
            type = "usersourcestone",
            action = "batchDeleteUserSourceStone",
            data = new BatchRemoveSourceStoneData
            {
                sourcestoneids = ids1
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(BatchRemoveSourceStoneRequest);
        return true;
    }
}
