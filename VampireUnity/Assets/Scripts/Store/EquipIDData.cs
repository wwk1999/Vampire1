using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipIDData : XSingleton<EquipIDData>
{
    public Dictionary<int,EquipTable> equipIds = new Dictionary<int, EquipTable>();
    public int nextEquipId = 1;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public int GenerateEquipId()
    {
        return nextEquipId++;
    }

    public void SavaEquip(EquipTable equip)
    {
        var data = new EquipTable()
        {
            equipid = GenerateEquipId(),
            Quality = equip.Quality,
            Damage = equip.Damage,
            CRIT = equip.CRIT,
            CRITDamage = equip.CRITDamage,
            DamageSpeed = equip.DamageSpeed,
            BloodSuck = equip.BloodSuck,
            HP = equip.HP,
            MoveSpeed = equip.MoveSpeed,
            suitid = equip.suitid,
            suitname = equip.suitname,
            equip_type_id = equip.equip_type_id,
            equip_type_name = equip.equip_type_name,
            Defense = equip.Defense,
            GoodFortune = equip.GoodFortune,
            EquipName = equip.EquipName
        };
        equipIds.Add(data.equipid,data);
    }
}
