using Mysql;
using UnityEngine;
using Random = System.Random;

public class TreeManCloth : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManCloth() : base( "TreeManClothFight", SuitType.TreeMan,new EquipTable()){}
    
    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManClothSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        System.Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "TreeManCloth";
        EquipAttributes.suitid = 1;
        EquipAttributes.suitname = "树人套装";
        EquipAttributes.equip_type_id = 2;
        EquipAttributes.equip_type_name = "衣服";
        //暂时写死
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 2;
        EquipAttributes.Defense=random.Next(5,8);
        EquipAttributes.HP=random.Next(25,40);
            
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            isPickUp= true;
        }else if (other.CompareTag("Player"))
        {
            if (isSend) return;
            Debug.Log("名字："+EquipAttributes.EquipName);
            //将这件装备的属性添加到数据库
            ServerConnect.S.SendSaveEquipRequest(EquipAttributes);
            isSend = true;
     


            //如果被拾取，销毁装备
            Destroy(gameObject);
        }
    }
}
