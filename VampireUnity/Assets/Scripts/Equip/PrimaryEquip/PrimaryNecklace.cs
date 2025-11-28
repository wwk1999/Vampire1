using Mysql;
using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryNecklace:EquipBase
    {
        private bool isSend = false; //是否发送消息

        public PrimaryNecklace() : base( "PrimaryNecklaceFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryNecklaceSprite").GetComponent<SpriteRenderer>();
            // EquipAttributes.EquipQuality = EquipQuality.White;
            // //添加防御，随机10-20
            Random random = new Random();
            // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
            // //添加生命值，随机10-20
            // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
            EquipAttributes.EquipName = "PrimaryNecklace";
            EquipAttributes.suitid = 1;
            EquipAttributes.suitname = "None";
            EquipAttributes.equip_type_id = 4;
            EquipAttributes.equip_type_name = "项链";
            EquipAttributes.Userid = GlobalUserInfo.Userid;
            EquipAttributes.Quality = 1;
            EquipAttributes.GoodFortune=random.Next(5,10);
            EquipAttributes.BloodSuck=random.Next(5,10);
            
        }
        
    }
}