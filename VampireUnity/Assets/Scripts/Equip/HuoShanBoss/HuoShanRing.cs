using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HuoShanRing : EquipBase
{
    private bool isSend = false; //是否发送消息

    public HuoShanRing() : base( "HuoShanRingFight", SuitType.HuoShan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("HuoShanRingSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.Blue;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "HuoShanRing";
        EquipAttributes.suitid = 102;
        EquipAttributes.suitname = "火山套装";
        EquipAttributes.equip_type_id = 5;
        EquipAttributes.equip_type_name = "戒指";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 3;
        EquipAttributes.Damage=random.Next(2,5);
        EquipAttributes.CRIT=random.Next(3,6);
            
    }
   
}
