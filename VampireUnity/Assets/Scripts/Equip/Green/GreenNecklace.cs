using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class GreenNecklace : EquipBase
{
   public GreenNecklace() : base( "GreenNecklaceFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("GreenNecklaceSprite").GetComponent<SpriteRenderer>();
            // EquipAttributes.EquipQuality = EquipQuality.Green;
            // //添加防御，随机10-20
            Random random = new Random();
            // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
            // //添加生命值，随机10-20
            // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
            EquipAttributes.EquipName = "GreenNecklace";
            EquipAttributes.Userid = GlobalUserInfo.Userid;
            EquipAttributes.Quality = 1;
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
                Debug.Log("名字："+EquipAttributes.EquipName);
                //将这件装备的属性添加到数据库
                EquipAttributes.Equipid= BagController.S.MaxEquipid["GreenNecklace"]+1;
                BagController.S.MaxEquipid["GreenNecklace"]= EquipAttributes.Equipid;
                // EquipAttributes.Equipid= EquipController.S.MaxNecklaceID(EquipAttributes.Quality) + 1;
                // EquipController.S.InsertEquip(EquipAttributes);
                //将这件装备的属性添加到BagController上
                BagController.S.EquipidSprite.Add(EquipAttributes.Equipid,SpriteRenderer.sprite);
                BagController.S.EquipidTable.Add(EquipAttributes.Equipid,EquipAttributes);
                BagController.S.GreenEquipidTable.Add(EquipAttributes.Equipid,EquipAttributes);
                BagController.S.EquipIdList.Add(EquipAttributes);


                //如果被拾取，销毁装备
                Destroy(gameObject);
            }
        }
}
