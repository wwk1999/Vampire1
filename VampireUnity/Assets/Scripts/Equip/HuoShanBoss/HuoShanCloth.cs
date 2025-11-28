using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HuoShanCloth : EquipBase
{
    private bool isSend = false; //是否发送消息

    public HuoShanCloth() : base( "HuoShanClothFight", SuitType.HuoShan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("HuoShanClothSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.Blue;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "HuoShanCloth";
        EquipAttributes.suitid = 102;
        EquipAttributes.suitname = "火山套装";
        EquipAttributes.equip_type_id = 2;
        EquipAttributes.equip_type_name = "衣服";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 3;
        EquipAttributes.Defense=random.Next(1,4);
        EquipAttributes.HP=random.Next(10,20);
            
    }
   
}
