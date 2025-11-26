using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class StoreController : XSingleton<StoreController>
{
    public StoreDefine.StoreData StoreData;

    private string SavePath => Path.Combine(Application.persistentDataPath, "store.json");

    public void SaveStoreData(StoreDefine.StoreData data = null)
    {
        StoreData = data ?? StoreData ?? new StoreDefine.StoreData();

        var equipRuntime = EquipIDData.S;
        
        StoreData.Player.CopyFromRuntime(PlayerData.S);
        StoreData.Equip.CopyFromRuntime(equipRuntime);

        var json = JsonConvert.SerializeObject(StoreData, Newtonsoft.Json.Formatting.None);
        File.WriteAllText(SavePath, json);
        Debug.Log($"保存数据->{SavePath}");
    }

    public void LoadStoreData()
    {
        var path = SavePath;
        if (!File.Exists(path))
        {
            StoreData = new StoreDefine.StoreData();
            StoreData.Player.CopyFromRuntime(PlayerData.S);
            StoreData.Equip.CopyFromRuntime(EquipIDData.S);
            SaveStoreData(StoreData);
            Debug.Log("首次创建存档");
            return;
        }

        var json = File.ReadAllText(path);
        StoreData = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json);
        StoreData.Player.ApplyToRuntime(PlayerData.S);
        StoreData.Equip.ApplyToRuntime(EquipIDData.S);
        
        BagController.S.WhiteEquipidTable.Clear();
        BagController.S.GreenEquipidTable.Clear();
        BagController.S.BlueEquipidTable.Clear();
        BagController.S.PurpleEquipidTable.Clear();
        BagController.S.OrangeEquipidTable.Clear();

        foreach (var equip in BagController.S.EquipIdList)
        {
            if (equip.Value.Quality == 1) // 白色装备
            {
                BagController.S.WhiteEquipidTable.Add(equip.Value);
            }
            else if (equip.Value.Quality == 2) // 绿色装备
            {
                BagController.S.GreenEquipidTable.Add(equip.Value);
            }
            else if (equip.Value.Quality == 3) // 蓝色装备
            {
                BagController.S.BlueEquipidTable.Add( equip.Value);
            }
            else if (equip.Value.Quality == 4) // 紫色装备
            {
                BagController.S.PurpleEquipidTable.Add(equip.Value);
            } 
            else if (equip.Value.Quality == 5) // 金色装备
            {
                BagController.S.OrangeEquipidTable.Add(equip.Value);
            }
        }

        Debug.Log("加载数据完成");
    }
}
