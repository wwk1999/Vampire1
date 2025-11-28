using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BlueNecklace : EquipBase
{
    private bool isSend = false; //是否发送消息

    public BlueNecklace() : base( "BlueNecklaceFight", SuitType.None,new EquipTable()){}

     private void Awake()
        {
            SpriteRenderer = transform.Find("BlueNecklaceSprite").GetComponent<SpriteRenderer>();
            // EquipAttributes.EquipQuality = EquipQuality.Blue;
            // //添加防御，随机10-20
            Random random = new Random();
            // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
            // //添加生命值，随机10-20
            // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
            EquipAttributes.EquipName = "BlueNecklace";
            EquipAttributes.suitid = 0;
            EquipAttributes.suitname = "None";
            EquipAttributes.equip_type_id = 4;
            EquipAttributes.equip_type_name = "项链";
            EquipAttributes.Userid = GlobalUserInfo.Userid;
            EquipAttributes.Quality = 3;
            EquipAttributes.GoodFortune=random.Next(5,10);
            EquipAttributes.BloodSuck=random.Next(5,10);
            
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
