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
        public Dictionary<int,EquipTable> equipIds = new Dictionary<int, EquipTable>();
        public int nextEquipId;

        public void CopyFromRuntime(EquipIDData runtime)
        {
            if (runtime == null) return;

            nextEquipId = runtime.nextEquipId;
            equipIds.Clear();
            foreach (var pair in runtime.equipIds)
            {
                equipIds.Add(pair.Key,pair.Value);
            }
        }

        public void ApplyToRuntime(EquipIDData runtime)
        {
            if (runtime == null) return;

            runtime.nextEquipId = nextEquipId;
            runtime.equipIds.Clear();
            foreach (var pair in equipIds)
            {
                runtime.equipIds.Add(pair.Key,pair.Value);
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
        
        public int clothid;
        public int cloakid;
        public int helmetid;
        public int ringid;
        public int shoeid;
        public int necklaceid;

        public void CopyFromRuntime(PlayerData runtime)
        {
            level = runtime.level;
            exp = runtime.exp;
            bloodEnergy = runtime.bloodEnergy;
            gameLevel = runtime.maxGameLevel;
            
            clothid = runtime.clothid;
            cloakid = runtime.cloakid;
            helmetid = runtime.helmetid;
            ringid = runtime.ringid;
            shoeid = runtime.shoeid;
            necklaceid = runtime.necklaceid;
        }

        public void ApplyToRuntime(PlayerData runtime)
        {
            runtime.level = level;
            runtime.exp = exp;
            runtime.bloodEnergy = bloodEnergy;
            runtime.maxGameLevel = gameLevel;
            runtime.clothid = clothid;
            runtime.cloakid = cloakid;
            runtime.helmetid = helmetid;
            runtime.ringid = ringid;
            runtime.shoeid = shoeid;
            runtime.necklaceid = necklaceid;
        }
    }
}
