using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RemoveEquipData
{
    public int equipid { get; set; }
}

public class WearEquipData
{
    public string equip_slot { get; set; }
    public int equipid { get; set; }
}

public class BatchRemoveEquipData
{
    public int[] equipids { get; set; }
}


public class EquipServer : XSingleton<EquipServer>
{
    /// <summary>
    /// 移除装备请求
    /// </summary>
    /// <param name="equipid"></param>
    /// <returns></returns>
    public async Task<bool> SendRemoveEquipRequest(int equipid)
    {

        var RemoveEquipRequest = new GameRequest
        {
            type = "equip",
            action = "delEquip",
            data = new RemoveEquipData
            {
                equipid = equipid
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(RemoveEquipRequest);
        return true;
    }
    
    
    /// <summary>
    /// 获取玩家穿戴装备请求
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetPlayerEquipRequest()
    {
        var GetPlayerEquipRequest = new GameRequest
        {
            type = "userequip",
            action = "getEquippedItems",
            data = new RemoveEquipData
            { },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(GetPlayerEquipRequest);
        return true;
    }
    
    
    
    /// <summary>
    /// 穿戴玩家装备请求
    /// </summary>
    /// <returns></returns>
    public async Task<bool> WearPlayerEquipRequest(string equip_slot,int equipid)
    {

        var WearPlayerEquipRequest = new GameRequest
        {
            type = "userequip",
            action = "equipItem",
            data = new WearEquipData
            {
                equip_slot = equip_slot,
                equipid = equipid
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(WearPlayerEquipRequest);
        return true;
    }
    
    
    /// <summary>
    /// 按品质批量删除装备请求
    /// </summary>
    /// <param name="equips"></param>
    /// <returns></returns>
    public async Task<bool> BatchRemoveEquipRequest(int[] equips)
    {


        int count = 0;
        int[] equips1=new int[200];
        foreach (var item in equips)
        {
            switch (item)
            {
                case 1:
                    foreach (var t in BagController.S.WhiteEquipidTable)
                    {
                        equips1[count] = t.equipid;
                        count++;
                    }
                    break;
                case 2:
                    foreach (var t in BagController.S.GreenEquipidTable)
                    {
                        equips1[count] = t.equipid;
                        count++;
                    }
                    break;
                case 3:
                    foreach (var t in BagController.S.BlueEquipidTable)
                    {
                        equips1[count] = t.equipid;
                        count++;
                    }
                    break;
                case 4:
                    foreach (var t in BagController.S.PurpleEquipidTable)
                    {
                        equips1[count] = t.equipid;
                        count++;
                    }
                    break;
                case 5:
                    foreach (var t in BagController.S.OrangeEquipidTable)
                    {
                        equips1[count] = t.equipid;
                        count++;
                    }
                    break;
            }
        }

        var BatchRemoveEquipRequest = new GameRequest
        {
            type = "equip",
            action = "batchDeleteEquip",
            data = new BatchRemoveEquipData
            {
                equipids = equips1
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };
        Debug.LogError(BatchRemoveEquipRequest);

        await ServerConnect.S.SendMessageAsync(BatchRemoveEquipRequest);
        return true;
    }
    
}
