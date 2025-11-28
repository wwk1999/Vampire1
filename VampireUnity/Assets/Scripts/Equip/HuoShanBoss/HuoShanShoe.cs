using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HuoShanShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public HuoShanShoe() : base( "HuoShanShoeFight", SuitType.HuoShan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("HuoShanShoeSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.Blue;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "HuoShanShoe";
        EquipAttributes.suitid = 102;
        EquipAttributes.suitname = "火山套装";
        EquipAttributes.equip_type_id = 6;
        EquipAttributes.equip_type_name = "鞋子";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 3;
        EquipAttributes.MoveSpeed=random.Next(3,7);
        EquipAttributes.Defense=random.Next(2,4);
    }
   
}
