using System.Collections;
using System.Collections.Generic;
using MySqlConnector;
using UnityEngine;

public class PlayerInfoController : XSingleton<PlayerInfoController>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

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

    public void GetPlayerInfo(int userid)
    {
        if (!ConnectMysql.S.CheckConnection()) return;

        string query = "SELECT level, experience, gamelevel,bloodenergy FROM playerinfo WHERE userid = @userid";
        MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
        command.Parameters.AddWithValue("@userid", userid);

        try
        {
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    GlobalPlayerAttribute.Level = reader.GetInt32("level");
                    GlobalPlayerAttribute.Exp = reader.GetInt32("experience");
                    GlobalPlayerAttribute.GameLevel = reader.GetInt32("gamelevel");
                    GlobalPlayerAttribute.BloodEnergy = reader.GetInt32("bloodenergy");
                }
                else
                {
                    Debug.LogWarning("未找到对应的玩家信息");
                }
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError("获取玩家信息时出错: " + ex.Message);
        }
    }
    
    public void UpdatePlayerInfo( int userid,int level, int experience, int gamelevel,int bloodenergy)
    {
        if (!ConnectMysql.S.CheckConnection()) return;

        string query = "UPDATE playerinfo SET level = @level, experience = @experience, gamelevel = @gamelevel,bloodenergy=@bloodenergy WHERE userid = @userid";
        MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
        command.Parameters.AddWithValue("@userid", userid);
        command.Parameters.AddWithValue("@level", level);
        command.Parameters.AddWithValue("@experience", experience);
        command.Parameters.AddWithValue("@gamelevel", gamelevel);
        command.Parameters.AddWithValue("@bloodenergy", bloodenergy);

        try
        {
            command.ExecuteNonQuery();
            Debug.Log("mysql更新playerinfo成功");
            return;
        }
        catch (MySqlException ex)
        {
            Debug.LogError("mysql更新playerinfo出错: " + ex.Message);
            return;
        }
    }
    
    public void UpdatePlayerInfo( int userid,int level, int experience)
    {
        if (!ConnectMysql.S.CheckConnection()) return;

        string query = "UPDATE playerinfo SET level = @level, experience = @experience WHERE userid = @userid";
        MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
        command.Parameters.AddWithValue("@userid", userid);
        command.Parameters.AddWithValue("@level", level);
        command.Parameters.AddWithValue("@experience", experience);

        try
        {
            command.ExecuteNonQuery();
            Debug.Log("mysql更新playerinfo成功");
            return;
        }
        catch (MySqlException ex)
        {
            Debug.LogError("mysql更新playerinfo出错: " + ex.Message);
            return;
        }
    }
    
    public void UpdatePlayerInfo( int userid,int gamelevel)
    {
        if (!ConnectMysql.S.CheckConnection()) return;

        string query = "UPDATE playerinfo SET  gamelevel = @gamelevel WHERE userid = @userid";
        MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
        command.Parameters.AddWithValue("@userid", userid);
        command.Parameters.AddWithValue("@gamelevel", gamelevel);
        try
        {
            command.ExecuteNonQuery();
            Debug.Log("mysql更新playerinfo成功");
            return;
        }
        catch (MySqlException ex)
        {
            Debug.LogError("mysql更新playerinfo出错: " + ex.Message);
            return;
        }
    }
}
