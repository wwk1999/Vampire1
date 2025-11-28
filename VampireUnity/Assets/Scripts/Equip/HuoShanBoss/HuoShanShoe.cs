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
        EquipAttributes.suitid = 2;
        EquipAttributes.suitname = "火山套装";
        EquipAttributes.equip_type_id = 6;
        EquipAttributes.equip_type_name = "鞋子";
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 3;
        EquipAttributes.MoveSpeed=random.Next(3,7);
        EquipAttributes.Defense=random.Next(2,4);
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
            EquipIDData.S.SavaEquip(EquipAttributes);
            StoreController.S.SaveStoreData();            isSend = true;
          
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowToast,EquipAttributes);


            //如果被拾取，销毁装备
            gameObject.SetActive(false);
            GameController.S.HuoShanShoeQueue.Enqueue(gameObject);        }
    }
}
