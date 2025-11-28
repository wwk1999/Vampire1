using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public BlueShoe() : base( "BlueShoeFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueShoeSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.Blue;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "BlueShoe";
        EquipAttributes.suitid = 3;
        EquipAttributes.suitname = "None";
        EquipAttributes.equip_type_id = 6;
        EquipAttributes.equip_type_name = "鞋子";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 3;
        EquipAttributes.MoveSpeed=random.Next(3,7);
        EquipAttributes.Defense=random.Next(2,4);
            
    }
    
}
