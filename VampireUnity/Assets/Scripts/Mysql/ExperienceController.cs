using System.Collections.Generic;
using MySqlConnector;
using UnityEngine;

public class ExperienceController : XSingleton<ExperienceController>
{
    public Dictionary<int,int> GetExperienceFromMysql()
    {
        string sql = "SELECT * FROM experience";
        MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
        MySqlDataReader reader = command.ExecuteReader();
        Dictionary<int,int> expDic=new Dictionary<int,int>();
        try
        {
            while (reader.Read())
            {
                int level = reader.GetInt32("level");
                int value = reader.GetInt32("value");
                expDic.Add(level,value);
            }
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error getting experience: " + ex.Message);
        }
        finally
        {
            reader.Close();
        }
        return expDic;
    }

}
