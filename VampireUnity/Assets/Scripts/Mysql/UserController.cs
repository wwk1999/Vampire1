
using System;
using System.Collections.Generic;
using MySqlConnector;
using UnityEngine;

namespace Mysql
{
    public class UserController : XSingleton<UserController>
    {
        public List<UserTable> Users;
        public int selfuserId;

        public int maxUserid;


        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        //向User表中插入数据
        public bool InsertUser(int userid,string username, string password)
        {
            if (!ConnectMysql.S.CheckConnection()) return false;
            
    
            string query = "INSERT INTO user (userid, username, password) VALUES (@userid, @username, @password)";
            MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
            command.Parameters.AddWithValue("@userid", userid);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                command.ExecuteNonQuery();
                Debug.Log("用户添加成功");
                return true;
            }
            catch (MySqlException ex)
            {
                Debug.LogError("添加用户时出错: " + ex.Message);
                return false;
            }
        }
       

        //获取User表中最大的userid
        public bool GetMaxUserId()
        {
            if (!ConnectMysql.S.CheckConnection()) return false;
            
            string query = "SELECT MAX(userid) FROM user";
            MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    maxUserid = Convert.ToInt32(result);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.LogError("获取最大用户ID时出错: " + ex.Message);
                return false;
            }
        }

        //将User表中的数据存储全部到Users中
        public bool GetUserTable()
        {
            if (!ConnectMysql.S.CheckConnection()) return false;
            
            string query = "SELECT * FROM user";
            MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
            MySqlDataReader reader = null;
            
            try
            {
                reader = command.ExecuteReader();
                Users = new List<UserTable>();
                
                while (reader.Read())
                {
                    UserTable userTable = new UserTable
                    {
                        UserId = reader.GetInt32("userid"),
                        Username = reader.GetString("username"),
                        Password = reader.GetString("password")
                    };
                    Users.Add(userTable);
                }
                return true;
            }
            catch (MySqlException ex)
            {
                Debug.LogError("查询数据库时出错: " + ex.Message);
                return false;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
        }

        public bool QueryDatabase()
        {
            if (!ConnectMysql.S.CheckConnection()) return false;
            
            string query = "SELECT * FROM user";
            MySqlCommand command = new MySqlCommand(query, ConnectMysql.Connection);
            MySqlDataReader reader = null;

            try
            {
                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    // 假设 user 表有 id、username、email 三个字段
                    int id = reader.GetInt32("userid");
                    string username = reader.GetString("username");
                    string email = reader.GetString("password");

                    Debug.Log($"ID: {id}, 用户名: {username}, 密码: {email}");
                }
                return true;
            }
            catch (MySqlException ex)
            {
                Debug.LogError("查询数据库时出错: " + ex.Message);
                return false;
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
        }
    }
}