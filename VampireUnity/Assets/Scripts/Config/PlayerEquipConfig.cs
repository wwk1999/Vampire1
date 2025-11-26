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
    public static int HelmetId
    {
        get => PlayerData.S.helmetid;
        set => PlayerData.S.helmetid = value;
    }
    public static int RingId
    {
        get => PlayerData.S.ringid;
        set => PlayerData.S.ringid = value;
    }

    public static int CloakId
    {
        get => PlayerData.S.cloakid;
        set => PlayerData.S.cloakid = value;
    }

    public static int ClothId
    {
        get => PlayerData.S.clothid;
        set => PlayerData.S.clothid = value;
    }

    public static int ShoeId
    {
        get => PlayerData.S.shoeid;
        set => PlayerData.S.shoeid = value;
    }

    public static int NecklaceId
    {
        get => PlayerData.S.necklaceid;
        set => PlayerData.S.necklaceid = value;
    }
}