using Mysql;
using UnityEngine;
using Random = System.Random;

namespace Equip
{
    public class PrimaryCloak:EquipBase
    {
        public PrimaryCloak() : base( "PrimaryCloakFight", SuitType.None,new EquipTable()){}

        private void Awake()
        {
            SpriteRenderer = transform.Find("PrimaryCloakSprite").GetComponent<SpriteRenderer>();
            // EquipAttributes.EquipQuality = EquipQuality.White;
            // //添加防御，随机10-20
             Random random = new Random();
            // EquipAttributes.Attributes.Add(EquipAttribute.Denfense, random.Next(1, 4));
            // //添加生命值，随机10-20
            // EquipAttributes.Attributes.Add(EquipAttribute.HP, random.Next(10, 20));
            EquipAttributes.EquipName = "PrimaryCloak";
            //暂时写死
            EquipAttributes.Userid = GlobalUserInfo.Userid;
            EquipAttributes.Quality = 1;
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
                Debug.Log("名字："+EquipAttributes.EquipName);
                //将这件装备的属性添加到数据库
                EquipAttributes.Equipid= BagController.S.MaxEquipid["WhiteCloak"]+1;
                BagController.S.MaxEquipid["WhiteCloak"]= EquipAttributes.Equipid;

                 //EquipAttributes.Equipid= EquipController.S.MaxCloakID(EquipAttributes.Quality) + 1;
                 //EquipController.S.InsertEquip(EquipAttributes);
                //将这件装备的属性添加到BagController上
                BagController.S.EquipidSprite.Add(EquipAttributes.Equipid,SpriteRenderer.sprite);
                BagController.S.EquipidTable.Add(EquipAttributes.Equipid,EquipAttributes);
                BagController.S.WhiteEquipidTable.Add(EquipAttributes.Equipid,EquipAttributes);
                BagController.S.EquipIdList.Add(EquipAttributes);


                //如果被拾取，销毁装备
                Destroy(gameObject);
            }
        }
    }
}