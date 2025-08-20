using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentItem
{
    public int equipid;
    public int quality;
    public int damage;
    public int crit;
    public int critdamage;
    public int damagespeed;
    public int bloodsuck;
    public int hp;
    public int movespeed;
    public string equipname;
    public int suitid;
    public string suitname;
    public int equip_type_id;
    public string equip_type_name;
    public int userid;
    public int defense;
    public int goodfortune;
    public int type;
}

[System.Serializable]
public class PlayerEquipData
{
    public EquipmentItem 头盔;
    public EquipmentItem 戒指;
    public EquipmentItem 手套;
    public EquipmentItem 衣服;
    public EquipmentItem 鞋子;
    public EquipmentItem 项链;
}

public class PlayerEquipConfig : MonoBehaviour
{
    public static PlayerEquipData playerEquipData=new PlayerEquipData();
}