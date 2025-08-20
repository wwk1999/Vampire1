using System;
using System.Collections.Generic;
using Mysql;
using MySqlConnector;
using UnityEngine;

public class ConnectMysql : XSingleton<ConnectMysql>
{
    public string connectionString;
    public static MySqlConnection Connection;
    public bool IsConnected { get; private set; } = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // 检查数据库连接状态
    public bool CheckConnection()
    {
        if (ConnectMysql.Connection == null || ConnectMysql.Connection.State != System.Data.ConnectionState.Open)
        {
            Debug.LogWarning("数据库连接已关闭，尝试重新连接...");
            return ConnectMysql.S.ReconnectToDatabase();
        }
        return true;
    }
    
    void Start()
    {
        // //DontDestroyOnLoad(gameObject);  // 确保场景切换时不销毁此对象
        //
        // // 根据你的 MySQL 服务器配置填写这些信息
        // string server = "rm-2zevr95ez9rrid70uho.mysql.rds.aliyuncs.com";
        // string database = "Vampire";
        // string user = "wwk18255113901";
        // string password = "BaiChen123456+";
        //
        // // 增加Connect Timeout参数，设置为30秒
        // connectionString = $"server={server};database={database};uid={user};pwd={password};Connect Timeout=30;";
        // ConnectToDatabase();
        //
        // // 只有在连接成功时才执行数据库操作
        // if (IsConnected)
        // {
        //     try
        //     {
        //         UserController.S.GetUserTable();
        //         UserController.S.GetMaxUserId();
        //     }
        //     catch (Exception ex)
        //     {
        //         Debug.LogError("执行数据库操作时出错: " + ex.Message);
        //     }
        // }
        // else
        // {
        //     Debug.LogWarning("数据库连接失败，无法执行后续操作");
        // }
    }

    void ConnectToDatabase()
    {
        Connection = new MySqlConnection(connectionString);
        IsConnected = false;
        
        try
        {
            // 尝试打开连接
            Connection.Open();
            Debug.Log("成功连接到MySQL数据库");
            IsConnected = true;
            
            // 在这里执行数据库操作，如查询、插入等
            UserController.S.QueryDatabase();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("连接MySQL数据库时出错: " + ex.Message);
            // 连接失败时不执行后续操作
        }
        catch (Exception ex)
        {
            Debug.LogError("发生未知错误: " + ex.Message);
        }
    }
    
    // 添加重新连接方法
    public bool ReconnectToDatabase()
    {
        if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
        {
            Connection.Close();
        }
        
        try
        {
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
            IsConnected = true;
            Debug.Log("重新连接到MySQL数据库成功");
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError("重新连接MySQL数据库时出错: " + ex.Message);
            IsConnected = false;
            return false;
        }
    }
   
    // Update is called once per frame
    void OnDestroy()
    {
        // if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
        // {
        //     Connection.Close();
        //     IsConnected = false;
        // }
    }
}
