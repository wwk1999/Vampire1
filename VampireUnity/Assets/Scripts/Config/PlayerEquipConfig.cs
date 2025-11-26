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

public class PlayerEquipConfig : MonoBehaviour
{
    public static int HelmetId;
    public static int RingId;
    public static int CloakId;
    public static int ClothId;
    public static int ShoeId;
    public static int NecklaceId;
}