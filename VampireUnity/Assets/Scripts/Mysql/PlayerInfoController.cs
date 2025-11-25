using System;
using System.Collections;
using System.Collections.Generic;
using MySqlConnector;
using Newtonsoft.Json;
using UnityEngine;


public class PlayerInfo
{
    public int UserId { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int GameLevel { get; set; }
    public int BloodEnergy { get; set; }
}
public class PlayerInfoController : XSingleton<PlayerInfoController>
{
    //获取玩家信息消息处

    public void RegisterInit(int userid)
    {
        if (!ConnectMysql.S.CheckConnection()) return;

        string query =
            "INSERT INTO playerinfo (userid, level, experience,gamelevel) VALUES (@userid, @level, @experience,@gamelevel)";
        MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
        command.Parameters.AddWithValue("@userid", userid);
        command.Parameters.AddWithValue("@level", 1);
        command.Parameters.AddWithValue("@experience", 0);
        command.Parameters.AddWithValue("@gamelevel", 1);


        try
        {
            command.ExecuteNonQuery();
            Debug.Log("mysql初始化playerinfo成功");
            return;
        }
        catch (MySqlException ex)
        {
            Debug.LogError("mysql初始化playerinfo出错: " + ex.Message);
            return;
        }

    }
    
    
    public void UpdatePlayerInfo( int level, int experience, int gamelevel,int bloodenergy)
    {
       ServerConnect.S.SendUpdatePlayerInfoRequest(level, experience, gamelevel, bloodenergy);
    }
    
}
