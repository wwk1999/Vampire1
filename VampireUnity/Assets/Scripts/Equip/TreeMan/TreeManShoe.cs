using UnityEngine;
using Random = System.Random;
using Mysql;

public class TreeManShoe : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManShoe() : base( "TreeManShoeFight", SuitType.TreeMan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManShoeSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "TreeManShoe";
        EquipAttributes.suitid = 101;
        EquipAttributes.suitname = "树人套装";
        EquipAttributes.equip_type_id = 6;
        EquipAttributes.equip_type_name = "鞋子";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 2;
        EquipAttributes.MoveSpeed=random.Next(8,13);
        EquipAttributes.Defense=random.Next(5,8);
            
    }
    
}
