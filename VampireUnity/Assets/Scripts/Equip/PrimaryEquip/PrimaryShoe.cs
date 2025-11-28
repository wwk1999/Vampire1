using Mysql;
using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryShoe:EquipBase
    {
        private bool isSend = false; //是否发送消息

        public PrimaryShoe() : base( "PrimaryShoeFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryShoeSprite").GetComponent<SpriteRenderer>();
            // EquipAttributes.EquipQuality = EquipQuality.White;
            // //添加防御，随机10-20
            Random random = new Random();
            // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
            // //添加生命值，随机10-20
            // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
            EquipAttributes.EquipName = "PrimaryShoe";
            EquipAttributes.suitid = 1;
            EquipAttributes.suitname = "None";
            EquipAttributes.equip_type_id = 6;
            EquipAttributes.equip_type_name = "鞋子";
            EquipAttributes.Userid = GlobalUserInfo.Userid;
            EquipAttributes.Quality = 1;
            EquipAttributes.MoveSpeed=random.Next(3,7);
            EquipAttributes.Defense=random.Next(2,4);
            
        }
       
    }
}