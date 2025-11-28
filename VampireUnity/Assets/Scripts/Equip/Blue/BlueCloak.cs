using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class BlueCloak : EquipBase
{
    private bool isSend = false; //是否发送消息
    public BlueCloak() : base( "BlueCloakFight", SuitType.None,new EquipTable()){}
    private void Awake()
    {
        SpriteRenderer = transform.Find("BlueCloakSprite").GetComponent<SpriteRenderer>();
        // EquipAttributes.EquipQuality = EquipQuality.White;
        // //添加防御，随机10-20
        System.Random random = new Random();
        // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
        // //添加生命值，随机10-20
        // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
        EquipAttributes.EquipName = "BlueCloak";
        EquipAttributes.suitid = 0;
        EquipAttributes.suitname = "None";
        EquipAttributes.equip_type_id = 1;
        EquipAttributes.equip_type_name = "手套";
        //暂时写死
        EquipAttributes.Userid = GlobalUserInfo.Userid;
        EquipAttributes.Quality = 3;
        EquipAttributes.CRIT=random.Next(4,8);
        EquipAttributes.CRITDamage=random.Next(6,10);
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
            StoreController.S.SaveStoreData();
            isSend = true;
           
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowToast,EquipAttributes);

            //如果被拾取，销毁装备
            Destroy(gameObject);
        }
    }
}
