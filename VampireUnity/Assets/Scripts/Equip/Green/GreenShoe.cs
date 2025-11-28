using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GreenShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public GreenShoe() : base( "GreenShoeFight", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("GreenShoeSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.Green;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "GreenShoe";
        EquipAttributes.suitid = 2;
        EquipAttributes.suitname = "None";
        EquipAttributes.equip_type_id = 6;
        EquipAttributes.equip_type_name = "鞋子";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 2;
        EquipAttributes.MoveSpeed=random.Next(3,7);
        EquipAttributes.Defense=random.Next(2,4);
            
    }
    
}
