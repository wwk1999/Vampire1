using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDefine : XSingleton<StoreDefine>
{
    [System.Serializable]
    public class StoreData
    {
        public EquipData Equip = new EquipData();
        public PlayData Player = new PlayData();
    }

    [System.Serializable]
    public class EquipData
    {
        public List<EquipTable> equipIds = new List<EquipTable>();
        public int nextEquipId;

        public void CopyFromRuntime(EquipIDData runtime)
        {
            if (runtime == null) return;

            nextEquipId = runtime.nextEquipId;
            equipIds.Clear();
            foreach (var pair in runtime.equipIds)
            {
                equipIds.Add(pair);
            }
        }

        public void ApplyToRuntime(EquipIDData runtime)
        {
            if (runtime == null) return;

            runtime.nextEquipId = nextEquipId;
            runtime.equipIds.Clear();
            foreach (var pair in equipIds)
            {
                runtime.equipIds.Add(pair);
            }
        }
    }

    [System.Serializable]
    public class PlayData
    {
        public int level;
        public int exp;
        public int bloodEnergy;
        public int gameLevel;

        public void CopyFromRuntime(PlayerData runtime)
        {
            level = runtime.level;
            exp = runtime.exp;
            bloodEnergy = runtime.bloodEnergy;
            gameLevel = runtime.gameLevel;
        }

        public void ApplyToRuntime(PlayerData runtime)
        {
            runtime.level = level;
            runtime.exp = exp;
            runtime.bloodEnergy = bloodEnergy;
            runtime.gameLevel = gameLevel;
        }
    }
}
