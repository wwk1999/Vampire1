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

        Debug.Log("加载数据完成");
    }
}
