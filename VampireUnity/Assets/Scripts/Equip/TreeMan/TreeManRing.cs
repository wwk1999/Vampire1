using UnityEngine;
using Random = System.Random;
using Mysql;

public class TreeManRing : EquipBase
{
    private bool isSend = false; //是否发送消息

    public TreeManRing() : base( "TreeManRingFight", SuitType.TreeMan,new EquipTable()){}

    private void Awake()
    {
        SpriteRenderer = transform.Find("TreeManRingSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "TreeManRing";
        EquipAttributes.suitid = 1;
        EquipAttributes.suitname = "树人套装";
        EquipAttributes.equip_type_id = 5;
        EquipAttributes.equip_type_name = "戒指";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 2;
        EquipAttributes.Damage=random.Next(6,10);
        EquipAttributes.CRIT=random.Next(7,12);
            
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
