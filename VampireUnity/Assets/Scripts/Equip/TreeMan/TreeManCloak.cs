using Mysql;
using UnityEngine;
using Random = System.Random;

public class TreeManCloak : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManCloak() : base( "TreeManCloakFight", SuitType.TreeMan,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManCloakSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "TreeManCloak";
        EquipAttributes.suitid = 101;
        EquipAttributes.suitname = "树人套装";
        EquipAttributes.equip_type_id = 1;
        EquipAttributes.equip_type_name = "手套";
        //暂时写死
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 2;
        EquipAttributes.CRIT=random.Next(10,18);
        EquipAttributes.CRITDamage=random.Next(12,22);
            
    }
    
   

}
