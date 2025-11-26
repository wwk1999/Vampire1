using Mysql;
using Tool;

public class EquipTable:TableBase
{
    public int equipid { get; set; }
    public int suitid { get; set; } // 套装ID
    public string suitname { get; set; } // 套装名称
    public int equip_type_id{ get; set; } // 装备类型ID
    public string equip_type_name { get; set; } // 装备类型名称
    public int Damage { get; set; }
    public int CRIT { get; set; }
    public int CRITDamage { get; set; }
    public int DamageSpeed { get; set; }
    public int BloodSuck { get; set; }
    public int Defense { get; set; }
    public int HP { get; set; }
    public int MoveSpeed { get; set; }
    public int GoodFortune { get; set; }

    public EquipTable(
        int equipid = 0,
        int userid = 0,
        string equipName = null,
        int quality = 0, 
        int damage = 0, 
        int crit = 0, 
        int critdamage = 0, 
        int damagespeed = 0, 
        int bloodsuck = 0, 
        int defense = 0, 
        int hp = 0, 
        int movespeed = 0, 
        int goodfortune = 0,
        int suitid = 0,
        string suitname = null,
        int equip_type_id = 0,
        string equip_type_name = null)
    {
        this.equipid = equipid;
        EquipName = equipName;
        Quality = quality;
        Damage = damage;
        CRIT = crit;
        CRITDamage = critdamage;
        DamageSpeed = damagespeed;
        BloodSuck = bloodsuck;
        Defense = defense;
        HP = hp;
        MoveSpeed = movespeed;
        GoodFortune = goodfortune;
        TableType = TableType.EquipTable;
        this.suitid = suitid;
        this.suitname = suitname;
        this.equip_type_id = equip_type_id;
        this.equip_type_name = equip_type_name;
    }
}