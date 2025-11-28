using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipConfig : MonoBehaviour
{
    public  enum EquipType
    {
        Helmet ,
        Ring ,
        Cloak ,
        Cloth,
        Shoe ,
        Necklace
    }
    
    public  enum EquipLevel
    {
        Primary ,
        Green ,
        Blue ,
        TreeMan,
        HuoShan ,
        ZhaoZe
    }
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