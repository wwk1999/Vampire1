using System;
using System.Collections.Generic;
using MySqlConnector;
using UnityEngine;
public class EquipData
{
    public int equipid { get; set; }
    public int quality { get; set; }
    public int damage { get; set; }
    public int crit { get; set; }
    public int critdamage { get; set; }
    public int damagespeed { get; set; }
    public int bloodsuck { get; set; }
    public int hp { get; set; }
    public int movespeed { get; set; }
    public string equipname { get; set; }
    public int suitid { get; set; }
    public string suitname { get; set; }
    public int equip_type_id { get; set; }
    public string equip_type_name { get; set; }
    public int userid { get; set; }
    public int defense { get; set; }
    public int goodfortune { get; set; }
    public int type { get; set; }
}
namespace Mysql
{
    public class EquipController : XSingleton<EquipController>
    {
        public List<EquipData> equipDatas = new List<EquipData>();

        protected override void Awake()
        {
            

            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
        
        public void GetAllEquipFromMysql()
        {
            ServerConnect.S.SendGetAllEquipRequest();//获取所有装备请求
        }

        
        
        /// <summary>
        /// 拉Equip最大值，需要先吧装备信息推到mysql
        /// </summary>
     public void GetMaxEquipId()
{
    // 构造完整 SQL 查询
    string sql = @"
        SELECT 
            CASE 
                WHEN equipid BETWEEN 11000000 AND 11999999 THEN 'WhiteProp'
                WHEN equipid BETWEEN 12000000 AND 12999999 THEN 'GreenProp'
                WHEN equipid BETWEEN 13000000 AND 13999999 THEN 'BlueProp'
                WHEN equipid BETWEEN 14000000 AND 14999999 THEN 'PurpleProp'
                WHEN equipid BETWEEN 15000000 AND 15999999 THEN 'OrangeProp'
                WHEN equipid BETWEEN 41000000 AND 41999999 THEN 'WhiteCloth'
                WHEN equipid BETWEEN 51000000 AND 51999999 THEN 'WhiteShoe'
                WHEN equipid BETWEEN 61000000 AND 61999999 THEN 'WhiteRing'
                WHEN equipid BETWEEN 71000000 AND 71999999 THEN 'WhiteNecklace'
                WHEN equipid BETWEEN 81000000 AND 81999999 THEN 'WhiteHelmet'
                WHEN equipid BETWEEN 91000000 AND 91999999 THEN 'WhiteCloak'
                WHEN equipid BETWEEN 42000000 AND 42999999 THEN 'GreenCloth'
                WHEN equipid BETWEEN 52000000 AND 52999999 THEN 'GreenShoe'
                WHEN equipid BETWEEN 62000000 AND 62999999 THEN 'GreenRing'
                WHEN equipid BETWEEN 72000000 AND 72999999 THEN 'GreenNecklace'
                WHEN equipid BETWEEN 82000000 AND 82999999 THEN 'GreenHelmet'
                WHEN equipid BETWEEN 92000000 AND 92999999 THEN 'GreenCloak'
                WHEN equipid BETWEEN 43000000 AND 43999999 THEN 'BlueCloth'
                WHEN equipid BETWEEN 53000000 AND 53999999 THEN 'BlueShoe'
                WHEN equipid BETWEEN 63000000 AND 63999999 THEN 'BlueRing'
                WHEN equipid BETWEEN 73000000 AND 73999999 THEN 'BlueNecklace'
                WHEN equipid BETWEEN 83000000 AND 83999999 THEN 'BlueHelmet'
                WHEN equipid BETWEEN 93000000 AND 93999999 THEN 'BlueCloak'
                WHEN equipid BETWEEN 44000000 AND 44999999 THEN 'PurpleCloth'
                WHEN equipid BETWEEN 54000000 AND 54999999 THEN 'PurpleShoe'
                WHEN equipid BETWEEN 64000000 AND 64999999 THEN 'PurpleRing'
                WHEN equipid BETWEEN 74000000 AND 74999999 THEN 'PurpleNecklace'
                WHEN equipid BETWEEN 84000000 AND 84999999 THEN 'PurpleHelmet'
                WHEN equipid BETWEEN 94000000 AND 94999999 THEN 'PurpleCloak'
                WHEN equipid BETWEEN 45000000 AND 45999999 THEN 'OrangeCloth'
                WHEN equipid BETWEEN 55000000 AND 55999999 THEN 'OrangeShoe'
                WHEN equipid BETWEEN 65000000 AND 65999999 THEN 'OrangeRing'
                WHEN equipid BETWEEN 75000000 AND 75999999 THEN 'OrangeNecklace'
                WHEN equipid BETWEEN 85000000 AND 85999999 THEN 'OrangeHelmet'
                WHEN equipid BETWEEN 95000000 AND 95999999 THEN 'OrangeCloak'
                ELSE 'OutOfRange'
            END AS RangeGroup,
            MAX(equipid) AS MaxEquipID
        FROM equip
        WHERE equipid BETWEEN 11000000 AND 95999999
        GROUP BY RangeGroup;
    ";

    MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);

    MySqlDataReader reader = null;
    try
    {
        reader = command.ExecuteReader();

        // 定义范围对应的最小值
        Dictionary<string, int> rangeMinValues = new Dictionary<string, int>
        {
            { "WhiteProp", 11000000 },
            { "GreenProp", 12000000 },
            { "BlueProp", 13000000 },
            { "PurpleProp", 14000000 },
            { "OrangeProp", 15000000 },
            { "WhiteCloth", 41000000 },
            { "WhiteShoe", 51000000 },
            { "WhiteRing", 61000000 },
            { "WhiteNecklace", 71000000 },
            { "WhiteHelmet", 81000000 },
            { "WhiteCloak", 91000000 },
            { "GreenCloth", 42000000 },
            { "GreenShoe", 52000000 },
            { "GreenRing", 62000000 },
            { "GreenNecklace", 72000000 },
            { "GreenHelmet", 82000000 },
            { "GreenCloak", 92000000 },
            { "BlueCloth", 43000000 },
            { "BlueShoe", 53000000 },
            { "BlueRing", 63000000 },
            { "BlueNecklace", 73000000 },
            { "BlueHelmet", 83000000 },
            { "BlueCloak", 93000000 },
            { "PurpleCloth", 44000000 },
            { "PurpleShoe", 54000000 },
            { "PurpleRing", 64000000 },
            { "PurpleNecklace", 74000000 },
            { "PurpleHelmet", 84000000 },
            { "PurpleCloak", 94000000 },
            { "OrangeCloth", 45000000 },
            { "OrangeShoe", 55000000 },
            { "OrangeRing", 65000000 },
            { "OrangeNecklace", 75000000 },
            { "OrangeHelmet", 85000000 },
            { "OrangeCloak", 95000000 }
        };

        while (reader.Read())
        {
            string rangeGroup = reader["RangeGroup"].ToString();
            int maxEquipID = Convert.ToInt32(reader["MaxEquipID"]);

            // 检查范围是否空值，以及是否在对应范围内
            if (!rangeMinValues.ContainsKey(rangeGroup))
            {
                Debug.LogWarning($"Unexpected RangeGroup: {rangeGroup}! Skipping.");
                continue;
            }

            int minEquipID = rangeMinValues[rangeGroup];
            int valueToInsert = maxEquipID >= minEquipID ? maxEquipID : minEquipID;

            if (!BagController.S.MaxEquipid.ContainsKey(rangeGroup))
            {
                BagController.S.MaxEquipid.Add(rangeGroup, valueToInsert); // 插入结果
            }
            else
            {
                BagController.S.MaxEquipid[rangeGroup]= valueToInsert; // 插入结果
            }
        }

        // 输出所有结果
        foreach (var entry in BagController.S.MaxEquipid)
        {
            Debug.Log($"Range: {entry.Key}, Max EquipID: {entry.Value}");
        }
        // 假设rangeMinValues是你本地定义的所有类型和最小ID的字典
        foreach(var key in rangeMinValues.Keys)
        {
            if (!BagController.S.MaxEquipid.ContainsKey(key))
                BagController.S.MaxEquipid[key] = rangeMinValues[key];
        }
    }
    catch (MySqlException ex)
    {
        Debug.LogError("Error fetching equip IDs for ranges: " + ex.Message);
    }
    finally
    {
        if (reader != null && !reader.IsClosed)
        {
            reader.Close(); // 确保资源被释放
        }
    }
    
}


        
        //保存装备信息到mysql
        public void BatchInsertEquipsWithTransaction(List<TableBase> equips)
        {
            Debug.Log("mysql保存装备");
            List<EquipTable> equiptables = new List<EquipTable>();
            List<SourceStoneTable> sourcestonetables = new List<SourceStoneTable>();
            foreach (var equip in equips)
            {
                if (equip.TableType == TableType.EquipTable)
                {
                    equiptables.Add((EquipTable) equip); // 确保类型转换正确
                }else if (equip.TableType == TableType.SourceStoneTable)
                {
                    sourcestonetables.Add((SourceStoneTable) equip); // 确保类型转换正确
                }
            }
            // 使用 INSERT IGNORE 避免重复 equipid 导致的主键冲突
            string sql = "INSERT IGNORE INTO equip (equipid, userid, equipname, quality, damage, crit, critdamage, damagespeed, bloodsuck, defense, hp, movespeed, goodfortune) VALUES ";
            string sql1 = "INSERT IGNORE INTO sourcestone (equipid, userid, sourcetype, count, quality) VALUES ";

            List<string> valueRows = new List<string>();
            List<string> valueRows1 = new List<string>();

            foreach (var equip in equiptables)
            {
                EquipTable equip1 = equip; // 确保类型转换正确
                string value = $"({equip1.equipid}, {equip1.Userid}, '{equip1.EquipName}', {equip1.Quality}, {equip1.Damage}, {equip1.CRIT}, {equip1.CRITDamage}, {equip1.DamageSpeed}, {equip1.BloodSuck}, {equip1.Defense}, {equip1.HP}, {equip1.MoveSpeed}, {equip1.GoodFortune})";
                valueRows.Add(value);
            }
            foreach (var sourcestone in sourcestonetables)
            {
                SourceStoneTable sourcestone1 = sourcestone; // 确保类型转换正确
                string value = $"({sourcestone1.SourceStoneId}, {sourcestone1.Userid}, '{sourcestone1.SourceStoneType}', {sourcestone1.Count}, {sourcestone1.Quality})";
                valueRows1.Add(value);
            }

            sql += string.Join(", ", valueRows);
            sql1 += string.Join(", ", valueRows1);

            // 只开启一次事务
            MySqlTransaction transaction = ConnectMysql.Connection.BeginTransaction();
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection, transaction);
            MySqlCommand command1 = new MySqlCommand(sql1, ConnectMysql.Connection, transaction);

            try
            {
                if (valueRows.Count > 0)
                {
                    command.ExecuteNonQuery(); // 批量插入装备
                }
                if (valueRows1.Count > 0)
                {
                    command1.ExecuteNonQuery(); // 批量插入源石
                }
                transaction.Commit(); // 一次性提交
                Debug.Log("Batch insert committed successfully.");
            }
            catch (MySqlException ex)
            {
                transaction.Rollback(); // 回滚事务
                Debug.LogError("Error in batch insert. Transaction rolled back: " + ex.Message);
            }
        }



        
        public void InsertEquip(EquipTable equip)
        {
            // 插入记录，如果 equip 已存在（基于主键或唯一约束），会忽略插入
            string sql =
                $"INSERT IGNORE INTO equip (equipid, userid, equipname, quality, damage, crit, critdamage, damagespeed, bloodsuck, defense, hp, movespeed, goodfortune) " +
                $"VALUES ({equip.equipid}, {equip.Userid}, '{equip.EquipName}', {equip.Quality}, {equip.Damage}, {equip.CRIT}, {equip.CRITDamage}, {equip.DamageSpeed}, {equip.BloodSuck}, {equip.Defense}, {equip.HP}, {equip.MoveSpeed}, {equip.GoodFortune})";

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);

            try
            {
                int rowsAffected = command.ExecuteNonQuery(); // 返回影响行数
                if (rowsAffected > 0)
                {
                    Debug.Log("Insert equip success"); // 插入成功
                }
                else
                {
                    Debug.Log("Equip already exists or ignored"); // equip 已存在或插入被忽略
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error inserting equip: " + ex.Message);
            }
        }

        
        // public void InsertEquip(EquipTable equip)
        // {
        //     //插入装备到Mysql,包括equipname
        //     string sql =
        //         $"INSERT INTO equip (equipid, userid,equipname, quality, damage, crit, critdamage, damagespeed, bloodsuck, denfense, hp, movespeed, goodfortune) " +
        //         $"VALUES ({equip.Equipid}, {equip.Userid},'{equip.EquipName}', {equip.Quality}, {equip.Damage}, {equip.CRIT}, {equip.CRITDamage}, {equip.DamageSpeed}, {equip.BloodSuck}, {equip.Defense}, {equip.HP}, {equip.MoveSpeed}, {equip.GoodFortune})";
        //     MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
        //     try
        //     {
        //         command.ExecuteNonQuery();
        //         Debug.Log("Insert equip success");
        //     }
        //     catch (MySqlException ex)
        //     {
        //         Debug.LogError("Error inserting equip: " + ex.Message);
        //     }
        // }

        public int MaxPropID(int quality)
        {
            int maxID = 0;
            string sql = "";
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            switch (quality)
            {
                case 1:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 11000000 AND 11999999";
                    break;
                case 2:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 12000000 AND 12999999";
                    break;
                case 3:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 13000000 AND 13999999";
                    break;
                case 4:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 14000000 AND 14999999";
                    break;
                case 5:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 15000000 AND 15999999";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }

            if (maxID > 10000000)
                return maxID;
            switch (quality)
            {
                case 1:
                    maxID = 11000000;
                    break;
                case 2:
                    maxID = 12000000;
                    break;
                case 3:
                    maxID = 13000000;
                    break;
                case 4:
                    maxID = 14000000;
                    break;
                case 5:
                    maxID = 15000000;
                    break;
            }
            return maxID;
        }

        public int MaxPrimaryWeaponID(int quality)
        {
            int maxID = 0;
            string sql = "";
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            switch (quality)
            {
                case 1:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 21000000 AND 21999999";
                    break;
                case 2:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 22000000 AND 22999999";
                    break;
                case 3:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 23000000 AND 23999999";
                    break;
                case 4:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 24000000 AND 24999999";
                    break;
                case 5:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 25000000 AND 25999999";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }

            if (maxID > 20000000)
                return maxID;
            switch (quality)
            {
                case 1:
                    maxID = 21000000;
                    break;
                case 2:
                    maxID = 22000000;
                    break;
                case 3:
                    maxID = 23000000;
                    break;
                case 4:
                    maxID = 24000000;
                    break;
                case 5:
                    maxID = 25000000;
                    break;
            }
            return maxID;
        }

        public int MaxSecondaryWeaponID(int quality)
        {
            int maxID = 0;
            string sql = "";
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            switch (quality)
            {
                case 1:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 31000000 AND 31999999";
                    break;
                case 2:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 32000000 AND 32999999";
                    break;
                case 3:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 33000000 AND 33999999";
                    break;
                case 4:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 34000000 AND 34999999";
                    break;
                case 5:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 35000000 AND 35999999";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }

            if (maxID > 30000000)
                return maxID;
            switch (quality)
            {
                case 1:
                    maxID = 31000000;
                    break;
                case 2:
                    maxID = 32000000;
                    break;
                case 3:
                    maxID = 33000000;
                    break;
                case 4:
                    maxID = 34000000;
                    break;
                case 5:
                    maxID = 35000000;
                    break;
            }
            return maxID;
        }

        public int MaxClothID(int quality)
        {
            int maxID = 0;
            string sql = "";
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            switch (quality)
            {
                case 1:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 41000000 AND 41999999";
                    break;
                case 2:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 42000000 AND 42999999";
                    break;
                case 3:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 43000000 AND 43999999";
                    break;
                case 4:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 44000000 AND 44999999";
                    break;
                case 5:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 45000000 AND 45999999";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }

            if (maxID > 40000000)
                return maxID;
            switch (quality)
            {
                case 1:
                    maxID = 41000000;
                    break;
                case 2:
                    maxID = 42000000;
                    break;
                case 3:
                    maxID = 43000000;
                    break;
                case 4:
                    maxID = 44000000;
                    break;
                case 5:
                    maxID = 45000000;
                    break;
            }
            return maxID;
        }

        public int MaxShoeID(int quality)
        {
            int maxID = 0;
            string sql = "";
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            switch (quality)
            {
                case 1:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 51000000 AND 51999999";
                    break;
                case 2:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 52000000 AND 52999999";
                    break;
                case 3:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 53000000 AND 53999999";
                    break;
                case 4:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 54000000 AND 54999999";
                    break;
                case 5:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 55000000 AND 55999999";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }

            if (maxID > 50000000)
                return maxID;
            switch (quality)
            {
                case 1:
                    maxID = 51000000;
                    break;
                case 2:
                    maxID = 52000000;
                    break;
                case 3:
                    maxID = 53000000;
                    break;
                case 4:
                    maxID = 54000000;
                    break;
                case 5:
                    maxID = 55000000;
                    break;
            }
            return maxID;
        }

        public int MaxRingID(int quality)
        {
            int maxID = 0;
            string sql = "";
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            switch (quality)
            {
                case 1:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 61000000 AND 61999999";
                    break;
                case 2:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 62000000 AND 62999999";
                    break;
                case 3:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 63000000 AND 63999999";
                    break;
                case 4:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 64000000 AND 64999999";
                    break;
                case 5:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 65000000 AND 65999999";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }

            if (maxID > 60000000)
                return maxID;
            switch (quality)
            {
                case 1:
                    maxID = 61000000;
                    break;
                case 2:
                    maxID = 62000000;
                    break;
                case 3:
                    maxID = 63000000;
                    break;
                case 4:
                    maxID = 64000000;
                    break;
                case 5:
                    maxID = 65000000;
                    break;
            }
            return maxID;
        }

        public int MaxNecklaceID(int quality)
        {
            int maxID = 0;
            string sql = "";
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            switch (quality)
            {
                case 1:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 71000000 AND 71999999";
                    break;
                case 2:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 72000000 AND 72999999";
                    break;
                case 3:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 73000000 AND 73999999";
                    break;
                case 4:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 74000000 AND 74999999";
                    break;
                case 5:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 75000000 AND 75999999";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }

            if (maxID > 70000000)
                return maxID;
            switch (quality)
            {
                case 1:
                    maxID = 71000000;
                    break;
                case 2:
                    maxID = 72000000;
                    break;
                case 3:
                    maxID = 73000000;
                    break;
                case 4:
                    maxID = 74000000;
                    break;
                case 5:
                    maxID = 75000000;
                    break;
            }
            return maxID;
        }

        //读取mysql的experience表的数据，有level和value两列
        public int MaxHelmetID(int quality)
        {
            int maxID = 0;
            string sql = "";
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            switch (quality)
            {
                case 1:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 81000000 AND 81999999";
                    break;
                case 2:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 82000000 AND 82999999";
                    break;
                case 3:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 83000000 AND 83999999";
                    break;
                case 4:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 84000000 AND 84999999";
                    break;
                case 5:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 85000000 AND 85999999";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }

            if (maxID > 80000000)
                return maxID;
            switch (quality)
            {
                case 1:
                    maxID = 81000000;
                    break;
                case 2:
                    maxID = 82000000;
                    break;
                case 3:
                    maxID = 83000000;
                    break;
                case 4:
                    maxID = 84000000;
                    break;
                case 5:
                    maxID = 85000000;
                    break;
            }
            return maxID;
        }

        public int MaxCloakID(int quality)
        {
            int maxID = 0;
            string sql = "";
            //获取mysql的equip表中的equipid在10000000-19999999之间的最大值
            switch (quality)
            {
                case 1:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 91000000 AND 91999999";
                    break;
                case 2:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 92000000 AND 92999999";
                    break;
                case 3:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 93000000 AND 93999999";
                    break;
                case 4:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 94000000 AND 94999999";
                    break;
                case 5:
                    sql = "SELECT MAX(equipid) FROM equip WHERE equipid BETWEEN 95000000 AND 95999999";
                    break;
            }

            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            try
            {
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxID = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting max equipid: " + ex.Message);
            }

            if (maxID > 90000000)
                return maxID;
            switch (quality)
            {
                case 1:
                    maxID = 91000000;
                    break;
                case 2:
                    maxID = 92000000;
                    break;
                case 3:
                    maxID = 93000000;
                    break;
                case 4:
                    maxID = 94000000;
                    break;
                case 5:
                    maxID = 95000000;
                    break;
            }
            return maxID;
        }

        public EquipTable GetEquipAttributeFromMysql(int equipId)
        {
            //根据equipId从Mysql中获取装备属性
            string sql = $"SELECT * FROM equip WHERE equipid = {equipId}";
            MySqlCommand command = new MySqlCommand(sql, ConnectMysql.Connection);
            MySqlDataReader reader = command.ExecuteReader();
            EquipTable equipTable = null;
            try
            {
                if (reader.Read())
                {
                    equipTable = new EquipTable
                    {
                        equipid = reader.GetInt32("equipid"),
                        Userid = reader.GetInt32("userid"),
                        EquipName = reader.GetString("equipname"),
                        Quality = reader.GetInt32("quality"),
                        Damage = reader.GetInt32("damage"),
                        CRIT = reader.GetInt32("crit"),
                        CRITDamage = reader.GetInt32("critdamage"),
                        DamageSpeed = reader.GetInt32("damagespeed"),
                        BloodSuck = reader.GetInt32("bloodsuck"),
                        Defense = reader.GetInt32("defense"),
                        HP = reader.GetInt32("hp"),
                        MoveSpeed = reader.GetInt32("movespeed"),
                        GoodFortune = reader.GetInt32("goodfortune")
                    };
                }
            }
            catch (MySqlException ex)
            {
                Debug.LogError("Error getting equip attribute: " + ex.Message);
            }
            finally
            {
                reader.Close();
            }

            return equipTable;
        }
    }
}